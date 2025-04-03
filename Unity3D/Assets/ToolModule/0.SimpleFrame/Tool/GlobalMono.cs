using System;

namespace SimpleFrame
{
    public class GlobalMono : MonoSingleton<GlobalMono>
    {
        public event Action OnFixedUpdate;
        public event Action OnUpdate;
        public event Action OnLateUpdate;

        private void FixedUpdate()
        {
            OnFixedUpdate?.Invoke();
        }
        private void Update()
        {
            OnUpdate?.Invoke();
        }

        private void LateUpdate()
        {
            OnLateUpdate?.Invoke();
        }
    }
}