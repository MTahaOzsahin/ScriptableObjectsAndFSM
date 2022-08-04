using ScriptableObjectsAndFSM.FSM;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.AI;

namespace ScriptableObjectsAndFSM.Enemy
{
    public class Overseer : MonoBehaviour
    {
        BaseStateMachine baseStateMachine;
        PatrolPoints patrolPoints;
        NavMeshAgent navMeshAgent;

        [SerializeField] TMP_Text currentStateText;
        [SerializeField] TMP_Text nextPatrolPointText;
        [SerializeField] float velocity;
        private void Awake()
        {
            baseStateMachine = GetComponent<BaseStateMachine>();
            patrolPoints = GetComponent<PatrolPoints>();
            navMeshAgent = GetComponent<NavMeshAgent>();
        }
        private void Update()
        {
            CurrentState();
            NextPatrolPoint();
            CurrentVelocity();
        }
        void CurrentState()
        {
            var currentState = baseStateMachine.CurrentState;
            currentStateText.text = ("Current State: " + currentState.ToString());
        }
        void NextPatrolPoint()
        {
            var nextPatrolPoint = patrolPoints.nextPatrolPoint;
            nextPatrolPointText.text =("Next Patrol Point: " + nextPatrolPoint.ToString());
        }
        void CurrentVelocity()
        {
            velocity = navMeshAgent.velocity.magnitude;
        }
    }
}
