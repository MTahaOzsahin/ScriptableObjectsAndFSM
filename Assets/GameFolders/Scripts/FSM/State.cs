using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjectsAndFSM.FSM
{
    [CreateAssetMenu(menuName = "FSM/State")]
    public sealed class State : BaseState
    {
        public List<FSMAction> CommonActions = new List<FSMAction>();
        public List<Transition> CommonTransitions = new List<Transition>();
        public List<Transition> GuardTransitions = new List<Transition>();
        public List<Transition> PatrolTransitions = new List<Transition>();

        public override void Execute(BaseStateMachine machine)
        {
            switch (machine.enemyType)
            {
                case BaseStateMachine.EnemyType.Guard:
                    foreach (var action in CommonActions) action.Execute(machine);
                    foreach (var transition in GuardTransitions) transition.Execute(machine);
                    break;
                case BaseStateMachine.EnemyType.Patrol:
                    foreach (var action in CommonActions) action.Execute(machine);
                    foreach (var transition in PatrolTransitions) transition.Execute(machine);
                    break;
                case BaseStateMachine.EnemyType.Common:
                    foreach (var action in CommonActions) action.Execute(machine);
                    foreach (var transition in CommonTransitions) transition.Execute(machine);
                    break;
                default:
                    break;
            }
        }
    }
}
