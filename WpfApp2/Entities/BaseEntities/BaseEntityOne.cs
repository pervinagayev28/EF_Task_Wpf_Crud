using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5.Entities.BaseEntities
{
    public abstract class BaseEntityOne
    {
        public int Id { get; set; }
        public string FirstName{ get; set; }
        public string LastName { get; set; }
    }
}
