namespace LeetCode
{
    /// <summary>
    /// 1. 两数之和
    /// https://leetcode.cn/problems/two-sum/
    /// </summary>
    class Solution_1 : IExcute
    {
        public void Excute()
        {
            int[] nums = { -1, -2, -3, -4, -5 };
            int target = -8;
            int[] result = TwoSum(nums, target);
            Console.WriteLine($"值1：{result[0]},值2：{result[1]}");
        }

        public int[] TwoSum(int[] nums, int target)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                int y = target - nums[i];
                nums[i] = int.MinValue; // 使用一个不可能的值代替 null

                if (nums.Contains(y))
                {
                    int[] result = { i, Array.IndexOf(nums, y) };
                    return result;
                }
            }
            return null;
        }

        /// <summary>
        /// 优化
        /// 解题思路：使用字典存储已经遍历过的值，key:值 value:索引
        /// 当我们需要查询一个元素是否出现过，或者一个元素是否在集合里的时候，就要第一时间想到哈希法
        /// </summary>
        public int[] TwoSum2(int[] nums, int target)
        {
            Dictionary<int, int> dic = new Dictionary<int, int>();// key:值 value:索引
            for (int i = 0; i < nums.Length; i++)
            {
                int value = target - nums[i];
                if (dic.ContainsKey(value) && dic[value] != i)
                {
                    return new int[] { i, dic[value] };
                }
                if (!dic.ContainsKey(nums[i]))
                {
                    dic.Add(nums[i], i);
                }
            }
            return new int[] { 0, 0 };
        }
    }
}
