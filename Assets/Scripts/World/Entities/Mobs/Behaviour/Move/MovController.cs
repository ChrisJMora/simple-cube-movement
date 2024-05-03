using UnityEngine;
using Scripts.CustomAttributes;

namespace Scripts.World.Entities.Mobs.Behaviour.Move {
    public class MovController : MonoBehaviour {
        [Header("Properties")]
        public float speed = 5f;

        [Header("References")]
        [SerializeField] public Transform wallRef;
        [SerializeField] public Transform groundRef;

        [Header("Dependencies")]
        [ReadOnly] public MovUtilities movUtils;

        // Delegates
        public delegate void _Jump(Transform entity, Transform wallRef,
         Transform groundRef, float speed);
        public delegate void _Fall(Transform entity, Transform wallRef,
         Transform groundRef, float speed);
        // Events
        public static event _Jump Jump;
        public static event _Fall Fall;

        void Start() {
            movUtils = new();
            gameObject.AddComponent<MovHandler>();
        }

        void FixedUpdate() {
            float xDistance = Input.GetAxisRaw("Horizontal");
            float zDistance = Input.GetAxisRaw("Vertical");
            Transform target = movUtils.MoveReferences(transform, wallRef, groundRef,
             xDistance, zDistance);
            if (movUtils.CheckWall(target.position)) {
                Jump?.Invoke(transform, wallRef, groundRef, speed);
            } else if (!movUtils.CheckGround(groundRef)) {
                Fall?.Invoke(transform, wallRef, groundRef, speed);
            } else {
                movUtils.UpdateEntityPosition(transform, target, speed);
            }
        }
    }
}