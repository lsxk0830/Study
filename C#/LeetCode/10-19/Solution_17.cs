namespace LeetCode
{
    #region 解决思路
    /*
     * 每次处理两轮数字的交叉结果。然后与下一轮进行交叉。
     */
    #endregion

    /// <summary>
    /// 电话号码的字母组合
    /// https://leetcode.cn/problems/letter-combinations-of-a-phone-number/
    /// </summary>
    internal class Solution_17 : IExcute
    {
        public void Excute()
        {
            string digits = "234";
            IList<string> result = LetterCombinations(digits);
            foreach(string digit in result) 
            {
                Console.WriteLine($"电话号码的字母组合：{digit}");
            }
        }

        public IList<string> LetterCombinations(string digits)
        {
            // 边界条件：输入为空时直接返回空列表
            if (string.IsNullOrEmpty(digits)) return new List<string>();

            // 定义数字到字母的映射字典
            var digitToLetters = new Dictionary<char, string> 
            {
                {'2', "abc"}, {'3', "def"},  {'4', "ghi"}, {'5', "jkl"},
                {'6', "mno"}, {'7', "pqrs"}, {'8', "tuv"}, {'9', "wxyz"}
            };

            // 初始化结果列表，包含一个空字符串（用于首次拼接）
            List<string> result = new List<string> { "" };

            // 遍历输入字符串中的每个数字
            foreach (char digit in digits)
            {
                // 获取当前数字对应的字母集合（例如 '2' 对应 "abc"）
                var letters = digitToLetters[digit];

                // 临时列表存储当前轮次生成的新组合
                List<string> temp = new List<string>();

                // 遍历当前结果中的每一个已有组合
                foreach (string s in result)
                {
                    // 遍历当前数字对应的每个字母
                    foreach (char c in letters)
                    {
                        // 将已有组合与当前字母拼接，生成新组合
                        temp.Add(s + c);
                    }
                }
                // 用新生成的组合替换旧结果，进入下一轮迭代
                result = temp;
            }
            return result;
        }
    }
}