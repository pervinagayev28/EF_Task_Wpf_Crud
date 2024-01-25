using ConsoleApp5.Entities.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5.Entities
{
    public class Teacher:BaseEntityOne
    {
        public int Id_Dep { get; set; }
        public Department Department { get; set; }
        public ICollection<T_Card> T_Cards { get; set; }

    }
}
