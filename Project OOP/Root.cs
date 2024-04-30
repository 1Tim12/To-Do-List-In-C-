using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_OOP
{
    public class Root : DataItem
    {
        public ExistingData existingData { get; set; }
        public DataItem NewData { get; set; }
    }
}
