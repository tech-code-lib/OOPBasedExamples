using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAppBusinessLogic
{
    public class LibraryManager
    {
        private EBook[] allEBooks = new EBook[7] { 
            new EBook{Id=1, Name="C# Basics", Author="John", Description="Learn C# for Beginers"},
            new EBook{Id=2,  Name="ASP.Net Basics", Author="Mark", Description="Learn ASP.Net Core"},
            new EBook{Id=3,  Name="ASP.Net Advanced", Author="Mike", Description="Learn ASP.Net Advanced"},
            new EBook{Id=4,  Name="SQL Server Basics", Author="John", Description="Learn SQL Server Basics"},
            new EBook{Id=5,  Name="Python Basics", Author="Mark", Description="Learn basics of Python"},
            new EBook{Id=6,  Name="React Js Advanced", Author="Mike", Description="Learn React js"},
            new EBook{Id=7,  Name="Angular", Author="Lewis", Description="Learn Angular from scratch"}            
        };

        private DVD[] allDVDs = new DVD[7] {
            new DVD{Id=8,  Name="DVD - C# Basics", Author="John", Description="Learn C# for Beginers"},
            new DVD{Id=9,  Name="DVD - ASP.Net Basics", Author="Mark", Description="Learn ASP.Net Core"},
            new DVD{Id=10,  Name="DVD - ASP.Net Advanced", Author="Mike", Description="Learn ASP.Net Advanced"},
            new DVD{Id=11,  Name="DVD - SQL Server Basics", Author="John", Description="Learn SQL Server Basics"},
            new DVD{Id=12,  Name="DVD - Python Basics", Author="Mark", Description="Learn basics of Python"},
            new DVD{Id=13,  Name="DVD - React Js Advanced", Author="Mike", Description="Learn React js"},
            new DVD{Id=14,  Name="DVD - Angular", Author="Lewis", Description="Learn Angular from scratch"}
        };

        public void IssueLibraryItemToCustomer(Customer customer, LibraryItem libraryItem)
        {
            bool issued = false;
            for (int i = 0; i < customer.BorrowedLibraryItems.Length; i++)
            {
                LibraryItem item = customer.BorrowedLibraryItems[i];
                if(item == null)
                {
                    customer.BorrowedLibraryItems[i] = libraryItem;
                    Console.WriteLine($"Issueing LibraryItem {libraryItem.Name} to {customer.Name}");
                    issued = true;
                    break;
                }
            }

            if (!issued)
            {
                Console.WriteLine($"Customer has alreday 5 items issued to him.");
            }
        }

        public LibraryItem GetLibraryItem(int id)
        {
            LibraryItem libraryItem = null;
            bool found = false;
            for (int i = 0; i < allEBooks.Length; i++)
            {
                if (allEBooks[i].Id == id)
                {
                    libraryItem = allEBooks[i];
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                for (int i = 0; i < allDVDs.Length; i++)
                {
                    if (allDVDs[i].Id == id)
                    {
                        libraryItem = allDVDs[i];
                        break;
                    }
                }
            }
            return libraryItem;
        }

        public void ReturnLibraryItem(Customer customer, int id)
        {
            bool issued = false;
            for (int i = 0; i < customer.BorrowedLibraryItems.Length; i++)
            {
                LibraryItem item = customer.BorrowedLibraryItems[i];
                if (item != null && item.Id == id)
                {
                    string libItemName = item.Name;
                    customer.BorrowedLibraryItems[i] = null;
                    Console.WriteLine($"Customer {customer.Name} returned LibraryItem {libItemName} on {DateTime.Now.ToString("MMM/dd/yyyy")}");
                    issued = true;
                    break;
                }
            }

            if (!issued)
            {
                Console.WriteLine($"Cound not find the item to return, try again.");
            }
        }


        public EBook[] ListAllAvialbleEBooks()
        {
            Console.WriteLine("All available eBooks.");
            foreach (LibraryItem  item in allEBooks)
            {
                Console.WriteLine($"Book - Id:{item.Id}, Name: {item.Name} by {item.Author}");
            }
            return allEBooks;
        }

        public EBook[] ListAllAvialbleDVDs()
        {
            Console.WriteLine("All available DVDs.");
            foreach (LibraryItem item in allDVDs)
            {
                Console.WriteLine($"DVD - Id:{item.Id}, Name: {item.Name} by {item.Author}");
            }
            return allEBooks;
        }
    }
}
