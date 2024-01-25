using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5.Entities.BaseEntities
{
    public abstract class BaseEntityStudentAndTeacher
    {
        public int Id { get; set; }
        public int Id_Book { get; set; }
        public Book Book { get; set; }
        public DateTime DateOut { get; set; }
        public DateTime DateIn { get; set; }
        public int Id_Lib { get; set; }
        public Lib Lib { get; set; }
    }
}
