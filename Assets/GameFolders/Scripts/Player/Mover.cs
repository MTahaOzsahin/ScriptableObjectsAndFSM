using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ScriptableObjectsAndFSM.Player
{
    [RequireComponent(typeof(CharacterController))]
    public class Mover : MonoBehaviour
    {
        /// <summary>
        /// We will make our players movement with mouse click.
        /// </summary>
        /// 


        [SerializeField] InputAction playerInputAction;
        [SerializeField] float playerSpeed = 5f;
        [SerializeField] float playerFastSpeed = 10f;
        [SerializeField] float rotationSpeed = 6f;
        Camera mainCamera;
        int groundLayer;
        Coroutine coroutine;
        Vector3 targetPosition;
        CharacterController characterController;

        private void Awake()
        {
            mainCamera = Camera.main;
            characterController = GetComponent<CharacterController>();
            groundLayer = LayerMask.NameToLayer("Ground");
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
                    coroutine = StartCoroutine(PlayerMoveCoroutine(hit.point, playerSpeed));
                }
                else if (context.performed)
                {
                    coroutine = StartCoroutine(PlayerMoveCoroutine(hit.point, playerFastSpeed));
                }
                targetPosition = hit.point;
            }
        }
        IEnumerator PlayerMoveCoroutine(Vector3 target,float moveSpeed)
        {
            float playerDistanceToFloor = transform.position.y - target.y;
            target.y += playerDistanceToFloor;
            while (Vector3.Distance(transform.position,target) > 0.2f)
            {
                Vector3 direction = target - transform.position;
                Vector3 movement = direction.normalized * moveSpeed * Time.deltaTime;
                characterController.Move(movement);
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction.normalized),
                    rotationSpeed * Time.deltaTime);
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
