using ScriptableObjectsAndFSM.Enemy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace ScriptableObjectsAndFSM.FSM
{
    [CreateAssetMenu(menuName ="FSM/Remain In State",fileName ="RemainInState")]
    public sealed class RemainInState : BaseState
    {
        public override void MainExecute(BaseStateMachine stateMachine)
        {
            
        }
    }
}
