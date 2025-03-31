using System;

namespace Tool
{
    public class CustomState : IState
    {
        private Action onEnter;
        private Action onUpdate;
        private Action onFixedUpdate;
        private Action onExit;

        public CustomState OnEnter(Action onEnter)
        {
            this.onEnter = onEnter;
            return this;
        }

        public CustomState OnUpdate(Action onUpdate)
        {
            this.onUpdate = onUpdate;
            return this;
        }

        public CustomState OnFixedUpdate(Action onFixedUpdate)
        {
            this.onFixedUpdate = onFixedUpdate;
            return this;
        }

        public CustomState OnExit(Action onExit)
        {
            this.onExit = onExit;
            return this;
        }

        public void Enter()
        {
            onEnter?.Invoke();
        }

        public void Update()
        {
            onUpdate?.Invoke();
        }

        public void FixedUpdate()
        {
            onFixedUpdate?.Invoke();
        }

        public void Exit()
        {
            onExit?.Invoke();
        }
    }
}