using ConsoleApp5.Entities.BaseEntities;
using System.Collections.Generic;

namespace ConsoleApp5.Entities
{
    public class Group:BaseEntityTwo
    {
        public int Id_Facultie { get; set; }
        public Facultie Facultie{ get; set; }
        public ICollection<Student> Students { get; set; }

    }
}