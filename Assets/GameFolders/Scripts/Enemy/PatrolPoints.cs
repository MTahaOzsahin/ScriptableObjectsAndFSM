using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace ScriptableObjectsAndFSM.Enemy
{
    public class PatrolPoints : MonoBehaviour
    {
        [SerializeField] Transform[] patrolPoints;
        Vector3 startPosition;
        public Transform CurrentPoint => patrolPoints[currentPoint];
        public Transform nextPatrolPoint { get; set; }

        public Vector3 StartPosition => startPosition;

        int currentPoint = 0;
        private void Awake()
        {
            startPosition = transform.position;
        }
        public Transform GetNext()
        {
            Transform point = patrolPoints[Random.Range(currentPoint, patrolPoints.Length)];
            nextPatrolPoint = point;
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
