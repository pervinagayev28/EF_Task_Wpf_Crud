using ConsoleApp5.Entities.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5.Entities
{
    public class S_Card: BaseEntityStudentAndTeacher
    {
      
        public int Id_Student { get; set; }
        public Student Student { get; set; }
      
    }
}
