using ScriptableObjectsAndFSM.Enemy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace ScriptableObjectsAndFSM.FSM.FSMActions
{
    [CreateAssetMenu(menuName = "FSM/Actions/Patrol")]
    public class PatrolAction : FSMAction
    {
        NavMeshAgent navMeshAgent;
        PatrolPoints patrolPoints;
        public override void MainExecute(BaseStateMachine stateMachine)
        {
            //var navMeshAgent = stateMachine.GetComponent<NavMeshAgent>();
            //var patrolPoints = stateMachine.GetComponent<PatrolPoints>();
            if (patrolPoints.HasReached(navMeshAgent))
            {
                navMeshAgent.SetDestination(patrolPoints.GetNext().position);
            }
            else if (navMeshAgent.velocity.magnitude < 0.02f) // To avoid enemy stuck around obstackle after lose player.
            {
                navMeshAgent.ResetPath();
                navMeshAgent.SetDestination(patrolPoints.GetNext().position);
                navMeshAgent.velocity = (Vector3.one * 3);
            }
        }

        public override void OnEnterExecute(BaseStateMachine stateMachine)
        {
            navMeshAgent = stateMachine.GetComponent<NavMeshAgent>();
            patrolPoints = stateMachine.GetComponent<PatrolPoints>();
        }

        public override void OnExitExecute(BaseStateMachine stateMachine)
        {

        }
    }
}
