using System.Reflection;

namespace EverydayLeetCode
{
    #region 解决思路
    /*
     * 
     */
    #endregion

    /// <summary>
    /// 正则表达式匹配
    /// https://leetcode.cn/problems/regular-expression-matching/
    /// </summary>
    internal class Solution_10 : IExcute
    {
        public void Excute()
        {
            string s = "";
            string p = "";
            bool y = IsMatch(s,p);
            Console.WriteLine($"字符串转换整数：{y}");
        }

        public bool IsMatch(string s, string p)
        {
            return true;
        }
    }
}