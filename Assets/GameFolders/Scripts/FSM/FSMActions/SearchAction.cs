using ScriptableObjectsAndFSM.Enemy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace ScriptableObjectsAndFSM.FSM.FSMActions
{
    [CreateAssetMenu(menuName = "FSM/Actions/Search")]
    public class SearchAction : FSMAction
    {
        public override void MainExecute(BaseStateMachine stateMachine)
        {
            var navMeshAgent = stateMachine.GetComponent<NavMeshAgent>();
            var enemySightSensor = stateMachine.GetComponent<EnemySightSensor>();

            if (enemySightSensor.LastKnownPosition == null) return;
            navMeshAgent.SetDestination(enemySightSensor.LastKnownPosition);
        }

        public override void OnEnterExecute(BaseStateMachine stateMachine)
        {

        }

        public override void OnExitExecute(BaseStateMachine stateMachine)
        {

        }
    }
}
