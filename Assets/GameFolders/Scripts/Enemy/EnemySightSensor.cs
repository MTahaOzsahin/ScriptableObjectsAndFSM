using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjectsAndFSM.Enemy
{
    public class EnemySightSensor : MonoBehaviour
    {
        public Transform Player { get;private set; }

        [SerializeField] LayerMask ignoreMask;

        Ray ray;

        private void Awake()
        {
            Player = GameObject.Find("Player").transform;
        }

        public bool Ping()
        {
            if (Player == null)
                return false;

            ray = new Ray(this.transform.position, Player.position - this.transform.position);

            if (Vector3.Dot(ray.direction, this.transform.forward) < 0)

                return false;

            if(!Physics.Raycast(ray,out var hit, 100f, ~ignoreMask))
            {
                return false;
            }
            if (hit.collider.tag == "Player")
            {
                return true;
            }
            return false;
        }
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(ray.origin, ray.origin + ray.direction * 100f);
        }
    }
}
