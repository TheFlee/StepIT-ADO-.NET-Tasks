using HW3;
using Microsoft.Identity.Client;
using System.Threading.Channels;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public int Age { get; set; }
    public bool Gender { get; set; }


    public override string ToString()
    {
        return $@"Id = {Id}
Username = {Username}
Password = {Password}
Name = {FirstName} {LastName}
Age = {Age}
Gender = {Gender}";
    }

    internal static void SignUp(List<User> users, UserContext db)
    {
        Console.Clear();
        Console.WriteLine("=== Sign Up ===");

        Console.Write("Username: ");
        string uname = Console.ReadLine()!;

        if (users.Any(u => u.Username.Equals(uname, StringComparison.OrdinalIgnoreCase)))
        {
            Console.WriteLine("Username already exists!");
            Console.ReadKey();
            return;
        }

        Console.Write("Password: ");
        string pass = Console.ReadLine()!;

        Console.Write("FirstName: ");
        string fname = Console.ReadLine()!;

        Console.Write("LastName: ");
        string lname = Console.ReadLine()!;

        Console.Write("Age: ");
        int age = int.Parse(Console.ReadLine()!);

        Console.Write("Gender (0 = Female, 1 = Male): ");
        bool gender = Console.ReadLine() == "1";

        User newUser = new() { Username = uname, Password = pass, FirstName = fname, LastName = lname, Age = age, Gender = gender };
        users.Add(newUser);
        db.Users.Add(newUser);
        db.SaveChanges();

        Console.Clear();
        Console.WriteLine($"Welcome, {newUser.FirstName} {newUser.LastName}!");
        Console.ReadKey();
    }

    public static void SignIn(List<User> users)
    {
        Console.Clear();
        Console.WriteLine("=== Sign In ===");

        Console.Write("Username: ");
        string uname = Console.ReadLine()!;

        Console.Write("Password: ");
        string pass = Console.ReadLine()!;

        var user = users.FirstOrDefault(u => u.Username.Equals(uname, StringComparison.OrdinalIgnoreCase) && u.Password == pass);

        Console.Clear();
        if (user != null)
        {
            Console.WriteLine($"Welcome back, {user.FirstName} {user.LastName}!");
        }
        else
        {
            Console.WriteLine("Invalid username or password.");
        }
        Console.ReadKey();
    }

}
