using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjectsAndFSM.FSM.FSMActions
{
    [CreateAssetMenu(menuName = "FSM/Actions/Empty")]
    public class EmptyAction : FSMAction
    {
        public override void MainExecute(BaseStateMachine stateMachine)
        {
            Debug.Log("empty main");
        }

        public override void OnEnterExecute(BaseStateMachine stateMachine)
        {
            Debug.Log("empty Enter");
        }

        public override void OnExitExecute(BaseStateMachine stateMachine)
        {
            Debug.Log("empty Exit");
        }
    }
}
