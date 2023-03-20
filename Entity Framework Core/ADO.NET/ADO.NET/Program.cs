using Microsoft.Data.SqlClient;

SqlConnection connection = new SqlConnection("Server=.;Database=SoftUni;Integrated Security=true;Trust Server Certificate=true");
connection.Open();

using (connection)
{
    SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM [Employees]", connection);
    int? employeesCount = (int?) await command.ExecuteScalarAsync(); //? - moje da priema null(zaqvkata moje da vurne null)
    Console.WriteLine($"Employees count: {employeesCount}");
}

//READER
SqlConnection connectionReader = new SqlConnection("Server=DESKTOP-7ITDFKN\\SQLEXPRESS;Database=SoftUni;Integrated Security=true;Trust Server Certificate=true");
connectionReader.Open();

using (connection)
{
    SqlCommand command = new SqlCommand("SELECT * FROM [Employees] WHERE [DepartmentID] = 7", connectionReader);
    SqlDataReader reader = await command.ExecuteReaderAsync();

    using (reader)
    {
        while (reader.Read())
        {
            string? firstName = reader["FirstName"]?.ToString(); //raboti s ime na kolona
            string? lastName = reader[2]?.ToString(); //raboti s index na kolonata

            Console.WriteLine($"{firstName} {lastName}");
        }
    }
}

//!!!!!!!!!
//PAZI OT DATABASE INJECTION(ne moje potrebitel da ima dostup do db)
void InsertProject(string name, string descriprtion, DateTime startDate, DateTime endDate)
{
    SqlCommand cmd = new SqlCommand(
        "INSERT INTO [Projects] " +
        "(Name, Description, StartDate, EndDate) VALUES" +
        "(@name, @desc, @start, @end)", connection);

    cmd.Parameters.AddWithValue("@name", name);
    cmd.Parameters.AddWithValue("@desc", descriprtion);
    cmd.Parameters.AddWithValue("@start", startDate);
    cmd.Parameters.AddWithValue("@end", endDate);

    cmd.ExecuteNonQuery();
}
