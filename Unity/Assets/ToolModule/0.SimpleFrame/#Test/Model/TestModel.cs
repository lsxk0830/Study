namespace SimpleFrameTest
{
    public class TestModel : ITestModel
    {
        private float id;

        public void Init() // 用于数据初始化，不建议在Init中获取层级数据
        {
            id = 100000;
            // this.GetModel<TestModelPlanB>();
        }

        string ITestModel.GetID(string idStr)
        {
            float mTestID = float.Parse(idStr);

            mTestID += id;

            return mTestID.ToString();
        }
    }
}