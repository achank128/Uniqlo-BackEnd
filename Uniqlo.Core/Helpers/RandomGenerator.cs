using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uniqlo.Core.Helpers
{
    public static class RandomGenerator
    {
        public static int GenerateInteger(int min, int max)
        {
            return new Random().Next(min, max);
        }
    }
}
