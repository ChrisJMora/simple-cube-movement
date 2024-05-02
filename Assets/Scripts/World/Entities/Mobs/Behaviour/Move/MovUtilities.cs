using UnityEngine;

namespace Scripts.World.Entities.Mobs.Behaviour.Move {
    public class MovUtilities {
        public LayerMask wall;

        public MovUtilities() {
            wall = LayerMask.GetMask("Wall");
        }
        
        public void UpdateEntityPosition(Transform entity, Transform target, float speed) {
            Debug.Log("Update entity position");
            entity.SetPositionAndRotation(
                Vector3.MoveTowards(entity.position, target.position,
                speed * Time.fixedDeltaTime), target.rotation);
        }

        public Transform MoveReferences(Transform entity, Transform walkRef, Transform groundRef,
         float x, float z) {
            if (CheckDistance(entity, walkRef)) {
                if (Mathf.Abs(x) == 1f) 
                    MoveSideWays(walkRef, groundRef, x);
                else if (Mathf.Abs(z) == 1f) 
                    MoveForward(walkRef, groundRef, z);
            }
            return walkRef;
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

        public bool CheckGround(Vector3 origin, string tag) {
            RaycastHit hit;
            if (Physics.Raycast(origin, Vector3.down, out hit, 1f))
                return hit.collider.CompareTag(tag);
            return false;
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