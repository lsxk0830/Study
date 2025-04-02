using EverydayLeetCode;
using System;
using System.Text;

namespace LeetCode
{
    #region 解决思路
    /*
     * i == 4 || i == 9 特殊处理
     */
    #endregion

    /// <summary>
    /// 整数转罗马数字
    /// https://leetcode.cn/problems/integer-to-roman/description/
    /// </summary>
    internal class Solution_12 : IExcute
    {
        public void Excute()
        {
            int num = 3749;
            string s = IntToRoman(num);
            Console.WriteLine($"整数转罗马数字：{s}");
        }

        public string IntToRoman(int num)
        {
            (int Value, string Symbol)[] _romanSymbols =
            {
                (1000, "M"),  (900, "CM"), (500, "D"), (400, "CD"),
                (100, "C"),   (90, "XC"),  (50, "L"),  (40, "XL"),
                (10, "X"),    (9, "IX"),   (5, "V"),   (4, "IV"),
                (1, "I")
            };
            StringBuilder sb = new StringBuilder();
            foreach (var pair in _romanSymbols)
            {
                while (num >= pair.Value)
                {
                    sb.Append(pair.Symbol);
                    num -= pair.Value;
                }
            }
            return sb.ToString();
        }
    }
}