using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Algorithm.Algorithm
{
    public class ConvertZ
    {
        public static string Convert(string s, int numRows)
        {
            if (numRows == 1) return s;
            List<StringBuilder> resultString = new List<StringBuilder>();
            for (int i = 0; i < Math.Min(numRows, s.Length); i++)
                resultString.Add(new StringBuilder());

            int curRow = 0;
            bool goingDown = false;

            foreach (char c in s.ToCharArray())
            {
                resultString[curRow].Append(c);
                if (curRow == 0 || curRow == numRows - 1) goingDown = !goingDown;
                curRow += goingDown ? 1 : -1;
            }

            StringBuilder result = new StringBuilder();
            foreach (StringBuilder row in resultString) result.Append(row);
            return result.ToString();
        }
    }
}