using System;
using LibraryAppBusinessLogic;
namespace LibraryApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Library App!!");

            // Class for Customer

            Console.WriteLine("Enter your ID, name and Email");
            
            int id;
            int.TryParse(Console.ReadLine(), out id);

            string name = Console.ReadLine();
            
            string email = Console.ReadLine();

            Customer customer = new Customer() { CustomerId = id, Name = name, Email = email };

            System.Threading.Thread.Sleep(2000);
            Console.WriteLine("-----------------");

            LibraryManager libraryManager = new LibraryManager();

            Console.WriteLine("List out all eBooks");
            EBook[] allEbooks =  libraryManager.ListAllAvialbleEBooks();

            System.Threading.Thread.Sleep(2000);

            Console.WriteLine("\nList out all DVDs");
            EBook[] allDVDs = libraryManager.ListAllAvialbleDVDs();

        IssueAnItem:

            Console.WriteLine("Enter Library Item's Id to issue");
            int libItemId;
            int.TryParse(Console.ReadLine(), out libItemId);

            LibraryItem libraryItemToIssue = libraryManager.GetLibraryItem(libItemId);

            libraryManager.IssueLibraryItemToCustomer(customer, libraryItemToIssue);

            Console.WriteLine("More books/DVDs?Enter YES or NO");
            string userResponse = Console.ReadLine();

            if (userResponse == "YES")
            {
                goto IssueAnItem;
            }

            customer.ViewMyBorrowedLibraryItems();

            PlayAnItem:

            Console.WriteLine("Enter ID to play an item from your list.");
            int libItemToPlayId;
            int.TryParse(Console.ReadLine(), out libItemToPlayId);

            customer.PlayById(libItemToPlayId);

            Console.WriteLine("Want to play again?? YES or NO");
            string userResponsePlay = Console.ReadLine();

            if (userResponsePlay == "YES")
            {
                goto PlayAnItem;
            }

            Console.WriteLine("Enter ID to return from your list.");
            int libItemToReturnId;
            int.TryParse(Console.ReadLine(), out libItemToReturnId);

            libraryManager.ReturnLibraryItem(customer, libItemToReturnId);
            customer.ViewMyBorrowedLibraryItems();
            // Class for eBook
            // Class for DVD

        }
    }
}
