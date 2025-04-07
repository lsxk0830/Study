using System.Text;

namespace LeetCode
{
    #region 解决思路
    /*
     * 以第一个字符串为基准，遍历每个字符，判断是否在其他字符串中都存在
     */
    #endregion

    /// <summary>
    /// 最长公共前缀
    /// https://leetcode.cn/problems/longest-common-prefix/description/
    /// </summary>
    internal class Solution_14 : IExcute
    {
        public void Excute()
        {
            string[] strs = ["abab", "aba", ""];
            string prefix = LongestCommonPrefix(strs);
            Console.WriteLine($"最长公共前缀：{prefix}");
        }

        public string LongestCommonPrefix(string[] strs)
        {
            if (strs == null || strs.Length == 0) return "";
            if (strs.Length == 1) return strs[0];

            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0;i < strs[0].Length; i++)
            {
                int index = 1;
                while(index< strs.Length && strs[index].Length > i)
                {
                    if(strs[0][i] == strs[index][i])
                    {
                        index++;
                    }
                    else
                    {
                        break;
                    }
                }
                if(index == strs.Length)
                    stringBuilder.Append(strs[0][i]);
                else
                    return stringBuilder.ToString();
            }
            return stringBuilder.ToString();
        }
    }
}