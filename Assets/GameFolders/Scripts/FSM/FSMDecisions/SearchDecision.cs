using ScriptableObjectsAndFSM.Enemy;
using ScriptableObjectsAndFSM.FSM.FSMActions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace ScriptableObjectsAndFSM.FSM.FSMDecisions
{
    [CreateAssetMenu(menuName = "FSM/Decisions/ Searching")]
    public class SearchDecision : Decision
    {
        public override bool Decide(BaseStateMachine stateMachine)
        {
            var enemyInLineOfSight = stateMachine.GetComponent<EnemySightSensor>();
            return enemyInLineOfSight.IsCheckCompleted();
        }
    }
}
