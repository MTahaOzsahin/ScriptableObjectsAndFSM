using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjectsAndFSM.FSM.FSMDecisions
{
    [CreateAssetMenu(menuName = "FSM/Decisions/ Enemy Type Decision")]
    public class EnemyTypeDecision : Decision
    {
        public override bool Decide(BaseStateMachine stateMachine)
        {
            if (stateMachine.enemyType == BaseStateMachine.EnemyType.Guard)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
