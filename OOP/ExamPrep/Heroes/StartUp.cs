﻿using System;
using System.Collections.Generic;
using Heroes.Core;
using Heroes.Core.Contracts;
using Heroes.Models.Contracts;
using Heroes.Models.Heroes;
using Heroes.Models.Map;
using Heroes.Models.Weapons;

namespace Heroes
{
    public class StartUp
    {
        public static void Main()
        {
           IEngine engine = new Engine();
           engine.Run();
        }
    }
}
