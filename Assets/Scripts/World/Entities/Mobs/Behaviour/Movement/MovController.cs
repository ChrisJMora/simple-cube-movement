using UnityEngine;
using Scripts.CustomAttributes;

namespace Scripts.World.Entities.Mobs.Behaviour.Movement {
    public class MovController : MonoBehaviour {
        [Header("Properties")]
        public float speed = 5f;

        [Header("References")]
        [ReadOnly] public Transform walkRef;
        [ReadOnly] public Transform groundRef;

        [Header("Dependencies")]
        [ReadOnly] public MovUtilities movUtils;

        // Delegates
        public delegate void _Jump(Transform entity, Transform walkRef,
         Transform groundRef, float speed);
        public delegate void _Fall(Transform entity, Transform walkRef,
         Transform groundRef, float speed);
        // Events
        public static event _Jump Jump;
        public static event _Fall Fall;

        void Start() {
            movUtils = new();
            gameObject.AddComponent<MovHandler>();
            walkRef = new GameObject("Walk Reference").transform;
            groundRef = new GameObject("Ground Reference").transform;
            groundRef.position += Vector3.down;
        }

        void FixedUpdate() {
            float xDistance = Input.GetAxisRaw("Horizontal");
            float zDistance = Input.GetAxisRaw("Vertical");
            Vector3 target = movUtils.MoveReferences(transform, walkRef, groundRef,
             xDistance, zDistance);
            if (movUtils.CheckWall(target)) {
                Debug.Log("Wall detected!");
                Jump?.Invoke(transform, walkRef, groundRef, speed);
            } else if (!movUtils.CheckGround(groundRef)) {
                Debug.Log("Ground not detected!");
                Fall?.Invoke(transform, walkRef, groundRef, speed);
            } else {
                movUtils.UpdateEntityPosition(transform, target, speed);
            }
        }
    }
}