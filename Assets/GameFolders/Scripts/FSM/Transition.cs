using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjectsAndFSM.FSM
{
    [CreateAssetMenu(menuName = "FSM/Transition")]
    public sealed class Transition : ScriptableObject
    {
        public Decision Decision;
        public BaseState TrueState;
        public BaseState FalseState;
        public static event System.Action OnStateChange;

        public void Execute(BaseStateMachine stateMachine)
        {
            if (Decision.Decide(stateMachine) && !(TrueState is RemainInState))
            {
                stateMachine.NextState = TrueState;
                if (stateMachine.CurrentState != stateMachine.NextState)
                {
                    OnStateChange?.Invoke();
                }
            }
            else if (!Decision.Decide(stateMachine) && !(FalseState is RemainInState))
            {
                stateMachine.NextState = FalseState;
                if (stateMachine.CurrentState != stateMachine.NextState)
                {
                    OnStateChange?.Invoke();
                }
            }
        }
    }
}
