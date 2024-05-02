using UnityEngine;

namespace Scripts.World.Entities.Mobs.Behaviour.Movement {
    public class MovHandler : MonoBehaviour{
        void OnEnable() {
            MovController.Jump += HandleJump;
            MovController.Fall += HandleFall;
        }

        void OnDisable() {
            MovController.Jump -= HandleJump;
            MovController.Fall -= HandleFall;
        }

        void HandleJump(Transform entity, Transform movePoint, Transform groundCheck, float speed) {
            Debug.Log("Jump");
            entity.position = Vector3.MoveTowards(entity.position, entity.position + Vector3.up,
                speed * Time.deltaTime);
            if (entity.position.y >= 1f) {
                groundCheck.position = movePoint.position;
                movePoint.position += Vector3.up;
            } 
        }

        void HandleFall(Transform entity, Transform movePoint, Transform groundCheck, float speed) {
            Debug.Log("Fall");
            entity.position = Vector3.MoveTowards(entity.position, movePoint.position,
                speed * Time.deltaTime);
            if (Vector3.Distance(entity.position, movePoint.position) <= .05f) {
                movePoint.position += Vector3.down;
                groundCheck.position = movePoint.position + Vector3.down;
            }
        }
    }
}