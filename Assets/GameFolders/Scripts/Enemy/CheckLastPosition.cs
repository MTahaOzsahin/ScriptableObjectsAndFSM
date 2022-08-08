using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace ScriptableObjectsAndFSM.Enemy
{
    public class CheckLastPosition : MonoBehaviour
    {
        public bool IsCheckCompleted()
        {
            float distance = Vector3.Distance(transform.position, GetComponent<EnemySightSensor>().LastKnownPosition);
            if (distance < 0.2f)
            {
                return true;
            }
            return false;
        }
    }
}
