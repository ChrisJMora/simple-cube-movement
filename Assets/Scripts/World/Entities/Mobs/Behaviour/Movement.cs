using UnityEngine;

namespace Scripts.World.Entities.Mobs.Behaviour {
    public class Movement : MonoBehaviour {
        public Transform movePoint;
        public Transform groundCheck;
        public LayerMask wall;

        void Start() {
            movePoint = new GameObject("MovePoint").transform;
            groundCheck = new GameObject("GroundCheck").transform;
            
            groundCheck.position += Vector3.down;
            wall = LayerMask.GetMask("Wall");
        }

        void OnEnable() {
            MovController.Jump += HandleJump;
            MovController.Fall += HandleFall;
        }

        void OnDisable() {
            MovController.Jump -= HandleJump;
            MovController.Fall -= HandleFall;
        }

        public Vector3 GetNextStep(Transform entityTransform) {
            float xDistance = Input.GetAxisRaw("Horizontal");
            float zDistance = Input.GetAxisRaw("Vertical");
            if (CheckDistance(entityTransform)) {
                if (Mathf.Abs(xDistance) == 1f) MoveSideWays(xDistance);
                else if (Mathf.Abs(zDistance) == 1f) MoveForward(zDistance);
            }
            return movePoint.position;
        }

        void HandleJump(Transform entityTransform, float moveSpeed) {
            Vector3 entityPosition = entityTransform.position;
            entityTransform.position = Vector3.MoveTowards(entityPosition, entityPosition + Vector3.up,
                moveSpeed * Time.deltaTime);
            if (entityPosition.y >= 1f) {
                groundCheck.position = movePoint.position;
                movePoint.position += Vector3.up;
            } 
        }

        void HandleFall(Transform entityTransform, float moveSpeed) {
            Vector3 entityPosition = entityTransform.position;
            entityTransform.position = Vector3.MoveTowards(entityPosition, movePoint.position,
                moveSpeed * Time.deltaTime);
            if (CheckDistance(entityTransform)) {
                movePoint.position += Vector3.down;
                groundCheck.position = movePoint.position + Vector3.down;
            }
        }

        public bool CheckDistance(Transform entityTransform) {
            return Vector3.Distance(entityTransform.position, movePoint.position) <= .05f;
        }

        public bool CheckWall(Vector3 target) {
            return Physics.CheckSphere(target, .2f, wall);
        }

        public bool CheckGround() {
            return Physics.CheckSphere(groundCheck.position, .2f, wall);
        }

        public void MoveSideWays(float distance) {
            if (distance == 1f) 
                movePoint.rotation = Quaternion.Euler(0f, 90f, 0f);
            else 
                movePoint.rotation = Quaternion.Euler(0f, -90f, 0f);
            movePoint.position += new Vector3(distance, 0f, 0f);
            groundCheck.position = movePoint.position + Vector3.down;
        }

        public void MoveForward(float distance) {
            if (distance == 1f) 
                movePoint.rotation = Quaternion.Euler(0f, 0f, 0f);
            else 
                movePoint.rotation = Quaternion.Euler(0f, 180f, 0f);
            movePoint.position += new Vector3(0f, 0f, distance);
            groundCheck.position = movePoint.position + Vector3.down;
        }
    }
}