using HW3;
using Microsoft.Extensions.Configuration;

var builder = new ConfigurationBuilder();
builder.SetBasePath(Directory.GetCurrentDirectory());
builder.AddJsonFile("appsettings.json");

var config = builder.Build();
string connectionString = config.GetConnectionString("MyJCS")!;

using var db = new UserContext(connectionString);

var users = db.Users.ToList();

while (true)
{
    Console.Clear();
    Console.WriteLine("=== User Panel ===");
    Console.WriteLine("1. Sign In (Log In)");
    Console.WriteLine("2. Sign Up (Register)");
    Console.WriteLine("3. Exit");
    Console.Write("Choose an option (1-3): ");

    string choice = Console.ReadLine()!;

    switch (choice)
    {
        case "1":
            User.SignIn(users);
            break;
        case "2":
            User.SignUp(users, db);
            break;
        case "3":
            Console.Clear();
            Console.WriteLine("Bye o/");
            return;
        default:
            Console.Clear();
            Console.WriteLine("Invalid choice. Try Again!");
            Console.ReadKey();
            break;
    }
}
