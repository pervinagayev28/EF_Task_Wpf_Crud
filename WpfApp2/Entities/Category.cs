using ConsoleApp5.Entities.BaseEntities;
using System.Collections.Generic;

namespace ConsoleApp5.Entities
{
    public class Category:BaseEntityTwo
    {
        public ICollection<Book> Books { get; set; }
    }
}