using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeawallCalculator
{
    class ListFunctions
    {
        public double FindMaxValue(List<double> a_list)
        {
            double max_value = 0;
            foreach(double value in a_list)
            {
                if (value > max_value)
                    max_value = value;
            }
            return max_value;
        }
    }
}
