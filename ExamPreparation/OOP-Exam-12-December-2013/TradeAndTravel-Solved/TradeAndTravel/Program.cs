﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeAndTravel
{
    class Program
    {
        // 100 Points

        static void Main(string[] args)
        {
            var engine = new Engine(new AdvancedInteractionManager());
            engine.Start();
        }
    }
}
