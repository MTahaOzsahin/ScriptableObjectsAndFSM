using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

namespace ScriptableObjectsAndFSM.Player
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class Mover : MonoBehaviour
    {
        /// <summary>
        /// We will make our players movement with mouse click.
        /// </summary>
        /// 


        [SerializeField] InputAction playerInputAction;
        [SerializeField] float playerSpeed = 5f;
        [SerializeField] float playerFastSpeed = 8f;
        [SerializeField] float rotationSpeed = 360f;
        Camera mainCamera;
        int groundLayer;
        Coroutine coroutine;
        Vector3 targetPosition;
        NavMeshAgent navMeshAgent;

        private void Awake()
        {
            mainCamera = Camera.main;
            groundLayer = LayerMask.NameToLayer("Ground");
            navMeshAgent = GetComponent<NavMeshAgent>();
        }
        private void OnEnable()
        {
            playerInputAction.Enable();
            playerInputAction.started += MoveWithMouseClick;
            playerInputAction.performed += MoveWithMouseClick;
        }
        private void OnDisable()
        {
            playerInputAction.started -= MoveWithMouseClick;
            playerInputAction.performed -= MoveWithMouseClick;
            playerInputAction.Disable();
        }

        void MoveWithMouseClick(InputAction.CallbackContext context)
        {
            Ray ray = mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());
            if (Physics.Raycast(ray: ray , hitInfo: out RaycastHit hit) && hit.collider && 
                hit.collider.gameObject.layer.CompareTo(groundLayer) == 0)
            {
                if (coroutine != null) StopCoroutine(coroutine);
                if (context.started)
                {
                    coroutine = StartCoroutine(PlayerMoveCoroutine(hit.point, playerSpeed,rotationSpeed));
                }
                else if (context.performed)
                {
                    coroutine = StartCoroutine(PlayerMoveCoroutine(hit.point, playerFastSpeed,rotationSpeed));
                }
                targetPosition = hit.point;
            }
        }
        IEnumerator PlayerMoveCoroutine(Vector3 target,float moveSpeed,float rotationSpeed)
        {
            float playerDistanceToFloor = transform.position.y - target.y;
            target.y += playerDistanceToFloor;
            while (Vector3.Distance(transform.position,target) > 0.2f)
            {
                navMeshAgent.destination = target;
                navMeshAgent.speed = moveSpeed;
                navMeshAgent.angularSpeed = rotationSpeed;
                if(Vector3.Distance(transform.position,target) < 0.3f)
                {
                    navMeshAgent.speed = (moveSpeed / 3);
                }
                yield return null;
            }
        }
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(targetPosition, 0.5f);
        }
    }
}
