using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_OOP
{
    public class DataItem
    {
        public DateTime Date { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return $"Date: {Date}, Name: {Name}";
        }
    }
}
