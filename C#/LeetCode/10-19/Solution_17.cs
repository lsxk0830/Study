using System.Text;

namespace LeetCode
{
    #region 解决思路
    /*
     * 每次处理两轮数字的交叉结果。然后与下一轮进行交叉。
     * 以“234”为例，先将'2'与‘3’的结果缓存起来，在于‘4’组合
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
            var dic = new Dictionary<char, string> 
            {
                {'2', "abc"}, {'3', "def"},  {'4', "ghi"}, {'5', "jkl"},
                {'6', "mno"}, {'7', "pqrs"}, {'8', "tuv"}, {'9', "wxyz"}
            };
            IList<string> result = new List<string>();
            StringBuilder sb = new StringBuilder(); // 使用StringBuilder减少字符拼接产生的内存
            foreach (char digit in digits)
            { 
                var str = dic[digit];
                //将上一轮的结果与当前数字的字母进行交叉组合。第一次没有结果，所以需要初始化一个空字符串
                IList<string> temp = result.Count == 0 ? new List<string>() { "" } : new List<string>(result);
                result.Clear();
                for (int i = 0; i < str.Length; i++)
                {
                    for (int j = 0; j < temp.Count; j++)
                    {
                        sb.Append(temp[j]);
                        sb.Append(str[i]);
                        result.Add(sb.ToString());
                        sb.Clear();
                    }
                }
            }
            return result;
        }
    }
}