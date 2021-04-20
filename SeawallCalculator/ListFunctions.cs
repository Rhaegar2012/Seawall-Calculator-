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
                Console.WriteLine("Max Value");
                Console.WriteLine(value.ToString() + " " + max_value.ToString());
                if (Math.Abs(value) > max_value)
                    Console.WriteLine("Accesed");
                    max_value = value;
                Console.WriteLine(max_value.ToString());
            }
            return Math.Abs(max_value);
        }
    }
}
