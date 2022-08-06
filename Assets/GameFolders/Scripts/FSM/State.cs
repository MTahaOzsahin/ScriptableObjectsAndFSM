using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjectsAndFSM.FSM
{
    [CreateAssetMenu(menuName = "FSM/State")]
    public sealed class State : BaseState
    {
        public List<FSMAction> Action = new List<FSMAction>();
        public List<Transition> Transitions = new List<Transition>();
        [Tooltip("Use only when fixed transition wanted")]
        public List<Transition> FixedTransition = new List<Transition>();

        public override void Execute(BaseStateMachine machine)
        {
            if (machine.IsFixedState)
            {
                foreach (var action in Action) action.Execute(machine);
                foreach (var transition in FixedTransition) transition.Execute(machine);
            }
            else
            {
                foreach (var action in Action) action.Execute(machine);
                foreach (var transition in Transitions) transition.Execute(machine);
            }
        }
    }
}
