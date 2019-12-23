using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = new int[] { 1, 2, 3, 3, 4, 4, 5, 6 };
            Algorithm.IsPossibleDivide.judgeNumber(nums, 4);
        }
    }
}
