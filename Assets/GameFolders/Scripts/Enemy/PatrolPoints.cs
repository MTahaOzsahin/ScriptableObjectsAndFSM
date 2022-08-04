using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace ScriptableObjectsAndFSM.Enemy
{
    public class PatrolPoints : MonoBehaviour
    {
        [SerializeField] Transform[] patrolPoints;

        public Transform CurrentPoint => patrolPoints[currentPoint];
        public GameObject nextPatrolPoint { get; set; }

        int currentPoint = 0;

        public Transform GetNext()
        {
            Transform point = patrolPoints[Random.Range(currentPoint,patrolPoints.Length)];
            nextPatrolPoint = point.gameObject;
            return point;
        }
        public bool HasReached(NavMeshAgent agent)
        {
            if (!agent.pathPending)
            {
                if (agent.remainingDistance <= agent.stoppingDistance)
                {
                    if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
