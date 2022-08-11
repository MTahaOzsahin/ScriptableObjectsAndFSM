using ScriptableObjectsAndFSM.Enemy;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace ScriptableObjectsAndFSM.FSM.FSMActions
{
    [CreateAssetMenu(menuName = "FSM/Actions/Chase")]
    public class ChaseAction : FSMAction
    {
        NavMeshAgent navMeshAgent;
        EnemySightSensor enemySightSensor;


        public override void MainExecute(BaseStateMachine stateMachine)
        {
            if (enemySightSensor.Player == null) return;
            navMeshAgent.SetDestination(enemySightSensor.Player.position);
        }

        public override void OnEnterExecute(BaseStateMachine stateMachine)
        {
            Debug.Log("Chase enter");
            navMeshAgent = stateMachine.GetComponent<NavMeshAgent>();
            enemySightSensor = stateMachine.GetComponent<EnemySightSensor>();
        }

        public override void OnExitExecute(BaseStateMachine stateMachine)
        {
            Debug.Log("Chase exit");
        }
    }
}
