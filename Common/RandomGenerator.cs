using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Logger.Services.Common
{
    public class RandomGenerator
    {                
        public static int RandomNumber()
        {
            Random _random = new Random();
            return _random.Next(1, 2000);
        }
    }
}
