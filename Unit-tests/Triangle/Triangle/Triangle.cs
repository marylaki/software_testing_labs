using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triangle
{
    class Triangle
    {
        public bool isTriangle(Double a, Double b, Double c)
        {
            if (Math.Max(Math.Max(a, b), c) < a + b + c - Math.Max(Math.Max(a, b), c))
            {
                return true;
            }
            return false;
        }
    }
}
