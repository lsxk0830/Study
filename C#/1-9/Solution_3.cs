using System;

namespace EverydayLeetCode
{
    /// <summary>
    /// 无重复字符的最长子串
    /// https://leetcode.cn/problems/longest-substring-without-repeating-characters/
    /// </summary>
    internal class Solution_3 : IExcute
    {
        public void Excute()
        {
            Console.WriteLine(LengthOfLongestSubstring("tmmzuxt"));
            Console.WriteLine(LengthOfLongestSubstring("abcabcbb"));
            Console.WriteLine(LengthOfLongestSubstring("bbbbb"));
            Console.WriteLine(LengthOfLongestSubstring("pwwkew"));
            Console.WriteLine(LengthOfLongestSubstring("aab"));
            Console.WriteLine(LengthOfLongestSubstring("dvdf"));
        }

        public int LengthOfLongestSubstring2(string s)
        {
            string temp = "";
            int maxCount = 0;
            foreach (char c in s)
            {
                if (temp.Contains(c))
                {
                    int count = temp.IndexOf(c);
                    temp = temp.Substring(count + 1);
                    temp += c;
                }
                else
                {
                    temp += c;
                    maxCount = maxCount < temp.Length ? temp.Length : maxCount;
                }
            }
            return maxCount;
        }

        /// <summary>
        /// 滑动窗口算法（Sliding Window）可以用来解决字符串（数组）的子元素问题，
        /// 查找满足一定条件的连续子区间，可以将嵌套的循环问题，转化为单循环问题，降低时间复杂度。
        //  滑动窗口算法需要用到双指针，遍历字符串（数组）时，两个指针都起始于原点，并一前一后地向终点移动，
        //  两个指针一前一后夹着的子串（子数组）就像一个窗口，窗口的大小和覆盖范围会随着前后指针的移动而发生变化。
        //  窗口该如何移动需要根据求解的问题来决定，通过左右指针的移动遍历字符串（数组），寻找满足特定条件的连续子区间。
        /// </summary>
        public int LengthOfLongestSubstring(string s)
        {
            HashSet<char> letter = new HashSet<char>();// 哈希集合，记录每个字符是否出现过
            int left = 0, right = 0;//初始化左右指针，指向字符串首位字符
            int length = s.Length;
            int count = 0, max = 0;//count记录每次指针移动后的子串长度
            while (right < length)
            {
                if (!letter.Contains(s[right]))//右指针字符未重复
                {
                    letter.Add(s[right]);//将该字符添加进集合
                    right++;//右指针继续右移
                    count++;
                }
                else//右指针字符重复，左指针开始右移，直到不含重复字符（即左指针移动到重复字符(左)的右边一位）
                {
                    letter.Remove(s[left]);//去除集合中当前左指针字符
                    left++;//左指针右移
                    count--;
                }
                max = Math.Max(max, count);
            }
            return max;
        }
    }
}