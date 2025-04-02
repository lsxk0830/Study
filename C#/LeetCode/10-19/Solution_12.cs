using EverydayLeetCode;

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
            int num = 1994;
            string s = IntToRoman(num);
            Console.WriteLine($"整数转罗马数字：{s}");
        }

        public string IntToRoman(int num)
        {
            List<string> list = new List<string>();
            int shi = 0; int zhi = 0;
            while (num > 0)
            {
                int i = num % 10;
                if (shi != 0)
                    zhi = (int)Math.Pow(10, shi) * i;
                else
                    zhi = i;
                if (i == 4 || i == 9)
                {
                    list.Add(Other(zhi));
                }
                else
                {
                    if (i < 5)
                    {
                        string result = "";
                        if (zhi < 10)
                        {
                            result = new string(Change(1), i);
                        }
                        else if (zhi < 100)
                        {
                            result = new string(Change(10), i);
                        }
                        else if (zhi < 1000)
                        {
                            result = new string(Change(100), i);
                        }
                        else if (zhi < 10000)
                        {
                            result = new string(Change(1000), i);
                        }
                        list.Add(result);
                    }
                    else
                    {
                        i -= 5;
                        string result = "";
                        if (zhi < 10)
                        {
                            result = Change(5) + new string(Change(1), i);
                        }
                        else if (zhi < 100)
                        {
                            result += Change(50) + new string(Change(10), i);
                        }
                        else if (zhi < 1000)
                        {
                            result += Change(500) + new string(Change(100), i);
                        }
                        else if (zhi < 10000)
                        {
                            result += Change(5000) + new string(Change(1000), i);
                        }
                        list.Add(result);
                    }
                }
                num /= 10;
                shi++;
            }
            list.Reverse();
            string res = string.Join("", list);
            return res;
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