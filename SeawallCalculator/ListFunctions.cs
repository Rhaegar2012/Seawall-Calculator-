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
            double max_value = 0.0;
            foreach(double value in a_list)
            {

                double check_value = Math.Abs(value);
         
                if (check_value > max_value)
                    
                    max_value = check_value;
               
            }
            return max_value;
        }
    }
}
