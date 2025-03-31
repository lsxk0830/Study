using System.Collections.Generic;

namespace Unity3D.Demo.StateMachine
{
    public class FSM<T>
    {
        public Dictionary<T, IState> stateDic = new Dictionary<T, IState>();
        private IState currentState;
        public IState CurrentState => currentState;
        private T currentStateId;
        public T CurrentStateId => currentStateId;

        public CustomState State(T t)
        {
            if (stateDic.ContainsKey(t))
            {
                return (CustomState)stateDic[t];
            }
            var state = new CustomState();
            stateDic.Add(t, state);
            return state;
        }

        public void ChangeState(T t)
        {
            if (stateDic.ContainsKey(t))
            {
                currentState.Exit();
                currentState = stateDic[t];
                currentStateId = t;
            }
        }

        public void StartState(T t)
        {
            if (stateDic.TryGetValue(t, out var state))
            {
                currentState = state;
                currentStateId = t;
                state.Enter();
            }
        }
        public void FixedUpdate()
        {
            currentState?.FixedUpdate();
        }
        public void Update()
        {
            currentState?.Update();
        }

        public void Clear()
        {
            currentState = null;
            currentStateId = default;
            stateDic.Clear();
        }
    }
}