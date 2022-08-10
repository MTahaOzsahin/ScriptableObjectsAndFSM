using ScriptableObjectsAndFSM.Enemy;
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
        public override void MainExecute(BaseStateMachine stateMachine)
        {
            //var navMeshAgent = stateMachine.GetComponent<NavMeshAgent>();
            //var enemySightSensor = stateMachine.GetComponent<EnemySightSensor>();
            if (enemySightSensor.LastKnownPosition == null) return;
            navMeshAgent.SetDestination(enemySightSensor.LastKnownPosition);
            //navMeshAgent.gameObject.transform.RotateAround(navMeshAgent.gameObject.transform.position, Vector3.up, 20f * Time.deltaTime);
        }

        public override void OnEnterExecute(BaseStateMachine stateMachine)
        {
            Debug.Log("Check enter");
            navMeshAgent = stateMachine.GetComponent<NavMeshAgent>();
            enemySightSensor = stateMachine.GetComponent<EnemySightSensor>();
        }

        public override void OnExitExecute(BaseStateMachine stateMachine)
        {
            Debug.Log("Check exit");
        }
    }
}
