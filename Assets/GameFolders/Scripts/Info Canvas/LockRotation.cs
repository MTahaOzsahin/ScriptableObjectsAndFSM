using UnityEngine;

namespace ScriptableObjectsAndFSM.InfoCanvas
{
    public class LockRotation : MonoBehaviour
    {
        Quaternion quaternion;
        void Start()
        {
            quaternion = transform.rotation;
        }

        void LateUpdate()
        {
            transform.rotation = quaternion;
        }
    }
}
