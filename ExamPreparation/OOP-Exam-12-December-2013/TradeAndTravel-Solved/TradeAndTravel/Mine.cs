﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TradeAndTravel
{
    public class Mine : Location
    {
         public Mine(string name)
            : base(name, LocationType.Mine)
        {
        }
    }
}
