using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAppBusinessLogic
{
    public abstract class LibraryItem
    {
        public int Id{ get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }

        //We don't know how Play method is executed.
        // Play method should be implemented differently in child classes.
        public abstract void Play();
    }
}
