using System.Reflection;

namespace EverydayLeetCode
{
    #region 解决思路
    /*
     * 先判断整数，不为负数且不为10的倍数
     * 取左右标志位，进行移动判断是否相等
     * 
     * 优化：
     * 
     * 通过 ​反转一半数字来降低时间和空间复杂度，无需将整数转换为字符串
     */
    #endregion

    /// <summary>
    /// 回文数
    /// https://leetcode.cn/problems/palindrome-number/description/
    /// </summary>
    internal class Solution_9 : IExcute
    {
        public void Excute()
        {
            int x = 1231321;
            bool y = IsPalindrome(x);
            Console.WriteLine($"字符串转换整数：{y}");
        }

        public bool IsPalindrome(int x)
        {
            if (x < 0 || (x % 10 == 0 && x != 0)) return false;

            #region 旧方法
            //string str = x.ToString();
            //int left , right;

            //if ((str.Length %2) ==1)
            //{
            //    left = str.Length / 2 - 1;
            //    right = str.Length / 2 + 1;
            //}
            //else
            //{
            //    right = str.Length / 2;
            //    left = right - 1;
            //}

            //while (left >= 0 && right < str.Length)
            //{
            //    if (str[left] != str[right])
            //    {
            //        return false;
            //    }
            //    left--;
            //    right++;
            //}

            //return true;
            #endregion

            int revertedNumber = 0;
            // 只反转后半部分数字
            while (x > revertedNumber)
            {
                revertedNumber = revertedNumber * 10 + x % 10; //  x % 10 取出最低位数字.1、10、100、1000
                x /= 10;
            }

            // 数字长度为偶数：x == revertedNumber
            // 数字长度为奇数：x == revertedNumber / 10
            return x == revertedNumber || x == revertedNumber / 10;
        }
    }
}