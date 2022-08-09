using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjectsAndFSM.FSM
{
    public class BaseState : ScriptableObject
    {
        public virtual void OnEnterExecute(BaseStateMachine machine) { }
        public virtual void MainExecute(BaseStateMachine machine) { }
        public virtual void OnExitExecute(BaseStateMachine machine) { }
    }
}
