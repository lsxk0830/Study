namespace LeetCode
{
    #region 解决思路
    /*
     * 
     */
    #endregion

    /// <summary>
    /// 最接近的三数之和
    /// https://leetcode.cn/problems/3sum-closest/description/
    /// </summary>
    internal class Solution_16 : IExcute
    {
        public void Excute()
        {
            int[] nums = { -1, 2, 1, -4 };
            int target = 1;
            int result = ThreeSumClosest(nums, target);
            Console.WriteLine($"最接近的三数之和：{result}");
        }

        public int ThreeSumClosest(int[] nums, int target)
        {
            return 0;
        }
    }
}