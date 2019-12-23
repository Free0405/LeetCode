using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Algorithm
{
    public class IsPossibleDivide
    {
        public static bool judgeNumber(int[] nums, int k)
        {
            if (nums.Length % k != 0 || nums.Length == 0) return false;
            List<int> intNums = nums.ToList();
            while (intNums.Count != 0)
            {
                int minNumber = intNums.Min();
                for (int i = 0; i < k; i++)
                {
                    int number = minNumber + i;
                    if (!intNums.Remove(number))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
