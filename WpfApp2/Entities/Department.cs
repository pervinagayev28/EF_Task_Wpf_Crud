using ConsoleApp5.Entities.BaseEntities;
using System.Collections.Generic;

namespace ConsoleApp5.Entities
{
    public class Department:BaseEntityTwo
    {
        public ICollection<Teacher> Teachers{ get; set; }
    }
}