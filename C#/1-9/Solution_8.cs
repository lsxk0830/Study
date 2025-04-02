namespace EverydayLeetCode
{
    #region 解决思路
    /*
     * 先判断空格，再判断正负号，最后判断数字
     * 优化后：
     * 去除了StringBuilder 操作，取消TryParse操作，去除了临时字符串
     */
    #endregion

    /// <summary>
    /// 字符串转换整数 (atoi)
    /// https://leetcode.cn/problems/string-to-integer-atoi/description/
    /// </summary>
    internal class Solution_8 : IExcute
    {
        public void Excute()
        {
            string s = "    +11191657170";
            int y = MyAtoi(s);
            Console.WriteLine($"字符串转换整数：{y}");
        }

        public int MyAtoi(string s)
        {
            int index = 0, sign = 1, result = 0;

            while (index < s.Length && s[index] == ' ') //跳过前导空格
                index++;

            if (index < s.Length && (s[index] == '+' || s[index] == '-')) //判断正负号
            {
                sign = s[index] == '+' ? 1 : -1;
                index++;
            }

            while (index < s.Length && char.IsDigit(s[index]))
            {
                int digit = s[index] - '0'; //通过字符的 ASCII 码值计算得到数字字符所代表的实际数值
                if (digit < 0 || digit > 9)
                    break;
                if (result > int.MaxValue / 10 || (result == int.MaxValue / 10 && digit > int.MaxValue % 10)) //在将新数字添加到结果之前，确保结果不会超出 int 的范围
                    return sign == 1 ? int.MaxValue : int.MinValue;
                result = result * 10 + digit;
                index++;
            }

            return result * sign;
        }
    }
}