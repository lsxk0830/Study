using UnityEngine;

namespace Unity3D.Demo.StateMachine
{
    public class Test_FSMExample : MonoBehaviour
    {
        private FSM<Test_States> fsm;

        private void Start()
        {
            fsm = new FSM<Test_States>();

            fsm.State(Test_States.A)
            .OnEnter(() => { Debug.Log($"进入A"); })
            .OnUpdate(() => { Debug.Log($"Update:A"); })
            .OnFixedUpdate(() => { Debug.Log($"FixedUpdate:A"); })
            .OnExit(() => { Debug.Log($"离开A"); });

            fsm.State(Test_States.B)
           .OnExit(() => { Debug.Log($"离开B"); })
           .OnFixedUpdate(() => { Debug.Log($"FixedUpdate:B"); })
           .OnUpdate(() => { Debug.Log($"Update:B"); })
           .OnEnter(() => { Debug.Log($"进入B"); });


            fsm.State(Test_States.C)
           .OnEnter(() => { Debug.Log($"进入C"); })
           .OnFixedUpdate(() => { Debug.Log($"FixedUpdate:C"); })
           .OnUpdate(() => { Debug.Log($"Update:C"); })
           .OnExit(() => { Debug.Log($"离开C"); });

            fsm.StartState(Test_States.B);
        }

        private void Update()
        {
            fsm.Update();

            if (Input.GetKeyDown(KeyCode.A))
                fsm.ChangeState(Test_States.A);
            else if (Input.GetKeyDown(KeyCode.B))
                fsm.ChangeState(Test_States.B);
            else if (Input.GetKeyDown(KeyCode.C))
                fsm.ChangeState(Test_States.C);
        }

        private void FixedUpdate()
        {
            fsm.FixedUpdate();
        }

        private void OnDestroy()
        {
            fsm.Clear();
        }
    }
}