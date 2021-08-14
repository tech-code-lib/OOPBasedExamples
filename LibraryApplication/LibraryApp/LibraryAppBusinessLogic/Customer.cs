using System;

namespace LibraryAppBusinessLogic
{
    public class Customer
    {
        public Customer()
        {
            BorrowedLibraryItems = new LibraryItem[5];
        }

        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public LibraryItem[] BorrowedLibraryItems { get; set; }

        public void ViewMyBorrowedLibraryItems()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("List of books/DVDs issued to Customer\n");
            System.Threading.Thread.Sleep(1000);

            if (this.BorrowedLibraryItems != null && this.BorrowedLibraryItems.Length > 0)
            {
                foreach (LibraryItem libItem in this.BorrowedLibraryItems)
                {
                    if(libItem != null)
                    {
                        Console.WriteLine($"{libItem.Name} by {libItem.Author}");
                        Console.WriteLine($"  -- {libItem.Description}");
                    }
                    
                }
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void PlayById(int id)
        {            
            foreach (LibraryItem item in BorrowedLibraryItems)
            {
                if (item != null && item.Id == id)
                {
                    item.Play();
                    return;
                }
            }
        }
    }
}
