using UnityEngine;

namespace Scripts.World.Entities.Mobs.Behaviour.Movement {
    public class MovUtilities {
        public LayerMask wall;

        public MovUtilities() {
            wall = LayerMask.GetMask("Wall");
        }
        
        public void UpdateEntityPosition(Transform entity, Vector3 target, float speed) {
            entity.position = Vector3.MoveTowards(entity.position, target, speed * Time.fixedDeltaTime);
        }

        public Vector3 MoveReferences(Transform entity, Transform walkRef, Transform groundRef,
         float x, float z) {
            if (CheckDistance(entity, walkRef)) {
                if (Mathf.Abs(x) == 1f) 
                    MoveSideWays(walkRef, groundRef, x);
                else if (Mathf.Abs(z) == 1f) 
                    MoveForward(walkRef, groundRef, z);
            }
            return walkRef.position;
        }

        public bool CheckDistance(Transform entity, Transform walkRef) {
            return Vector3.Distance(entity.position, walkRef.position) <= .05f;
        }

        public bool CheckWall(Vector3 target) {
            return Physics.CheckSphere(target, .2f, wall);
        }

        public bool CheckGround(Transform groundRef) {
            return Physics.CheckSphere(groundRef.position, .2f, wall);
        }

        public void MoveSideWays(Transform walkRef, Transform groundRef, float distance) {
            Debug.Log("Move sideways");
            if (distance == 1f) 
                walkRef.rotation = Quaternion.Euler(0f, 90f, 0f);
            else 
                walkRef.rotation = Quaternion.Euler(0f, -90f, 0f);
            walkRef.position += new Vector3(distance, 0f, 0f);
            groundRef.position = walkRef.position + Vector3.down;
        }

        public void MoveForward(Transform walkRef, Transform groundRef, float distance) {
            Debug.Log("Move forward");
            if (distance == 1f) 
                walkRef.rotation = Quaternion.Euler(0f, 0f, 0f);
            else 
                walkRef.rotation = Quaternion.Euler(0f, 180f, 0f);
            walkRef.position += new Vector3(0f, 0f, distance);
            groundRef.position = walkRef.position + Vector3.down;
        }
    }
}