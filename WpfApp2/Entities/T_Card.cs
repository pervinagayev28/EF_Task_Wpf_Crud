using ConsoleApp5.Entities.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5.Entities
{
    public class T_Card:BaseEntityStudentAndTeacher
    {
        public int Id_Teacher { get; set; }
        public Teacher Teacher { get; set; }
  
    }
}
