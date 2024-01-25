using ConsoleApp5.Entities.BaseEntities;
using System.Collections.Generic;

namespace ConsoleApp5.Entities
{
    public class Student:BaseEntityOne
    {
        public int Id_Group { get; set; }
        public Group Group { get; set; }

        public int Term{ get; set; }
        public ICollection<S_Card> S_Cards { get; set; }

    }
}