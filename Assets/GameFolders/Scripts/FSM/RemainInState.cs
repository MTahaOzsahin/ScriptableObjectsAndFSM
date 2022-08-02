using ScriptableObjectsAndFSM.Enemy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace ScriptableObjectsAndFSM.FSM
{
    [CreateAssetMenu(menuName ="FSM/Remain In State",fileName ="RemainInState")]
    public sealed class RemainInState : BaseState
    {
        public override void Execute(BaseStateMachine stateMachine)
        {
            //var navMeshAgent = stateMachine.GetComponent<NavMeshAgent>();
            //var patrolPoints = stateMachine.GetComponent<PatrolPoints>();

            //if (patrolPoints.HasReached(navMeshAgent))
            //    navMeshAgent.SetDestination(patrolPoints.GetNext().position);
        }
    }
}
