﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishCookLib
{
    public interface IMarket 
    {
        IResource [][] Inventory { get; set;}

        void Refill();

        string ToString();

   }
}
