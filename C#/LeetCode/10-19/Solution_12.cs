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
            int num = 10;
            string s = IntToRoman(num);
            Console.WriteLine($"整数转罗马数字：{s}");
        }

        public string IntToRoman(int num)
        {
            StringBuilder stringBuilder = new StringBuilder();
            // 四类情况
            while (num > 0)
            {
                if (num >= 1000)
                {
                    num -= General(num,1000, stringBuilder);
                }
                else if (num >= 100)
                {
                    num -= General(num, 100, stringBuilder);
                }
                else if (num >= 10)
                {
                    num -= General(num, 10, stringBuilder);
                }
                else
                {
                    num -= General(num, 1, stringBuilder);
                }
            }
            return stringBuilder.ToString();
        }

        private int General(int num,int s, StringBuilder stringBuilder)
        {
            int i = num / s;
            if (i == 4 || i == 9)
                stringBuilder.Append(Other(i * s));
            else if (i < 5)
            {
                stringBuilder.Append(new string(Change(s), i));
            }
            else if (i == 5)
            {
                stringBuilder.Append(Change(5*s));
            }
            else
            {
                stringBuilder.Append(Change(5*s));
                stringBuilder.Append(new string(Change(s), i - 5));
            }
            return i * s;
        }

        private char Change(int s)
        {
            char c;
            switch (s)
            {
                case 1:
                    c = 'I';
                    break;
                case 5:
                    c = 'V';
                    break;
                case 10:
                    c = 'X';
                    break;
                case 50:
                    c = 'L';
                    break;
                case 100:
                    c = 'C';
                    break;
                case 500:
                    c = 'D';
                    break;
                case 1000:
                    c = 'M';
                    break;
                default:
                    c = 'I';
                    break;
            }
            return c;
        }

        private string Other(int s)
        {
            string str;
            switch (s)
            {
                case 4:
                    str = "IV";
                    break;
                case 40:
                    str = "XL";
                    break;
                case 400:
                    str = "CD";
                    break;
                case 4000:
                    str = "MMMM";
                    break;
                case 9:
                    str = "IX";
                    break;
                case 90:
                    str = "XC";
                    break;
                case 900:
                    str = "CM";
                    break;
                case 9000:
                    str = "MMMMMMMMM";
                    break;
                default:
                    str = "";
                    break;
            }
            return str;
        }
    }
}