namespace LeetCode
{
    #region 解决思路
    /*
     * 转化成字符串处理
     */
    #endregion

    /// <summary>
    /// 整数反转
    /// https://leetcode.cn/problems/reverse-integer/description/
    /// </summary>
    internal class Solution_7 : IExcute
    {
        public void Excute()
        {
            int x = 321;
            int y = Reverse(x);
            Console.WriteLine($"整数反转：{y}");
        }

        public int Reverse(int x)
        {
            int reversed = 0;
            while (x != 0)
            {
                int digit = x % 10; // 取最后一位
                x /= 10; // 去掉最后一位

                // 检查溢出
                if (reversed > int.MaxValue / 10 || (reversed == int.MaxValue / 10 && digit > 7))
                    return 0; // 正数溢出
                if (reversed < int.MinValue / 10 || (reversed == int.MinValue / 10 && digit < -8))
                    return 0; // 负数溢出

                reversed = reversed * 10 + digit; // 翻转 1、12、123
            }
            return reversed;
        }
    }
}