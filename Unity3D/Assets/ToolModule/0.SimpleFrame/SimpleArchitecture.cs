using Unity3D.Demo;

namespace SimpleFrame
{
    public class SimpleArchitecture : AbstractArchitecture<SimpleArchitecture>
    {
        protected override void OnInit()
        {
            this.RegisterService<IInitService>(new InitService());
        }
    }
}