using ScriptableObjectsAndFSM.Enemy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace ScriptableObjectsAndFSM.FSM.FSMActions
{
    [CreateAssetMenu(menuName = "FSM/Actions/Chase")]
    public class ChaseAction : FSMAction
    {
        public override void Execute(BaseStateMachine stateMachine)
        {
            var navMeshAgent = stateMachine.GetComponent<NavMeshAgent>();
            var enemySightSensor = stateMachine.GetComponent<EnemySightSensor>();
            if (enemySightSensor.Player == null) return;
            navMeshAgent.SetDestination(enemySightSensor.Player.position);
        }
    }
}
