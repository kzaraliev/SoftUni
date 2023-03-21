using System.Linq;
using System.Text;
using CarDealer;
using Newtonsoft.Json;
using SoftJail.Data.Models;
using SoftJail.Data.Models.Enums;
using SoftJail.DataProcessor.ImportDto;

namespace SoftJail.DataProcessor
{

    using Data;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid Data";
        private const string ImportDepartmentsSuccess = "Imported {0} with {1} cells";
        private const string ImportPrisonersSuccess = "Imported {0} {1} years old";
        private const string ImportOfficersPrisonersSuccess = "Imported {0} ({1} prisoners)";

        public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();
            List<Department> departments = new List<Department>();

            var departmentCells = JsonConvert.DeserializeObject<ImportDepartmentsAndCellsDto[]>(jsonString);

            foreach (var dto in departmentCells)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Department department = new Department()
                {
                    Name = dto.Name,
                };

                bool departmentValid = true;
                foreach (var cellsDto in dto.Cells)
                {
                    if (!IsValid(cellsDto))
                    {
                        departmentValid = false;
                        continue;
                    }

                    Cell cell = new Cell()
                    {
                        CellNumber = cellsDto.CellNumber,
                        HasWindow = cellsDto.HasWindow
                    };
                    department.Cells.Add(cell);

                    
                }
                if (!departmentValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (department.Cells.Count == 0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                departments.Add(department);
                sb.AppendLine(string.Format(ImportDepartmentsSuccess, department.Name.ToString(), department.Cells.Count));
            }

            context.Departments.AddRange(departments);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();
            List<Prisoner> prisoners = new List<Prisoner>();

            var prisonersMails = JsonConvert.DeserializeObject<ImportPrisonersAndMailsDto[]>(jsonString);

            foreach (var dto in prisonersMails)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime incarcerationDate;
                bool isIncarcerationDateValid = DateTime.TryParseExact(dto.IncarcerationDate, "dd/MM/yyyy",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out incarcerationDate);

                if (!isIncarcerationDateValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime? releaseDate = null;
                if (!string.IsNullOrEmpty(dto.ReleaseDate))
                {
                    DateTime releaseDateValue;
                    bool IsReleaseDateValid = DateTime.TryParseExact(dto.ReleaseDate, "dd/MM/yyyy",
                        CultureInfo.InvariantCulture, DateTimeStyles.None, out releaseDateValue);

                    if (!IsReleaseDateValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    releaseDate = releaseDateValue;
                }

                Prisoner prisoner = new Prisoner()
                {
                    FullName = dto.FullName,
                    Nickname = dto.Nickname,
                    Age = dto.Age,
                    IncarcerationDate = incarcerationDate,
                    ReleaseDate = releaseDate,
                    Bail = dto.Bail,
                    CellId = dto.CellId,
                };

                bool areMailsValid = true;
                foreach (var mail in dto.Mails)
                {
                    if (!IsValid(mail))
                    {
                        areMailsValid = false;
                        continue;
                    }

                    prisoner.Mails.Add(new Mail()
                    {
                        Description = mail.Description,
                        Sender = mail.Sender,
                        Address = mail.Address
                    });
                }

                if (!areMailsValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                prisoners.Add(prisoner);
                sb.AppendLine(string.Format(ImportPrisonersSuccess, prisoner.FullName, prisoner.Age));
            }
            context.Prisoners.AddRange(prisoners);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
            XmlHelper xmlHelper = new XmlHelper();
            StringBuilder sb = new StringBuilder();
            List<Officer> officerList = new List<Officer>();

            var officersPrisoners = xmlHelper.Deserializer<ImportOfficersPrisonersDto[]>(xmlString, "Officers");

            foreach (var dto in officersPrisoners)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                object position;
                bool isValidPosition = Enum.TryParse(typeof(Position), dto.Position, out position);

                if (!isValidPosition)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                object weapon;
                bool isValidWeapon = Enum.TryParse(typeof(Weapon), dto.Weapon, out weapon);

                if (!isValidWeapon)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Officer officer = new Officer()
                {
                    FullName = dto.FullName,
                    Salary = dto.Salary,
                    Position = (Position)position,
                    Weapon =  (Weapon)weapon,
                    DepartmentId = dto.DepartmentId
                };

                foreach (var prisonerDto in dto.Prisoners)
                {
                    officer.OfficerPrisoners.Add(new OfficerPrisoner()
                    {
                        Officer = officer,
                        PrisonerId = prisonerDto.Id
                    });
                }

                officerList.Add(officer);
                sb.AppendLine(string.Format(ImportOfficersPrisonersSuccess, officer.FullName, officer.OfficerPrisoners.Count));
            }

            context.Officers.AddRange(officerList);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(obj, validationContext, validationResult, true);
            return isValid;
        }
    }
}