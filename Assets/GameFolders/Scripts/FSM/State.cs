using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjectsAndFSM.FSM
{
    [CreateAssetMenu(menuName = "FSM/State")]
    public sealed class State : BaseState
    {
        public List<FSMAction> Actions = new List<FSMAction>();
        public List<Transition> CommonTransitions = new List<Transition>();
        public List<Transition> GuardTransitions = new List<Transition>();
        public List<Transition> PatrolTransitions = new List<Transition>();
        public override void OnEnterExecute(BaseStateMachine machine)
        {
            switch (machine.enemyType)
            {
                case BaseStateMachine.EnemyType.Guard:
                    foreach (var action in Actions) action.OnEnterExecute(machine);
                    break;
                case BaseStateMachine.EnemyType.Patrol:
                    foreach (var action in Actions) action.OnEnterExecute(machine);
                    break;
                case BaseStateMachine.EnemyType.Common:
                    foreach (var action in Actions) action.OnEnterExecute(machine);
                    break;
                default:
                    break;
            }
        }
        public override void MainExecute(BaseStateMachine machine)
        {
            switch (machine.enemyType)
            {
                case BaseStateMachine.EnemyType.Guard:
                    foreach (var action in Actions) action.MainExecute(machine);
                    foreach (var transition in GuardTransitions) transition.Execute(machine);
                    break;
                case BaseStateMachine.EnemyType.Patrol:
                    foreach (var action in Actions) action.MainExecute(machine);
                    foreach (var transition in PatrolTransitions) transition.Execute(machine);
                    break;
                case BaseStateMachine.EnemyType.Common:
                    foreach (var action in Actions) action.MainExecute(machine);
                    foreach (var transition in CommonTransitions) transition.Execute(machine);
                    break;
                default:
                    break;
            }
        }
        public override void OnExitExecute(BaseStateMachine machine)
        {
            switch (machine.enemyType)
            {
                case BaseStateMachine.EnemyType.Guard:
                    foreach (var action in Actions) action.OnExitExecute(machine);
                    break;
                case BaseStateMachine.EnemyType.Patrol:
                    foreach (var action in Actions) action.OnExitExecute(machine);
                    break;
                case BaseStateMachine.EnemyType.Common:
                    foreach (var action in Actions) action.OnExitExecute(machine);
                    break;
                default:
                    break;
            }
        }
    }
}
