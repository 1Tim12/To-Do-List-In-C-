﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_OOP
{
    public static class SharedData
    {
        public static DataItem SelectedDataItem { get; set; }
        public static List<DataItem> DataItems { get; set; } = new List<DataItem>();
    }
}
