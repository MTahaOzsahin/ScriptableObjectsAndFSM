using ScriptableObjectsAndFSM.Enemy;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace ScriptableObjectsAndFSM.FSM.FSMActions
{
    [CreateAssetMenu(menuName ="FSM/Actions/Guard")]
    public class GuardAction : FSMAction
    {
        NavMeshAgent navMeshAgent;
        PatrolPoints patrolPoints;


        public override void MainExecute(BaseStateMachine stateMachine)
        {
            Vector3 startPosition = patrolPoints.StartPosition;
            if (Vector3.Distance(startPosition,navMeshAgent.gameObject.transform.position) > 0.2f )
            {
                navMeshAgent.SetDestination(startPosition);
            }
            navMeshAgent.gameObject.transform.RotateAround(navMeshAgent.gameObject.transform.position,Vector3.up, 20f * Time.deltaTime);
        }

        public override void OnEnterExecute(BaseStateMachine stateMachine)
        {
            Debug.Log("Guard on enter");
            navMeshAgent = stateMachine.GetComponent<NavMeshAgent>();
            patrolPoints = stateMachine.GetComponent<PatrolPoints>();
        }

        public override void OnExitExecute(BaseStateMachine stateMachine)
        {
            Debug.Log("Guard on exit");
        }
    }
}
