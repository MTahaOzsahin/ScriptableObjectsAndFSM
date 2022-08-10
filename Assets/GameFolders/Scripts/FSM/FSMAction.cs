using ScriptableObjectsAndFSM.Enemy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace ScriptableObjectsAndFSM.FSM
{
    public abstract class FSMAction : ScriptableObject
    {
        public abstract void OnEnterExecute(BaseStateMachine stateMachine);
        public abstract void MainExecute(BaseStateMachine stateMachine);
        public abstract void OnExitExecute(BaseStateMachine stateMachine);
    }
}
