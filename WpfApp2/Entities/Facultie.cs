
using ConsoleApp5.Entities.BaseEntities;
using System.Collections.Generic;

namespace ConsoleApp5.Entities
{
    public class Facultie:BaseEntityTwo
    {
        public ICollection<Group> Groups{ get; set; }
    }
}
