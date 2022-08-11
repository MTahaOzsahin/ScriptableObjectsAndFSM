using ScriptableObjectsAndFSM.Enemy;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace ScriptableObjectsAndFSM.FSM.FSMActions
{
    [CreateAssetMenu(menuName = "FSM/Actions/CheckLastPosition")]
    public class SearchAction : FSMAction
    {
        NavMeshAgent navMeshAgent;
        EnemySightSensor enemySightSensor;

        public static event Action OnActionComplete;

        public override void MainExecute(BaseStateMachine stateMachine)
        {
            if (enemySightSensor.LastKnownPosition == null) return;
            navMeshAgent.SetDestination(enemySightSensor.LastKnownPosition);
            if (enemySightSensor.IsCheckCompleted()) OnActionComplete?.Invoke();
        }

        public override void OnEnterExecute(BaseStateMachine stateMachine)
        {
            Debug.Log("Search enter");
            navMeshAgent = stateMachine.GetComponent<NavMeshAgent>();
            enemySightSensor = stateMachine.GetComponent<EnemySightSensor>();
        }

        public override void OnExitExecute(BaseStateMachine stateMachine)
        {
            Debug.Log("Search exit");
            stateMachine.CurrentState = null;
        }
    }
}
