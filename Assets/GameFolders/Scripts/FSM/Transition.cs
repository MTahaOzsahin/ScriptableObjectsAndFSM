using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjectsAndFSM.FSM
{
    [CreateAssetMenu(menuName = "FSM/Transition")]
    public sealed class Transition : ScriptableObject
    {
        public enum DecisionType { OneDecision, TwoDecision };
        public DecisionType decisionType;
        [Tooltip("Use second decision if wanted. If selected one decision, no need to assign second decision."
           + " Also no need to assign SecondState and ThirdState")]
        public Decision FirstDecision;
        public Decision SecondDecision;
        [Tooltip("If first decision is true and second is also true its transition to FirstState")]
        public BaseState FirstState;
        [Tooltip("If first decision is true and second is false its transition to SecondState")]
        public BaseState SecondState;
        [Tooltip("If first decision is false and second is  true its transition to ThirdState")]
        public BaseState ThirdState;
        [Tooltip("If first decision is false and second is also false its transition to FourtState")]
        public BaseState FourtState;
        public static event System.Action OnStateChange;

        


        public void Execute(BaseStateMachine stateMachine)
        {
            switch (decisionType)
            {
                case DecisionType.OneDecision:
                    if (FirstDecision.Decide(stateMachine))
                    {
                        stateMachine.NextState = FirstState;
                        if (stateMachine.CurrentState != stateMachine.NextState)
                        {
                            OnStateChange?.Invoke();
                        }
                    }
                    else if (!FirstDecision.Decide(stateMachine))
                    {
                        stateMachine.NextState = FourtState;
                        if (stateMachine.CurrentState != stateMachine.NextState)
                        {
                            OnStateChange?.Invoke();
                        }
                    }
                    break;
                case DecisionType.TwoDecision:
                    if (FirstDecision.Decide(stateMachine) && SecondDecision.Decide(stateMachine))
                    {
                        stateMachine.NextState = FirstState;
                        if (stateMachine.CurrentState != stateMachine.NextState)
                        {
                            OnStateChange?.Invoke();
                        }
                    }
                    else if (FirstDecision.Decide(stateMachine) && !SecondDecision.Decide(stateMachine))
                    {
                        stateMachine.NextState = SecondState;
                        if (stateMachine.CurrentState != stateMachine.NextState)
                        {
                            OnStateChange?.Invoke();
                        }
                    }
                    else if (!FirstDecision.Decide(stateMachine) && SecondDecision.Decide(stateMachine))
                    {
                        stateMachine.NextState = ThirdState;
                        if (stateMachine.CurrentState != stateMachine.NextState)
                        {
                            OnStateChange?.Invoke();
                        }
                    }
                    else if (!FirstDecision.Decide(stateMachine) && !SecondDecision.Decide(stateMachine))
                    {
                        stateMachine.NextState = FourtState;
                        if (stateMachine.CurrentState != stateMachine.NextState)
                        {
                            OnStateChange?.Invoke();
                        }
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
