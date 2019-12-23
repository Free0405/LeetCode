using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Algorithm
{
    public class Palindrome
    {
        public static string LongestPalindrome(string s)
        {
            int length = s.Length;
            if (length < 2) return s;
            int longestPalindromeLength = 1;
            string longestPalindromeString = s.Substring(0, 1);
            bool[][] flag = new bool[length][];
            for (int i = 0; i < length; i++)
            {
                flag[i] = new bool[length];
            }
            for (int r = 1; r < length; r++)
                for (int l = 0; l < r; l++)
                {
                    if (s[l] == s[r] && ((r - l) <= 2 || flag[l + 1][r - 1]))
                    {
                        flag[l][r] = true;
                        if (r - l + 1 >= longestPalindromeLength)
                        {
                            longestPalindromeLength = r - l + 1;
                            longestPalindromeString = s.Substring(l, longestPalindromeLength);
                        }
                    }
                }
            return longestPalindromeString;
        }
        public static string LongestPalindrome2(string s)
        {
            int len = s.Length;
            if (len < 2)
            {
                return s;
            }

            int maxLen = 1;
            string res = s.Substring(0, 1);

            // 枚举所有长度大于等于 2 的子串
            for (int i = 0; i < len - 1; i++)
            {
                for (int j = i + 1; j < len; j++)
                {
                    if (j - i + 1 > maxLen && valid(s, i, j))
                    {
                        maxLen = j - i + 1;
                        res = s.Substring(i, j + 1);
                    }
                }
            }
            return res;

        }

        private static bool valid(String s, int left, int right)
        {
            // 验证子串 s[left, right] 是否为回文串
            while (left < right)
            {
                if (s[left] != s[right])
                {
                    return false;
                }
                left++;
                right--;
            }
            return true;
        }
}
}
