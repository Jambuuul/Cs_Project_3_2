﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_3_2
{
    public class BaseTask
    {
        public static void Run(ref Cities cities)
        {
            Console.Clear();
            
            cities.PrintInfo();
        }
    }
}
