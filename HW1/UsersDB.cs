using Microsoft.Data.SqlClient;

public class UsersDB
{
    private readonly string connectionString;

    public UsersDB(string connString)
    {
        connectionString = connString;
    }

    public List<Users> GetUsers()
    {
        List<Users> users = new();
        using (SqlConnection conn = new(connectionString))
        {
            conn.Open();
            SqlCommand command = new("SELECT * FROM Users", conn);

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                users.Add(new Users
                {
                    Id = (int)reader[0],
                    Username = reader[1].ToString()!,
                    Password = reader[2].ToString()!,
                    FirstName = reader[3].ToString()!,
                    LastName = reader[4].ToString()!,
                    Age = (int)reader[5],
                    Gender = (bool)reader[6],
                });
            }
        }

        return users;
    }

    public void AddUser(Users newUser)
    {
        SqlCommand command = new();

        using (SqlConnection conn = new(connectionString))
        {
            conn.Open();

            string insertQuery = $@"INSERT INTO Users(Username, Password, FirstName, LastName, Age, Gender) 
                                    VALUES('{newUser.Username}', '{newUser.Password}', '{newUser.FirstName}',
                                            '{newUser.LastName}', '{newUser.Age}', '{newUser.Gender}')";

            command.CommandText = insertQuery;
            command.Connection = conn;

            command.ExecuteNonQuery();

        }
    }
}