using ScriptableObjectsAndFSM.Enemy;
using ScriptableObjectsAndFSM.FSM.FSMActions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjectsAndFSM.FSM.FSMDecisions
{
    [CreateAssetMenu(menuName = "FSM/Decisions/ Have Lost Player")]
    public class HaveLostPLayer : Decision
    {
        public override bool Decide(BaseStateMachine stateMachine)
        {
            //var checkLastPosition = stateMachine.GetComponent<CheckLastPosition>();
            //return checkLastPosition.IsCheckCompleted();
            var enemyInLineOfSight = stateMachine.GetComponent<EnemySightSensor>();
            return enemyInLineOfSight.IsCheckCompleted();
        }
    }
}
