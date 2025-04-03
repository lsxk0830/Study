using System;

namespace LeetCode
{
    #region 解决思路
    /*
     * 
     */
    #endregion

    /// <summary>
    /// 罗马数字转整数
    /// https://leetcode.cn/problems/roman-to-integer/description/
    /// </summary>
    internal class Solution_13 : IExcute
    {
        public void Excute()
        {
            string s = "DCXXI";
            int y = RomanToInt(s);
            Console.WriteLine($"整数转罗马数字：{y}");
        }

        public int RomanToInt(string s)
        {
            (int Value, string Symbol)[] romanSymbols =
            {
                (1000, "M"),  (900, "CM"), (500, "D"), (400, "CD"),
                (100, "C"),   (90, "XC"),  (50, "L"),  (40, "XL"),
                (10, "X"),    (9, "IX"),   (5, "V"),   (4, "IV"),
                (1, "I")
            };
            int total = 0; int index = 0;

            foreach (var pair in romanSymbols)
            {
                int length = pair.Symbol.Length;

                while(index<s.Length)
                {
                    if (length == 1)
                    {
                        if (s[index] == pair.Symbol[0])
                        {
                            total += pair.Value;
                            index++;
                        }
                        else
                            break;
                    }
                    else if (length == 2 && index + 1 < s.Length)
                    {
                        if (s[index] == pair.Symbol[0] && s[index + 1] == pair.Symbol[1])
                        {
                            total += pair.Value;
                            index += 2;
                        }
                        else
                            break;
                    }
                    else
                        break;
                } 
            }
            return total;
        }
    }
}