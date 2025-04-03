using SimpleFrame;
using UnityEngine;

namespace Unity3D.Demo
{
    public interface IInitService : IService
    {

    }

    public class InitService : IInitService
    {
        void IService.Init()
        {
            GameObject go = new GameObject("初始化");
            go.AddComponent<GlobalMono>();
        }
    }
}