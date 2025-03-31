namespace Unity3D.Demo.StateMachine
{
    public interface IState
    {
        void Enter();
        void Update();
        void FixedUpdate();
        void Exit();
    }
}