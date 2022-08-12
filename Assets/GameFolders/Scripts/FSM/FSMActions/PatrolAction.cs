using ScriptableObjectsAndFSM.Enemy;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace ScriptableObjectsAndFSM.FSM.FSMActions
{
    [CreateAssetMenu(menuName = "FSM/Actions/Patrol")]
    public class PatrolAction : FSMAction
    {
        public override void MainExecute(BaseStateMachine stateMachine)
        {
            var navMeshAgent = stateMachine.GetComponent<NavMeshAgent>();
            var patrolPoints = stateMachine.GetComponent<PatrolPoints>();

            if (patrolPoints.HasReached(navMeshAgent))
            {
                navMeshAgent.ResetPath();
                navMeshAgent.SetDestination(patrolPoints.GetNext().position);
                navMeshAgent.velocity = (Vector3.one * 3);
            }
        }

        public override void OnEnterExecute(BaseStateMachine stateMachine)
        {
            var navMeshAgent = stateMachine.GetComponent<NavMeshAgent>();
            var patrolPoints = stateMachine.GetComponent<PatrolPoints>();
            navMeshAgent.SetDestination(patrolPoints.GetNext().position);
        }

        public override void OnExitExecute(BaseStateMachine stateMachine)
        {
            var navMeshAgent = stateMachine.GetComponent<NavMeshAgent>();
            navMeshAgent.ResetPath();
        }
    }
}
