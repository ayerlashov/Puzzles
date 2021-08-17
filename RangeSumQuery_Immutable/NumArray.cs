namespace RangeSumQuery_Immutable
{
    public class NumArray
    {
        private int[] Sums { get; set; }

        public NumArray(int[] nums)
        {
            Sums = new int[nums.Length];

            for (int i = 0, s = 0; i < nums.Length; i++)
                Sums[i] = (s += nums[i]);
        }

        public int SumRange(int left, int right) => 
            left == 0 
            ? Sums[right] 
            : Sums[right] - Sums[left - 1];
    }
}
