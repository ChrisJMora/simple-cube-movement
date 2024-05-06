using UnityEngine;

namespace Scripts.World.Entities.Mobs.Behaviour.Move
{
    public class MovController : MonoBehaviour
    {
        [Header("Properties")]
        public float speed;
        public float distance;

        // [Header("References")]
        // [SerializeField] public Transform wallRef;
        // [SerializeField] public Transform groundRef;

        [Header("Dependencies")]
        [Tooltip("The library that handles the movement of the entity.")]
        [SerializeField] MovUtilities movUtils;

        // Delegates
        // public delegate void _Jump(Transform entity, Transform wallRef,
        //  Transform groundRef, float speed);
        // public delegate void _Fall(Transform entity, Transform wallRef,
        //  Transform groundRef, float speed);
        // // Events
        // public static event _Jump Jump;
        // public static event _Fall Fall;

        void Awake()
        {
            movUtils = new(transform.position, speed, distance);
            gameObject.AddComponent<MovHandler>();
        }

        void OnDrawGizmosSelected()
        {
            // Draw a wireframe sphere in the Scene view
            Debug.Log("Drawing Gizmos");
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(movUtils.targetPosition, .05f);
        }

        void Update()
        {
            // Debug.Log($"Current: {movUtils.current}, Target: {movUtils.target}");
            float xInput = Input.GetAxisRaw("Horizontal");
            float zInput = Input.GetAxisRaw("Vertical");

            if (movUtils.CheckWall(movUtils.targetPosition))
                movUtils.Jump(transform);
            else
            if (!movUtils.CheckWall(movUtils.targetPosition + Vector3.down))
                movUtils.Fall(transform);
            if (!movUtils.isJumping && !movUtils.isFalling)
                movUtils.Move(transform, xInput, zInput);
        }
    }
}