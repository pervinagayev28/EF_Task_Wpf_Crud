using ConsoleApp5.Entities.BaseEntities;
using System.Collections.Generic;

namespace ConsoleApp5.Entities
{
    public class Lib:BaseEntityOne
    {
        public ICollection<T_Card> T_Cards { get; set; }
        public ICollection<S_Card> S_Cards { get; set; }
    }
}