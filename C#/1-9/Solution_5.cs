namespace EverydayLeetCode
{
    #region 解决思路
    /*
     * 找到一个中心，从这个中心向两边扩展的话，两边对应的值是相等的。如果是值一样的，则记录下来，进行特殊处理
     */
    #endregion
    /// <summary>
    /// 最长回文子串
    /// https://leetcode.cn/problems/longest-palindromic-substring/description/
    /// </summary>
    internal class Solution_5 : IExcute
    {
        public void Excute()
        {
            string s = "a";
            string str = LongestPalindrome(s);
            Console.WriteLine($"最长回文子串：{str}");
        }

        public string LongestPalindrome(string s)
        {
            int max = 0;// 回文字符串最大长度
            int Leftflag = 0, rightFlag = 1; // 记录下标志位
            for (int i = 0; i < s.Length; i++)
            {
                int left = i - 1, right = i + 1; bool repeat = false;
                while (left >= 0 || right < s.Length)
                {
                    if (left >= 0 && right < s.Length && s[left] == s[right])
                    {
                        int count = right - left + 1; // 计算回文字符串长度
                        if (count > max)
                        {
                            Leftflag = left;
                            rightFlag = right - left + 1;
                            max = count;
                        }
                        if (s[left] != s[i]) // 字符全部一致时特殊情况
                            repeat = true;

                        left--; right++;
                    }
                    else if (left >= 0 && s[left] == s[i] && !repeat)// 字符全部一致的特殊处理
                    {
                        int count = right - left; // 计算回文字符串长度
                        if (count > max)
                        {
                            Leftflag = left;
                            rightFlag = right - left;
                            max = count;
                        }
                        left--;
                    }
                    else if (right < s.Length && s[right] == s[i] && !repeat)// 字符全部一致的特殊处理
                    {
                        int count = right - left; // 计算回文字符串长度
                        if (count > max)
                        {
                            Leftflag = left + 1;
                            rightFlag = right - left;
                            max = count;
                        }
                        right++;
                    }
                    else
                        break;
                }
            }
            return s.Substring(Leftflag, rightFlag);
        }
    }
}