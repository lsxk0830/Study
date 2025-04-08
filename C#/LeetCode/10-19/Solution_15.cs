namespace LeetCode
{
    #region 解决思路
    /*
     * 
     */
    #endregion

    /// <summary>
    /// 三数之和
    /// https://leetcode.cn/problems/3sum/
    /// </summary>
    internal class Solution_15 : IExcute
    {
        public void Excute()
        {
            int[] nums1 = [-1, 0, 1, 2, -1, -4];
            int[] nums = [-1, 0, 1, 2, -1, -4];
            IList<IList<int>> result = ThreeSum(nums);
            foreach (List<int> list in result) 
            {
                Console.WriteLine($"X:{list[0]},Y:{list[1]},Z:{list[2]}");
            }
        }

        public IList<IList<int>> ThreeSum(int[] nums)
        {
            List<IList<int>> result = new List<IList<int>>();
            Array.Sort(nums); // 关键步骤：排序以去重

            for (int i = 0; i < nums.Length - 2; i++)
            {
                if (i > 0 && nums[i] == nums[i - 1]) continue; // 跳过重复的 i

                int target = -nums[i];
                int left = i + 1;
                int right = nums.Length - 1;

                // 双指针遍历剩余部分
                while (left < right)
                {
                    int sum = nums[left] + nums[right];

                    if (sum == target)
                    {
                        result.Add(new List<int> { nums[i], nums[left], nums[right] });

                        // 跳过重复的 left 和 right
                        while (left < right && nums[left] == nums[left + 1]) left++;
                        while (left < right && nums[right] == nums[right - 1]) right--;

                        left++;
                        right--;
                    }
                    else if (sum < target)
                    {
                        left++;
                    }
                    else
                    {
                        right--;
                    }
                }
            }
            return result;
        }
    }
}