using System.Globalization;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using TeisterMask.Data.Models;
using TeisterMask.Data.Models.Enums;
using TeisterMask.DataProcessor.ImportDto;
using Theatre;

namespace TeisterMask.DataProcessor
{
    using System;
    using System.Collections.Generic;

    using System.ComponentModel.DataAnnotations;

    using Data;

    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedProject
            = "Successfully imported project - {0} with {1} tasks.";

        private const string SuccessfullyImportedEmployee
            = "Successfully imported employee - {0} with {1} tasks.";

        public static string ImportProjects(TeisterMaskContext context, string xmlString)
        {
            XmlHelper xmlHelper = new XmlHelper();
            StringBuilder sb = new StringBuilder();
            List<Project> projects = new List<Project>();

            var projectsDto = xmlHelper.Deserializer<ImportProjectsDto[]>(xmlString, "Projects");

            foreach (var dto in projectsDto)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime openDate;
                bool isValidOpenDate = DateTime.TryParseExact(dto.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture,
                    DateTimeStyles.None, out openDate);

                if (!isValidOpenDate)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                
                DateTime dueDate;
                bool isValidDueDate = DateTime.TryParseExact(dto.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture,
                    DateTimeStyles.None, out dueDate);

                if (dto.DueDate == "" || dto.DueDate == null)
                {
                    dueDate = DateTime.MaxValue;
                }

                var project = new Project()
                {
                    Name = dto.Name,
                    OpenDate = openDate,
                    DueDate = dueDate,
                };

                foreach (var dtoTask in dto.Tasks)
                {
                    if (!IsValid(dtoTask))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    DateTime openDateTask;
                    bool isValidOpenDateTask = DateTime.TryParseExact(dtoTask.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture,
                        DateTimeStyles.None, out openDateTask);

                    if (!isValidOpenDateTask)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    DateTime dueDateTask;
                    bool isValidDueDateTask = DateTime.TryParseExact(dtoTask.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture,
                        DateTimeStyles.None, out dueDateTask);

                    if (!isValidDueDateTask)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (openDateTask < openDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (dueDateTask > dueDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var task = new Task()
                    {
                        Name = dtoTask.Name,
                        OpenDate = openDateTask,
                        DueDate = dueDateTask,
                        ExecutionType = (ExecutionType)dtoTask.ExecutionType,
                        LabelType = (LabelType)dtoTask.LabelType
                    };

                    project.Tasks.Add(task);
                }

                projects.Add(project);
                sb.AppendLine(string.Format(SuccessfullyImportedProject, project.Name, project.Tasks.Count()));
            }
            context.Projects.AddRange(projects);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static string ImportEmployees(TeisterMaskContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();
            List<Employee> employees = new List<Employee>();
            int[] tasksInDb = context.Tasks.Select(t => t.Id).ToArray();

            var employeesDto = JsonConvert.DeserializeObject<ImportEmployeesDto[]>(jsonString);

            foreach (var dto in employeesDto)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var employee = new Employee()
                {
                    Username = dto.Username,
                    Email = dto.Email,
                    Phone = dto.Phone,
                };

                foreach (var dtoTask in dto.Tasks.Distinct())
                {
                    Task t = context.Tasks.Find(dtoTask);
                    if (t == null)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    employee.EmployeesTasks.Add(new EmployeeTask()
                    {
                        Task = t
                    });
                }

                employees.Add(employee);
                sb.AppendLine(string.Format(SuccessfullyImportedEmployee, employee.Username,
                    employee.EmployeesTasks.Count));
            }
            context.Employees.AddRange(employees);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}