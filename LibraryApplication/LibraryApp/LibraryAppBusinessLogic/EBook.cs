using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAppBusinessLogic
{
    public class EBook : LibraryItem
    {
        public override void Play()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Playing audio for eBook {this.Name} by {this.Author}");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
