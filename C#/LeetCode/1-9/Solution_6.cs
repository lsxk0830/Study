using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    #region 解决思路
    /*
     * 每numRows一列为一组，少于numRows的特殊处理
     * P   A   H   N
     * A P L S I I G
     * Y   I   R
     * PAY一组，AILI一组，YIR一组
     * P、S等特殊处理。while循环处理
     */
    #endregion

    /// <summary>
    /// Z 字形变换
    /// https://leetcode.cn/problems/zigzag-conversion/description/
    /// </summary>
    internal class Solution_6 : IExcute
    {
        public void Excute()
        {
            string s = "PAYPALISHIRING";
            int numRows = 3;
            string str = Convert(s, numRows);
            Console.WriteLine($"Z 字形变换：{str}");
        }

        public string Convert(string s, int numRows)
        {
            if (numRows == 1 || numRows >= s.Length) return s;

            StringBuilder[] lists = new StringBuilder[numRows]; // 使用StringBuilder数组代替List<List<char>>
            for (int i = 0; i < numRows; i++)
                lists[i] = new StringBuilder();

            int flag = 0;
            for (int i = 0; i < s.Length; i++)
            {
                lists[flag].Append(s[i]);
                flag++;
                if (flag % numRows == 0)
                {
                    flag = numRows - 2;

                    while (flag > 0)
                    {
                        i++;
                        if (i >= s.Length)
                            break;
                        lists[flag].Append(s[i]);
                        flag--;
                    }
                }
            }

            for (int i = 1; i < numRows; i++)
                lists[0].Append(lists[i]);
            return lists[0].ToString();
        }
    }
}