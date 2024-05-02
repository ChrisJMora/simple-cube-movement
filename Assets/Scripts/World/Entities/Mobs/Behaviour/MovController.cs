using UnityEngine;
using Scripts.CustomAttributes;

namespace Scripts.World.Entities.Mobs.Behaviour {
    public class MovController : MonoBehaviour {
        [Header("Movement Settings")]
        public float moveSpeed = 5f;

        // Delegates
        public delegate void _Jump(Transform entityPosition, float speed);
        public delegate void _Fall(Transform entityPosition, float speed);
        // Events
        public static event _Jump Jump;
        public static event _Fall Fall;

        [ReadOnly] public Movement movement;

        void Start() {
            movement = gameObject.AddComponent<Movement>();
        }

        void FixedUpdate() {
            Vector3 target = movement.GetNextStep(transform);
            if (movement.CheckWall(target)) {
                Jump?.Invoke(transform, moveSpeed);
            } else if (!movement.CheckGround()) {
                Fall?.Invoke(transform, moveSpeed);
            } else {
                UpdateEntityPosition(target);
            }
        }

        private void UpdateEntityPosition(Vector3 target) {
            transform.position = Vector3.MoveTowards(transform.position, target,
                moveSpeed * Time.fixedDeltaTime);
        }
    }
}