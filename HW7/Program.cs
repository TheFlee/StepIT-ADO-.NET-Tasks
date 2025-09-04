using HW7;
using Microsoft.EntityFrameworkCore;

Console.WriteLine();

using var db = new LibraryContext();

#region Eager loading
//while (true)
//{
//    Console.WriteLine("1. Books by Themes");
//    Console.WriteLine("2. Books by Categories");
//    Console.WriteLine("3. Books by Authors");
//    Console.Write("Choose option: ");

//    var choice = Console.ReadLine();

//    Console.Clear();

//    switch (choice)
//    {
//        case "1":
//            var themes = db.Themes.Include(t => t.Books).ToList();

//            foreach (var theme in themes)
//            {
//                Console.ForegroundColor = ConsoleColor.Red;
//                Console.WriteLine($"{theme.Name}");
//                foreach (var book in theme.Books)
//                {
//                    Console.ForegroundColor = ConsoleColor.White;
//                    Console.WriteLine($"    {book.Name}");
//                }
//                Console.WriteLine();
//            }
//            break;
//        case "2":
//            var categories = db.Categories.Include(c => c.Books).ToList();

//            foreach (var category in categories)
//            {
//                Console.ForegroundColor = ConsoleColor.Red;
//                Console.WriteLine($"{category.Name}");
//                foreach (var book in category.Books)
//                {
//                    Console.ForegroundColor = ConsoleColor.White;
//                    Console.WriteLine($"    {book.Name}");
//                }
//                Console.WriteLine();
//            }
//            break;
//        case "3":
//            var authors = db.Authors.Include(a => a.Books).ToList();

//            foreach (var author in authors)
//            {
//                Console.ForegroundColor = ConsoleColor.Red;
//                Console.WriteLine($"{author.FirstName} {author.LastName}");
//                foreach (var book in author.Books)
//                {
//                    Console.ForegroundColor = ConsoleColor.White;
//                    Console.WriteLine($"    {book.Name}");
//                }
//                Console.WriteLine();
//            }
//            break;
//        default:
//            Console.WriteLine("Invalid choice!");
//            break;
//    }
//    Console.WriteLine("Press any key to continue!");
//    Console.ReadKey();
//    Console.Clear();
//}
#endregion

#region Explicit loading
//while (true)
//{
//    Console.WriteLine("1. Books by Themes");
//    Console.WriteLine("2. Books by Categories");
//    Console.WriteLine("3. Books by Authors");
//    Console.Write("Choose option: ");

//    var choice = Console.ReadLine();
//    Console.Clear();

//    switch (choice)
//    {
//        case "1":
//            var themes = db.Themes.ToList();
//            foreach (var theme in themes)
//            {
//                db.Books.Where(b => b.IdThemes == theme.Id).Load();

//                Console.ForegroundColor = ConsoleColor.Red;
//                Console.WriteLine($"{theme.Name}");

//                foreach (var book in theme.Books)
//                {
//                    Console.ForegroundColor = ConsoleColor.White;
//                    Console.WriteLine($"    {book.Name}");
//                }

//                Console.WriteLine();
//            }
//            break;

//        case "2":
//            var categories = db.Categories.ToList();
//            foreach (var category in categories)
//            {
//                db.Books.Where(b => b.IdCategory == category.Id).Load();

//                Console.ForegroundColor = ConsoleColor.Red;
//                Console.WriteLine($"{category.Name}");

//                foreach (var book in category.Books)
//                {
//                    Console.ForegroundColor = ConsoleColor.White;
//                    Console.WriteLine($"    {book.Name}");
//                }

//                Console.WriteLine();
//            }
//            break;

//        case "3":
//            var authors = db.Authors.ToList();
//            foreach (var author in authors)
//            {
//                db.Books.Where(b => b.IdAuthor == author.Id).Load();

//                Console.ForegroundColor = ConsoleColor.Red;
//                Console.WriteLine($"{author.FirstName} {author.LastName}");

//                foreach (var book in author.Books)
//                {
//                    Console.ForegroundColor = ConsoleColor.White;
//                    Console.WriteLine($"    {book.Name}");
//                }

//                Console.WriteLine();
//            }
//            break;

//        default:
//            Console.WriteLine("Invalid choice!");
//            break;
//    }

//    Console.WriteLine("Press any key to continue!");
//    Console.ReadKey();
//    Console.Clear();
//}
#endregion

#region Lazy loading
// UseLazyLoadingProxies() elave etdim

while (true)
{
    Console.WriteLine("1. Books by Themes");
    Console.WriteLine("2. Books by Categories");
    Console.WriteLine("3. Books by Authors");
    Console.Write("Choose option: ");

    var choice = Console.ReadLine();
    Console.Clear();

    switch (choice)
    {
        case "1":
            var themes = db.Themes.ToList();
            foreach (var theme in themes)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{theme.Name}");

                foreach (var book in theme.Books)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"    {book.Name}");
                }

                Console.WriteLine();
            }
            break;

        case "2":
            var categories = db.Categories.ToList();
            foreach (var category in categories)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{category.Name}");

                foreach (var book in category.Books)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"    {book.Name}");
                }

                Console.WriteLine();
            }
            break;

        case "3":
            var authors = db.Authors.ToList();
            foreach (var author in authors)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{author.FirstName} {author.LastName}");

                foreach (var book in author.Books)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"    {book.Name}");
                }

                Console.WriteLine();
            }
            break;

        default:
            Console.WriteLine("Invalid choice!");
            break;
    }

    Console.WriteLine("Press any key to continue!");
    Console.ReadKey();
    Console.Clear();
}

#endregion