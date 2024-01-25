using ConsoleApp5.Entities.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5.Entities
{
    public class Author:BaseEntityOne
    {
        public ICollection<Book> Books { get; set; }
    }
}
