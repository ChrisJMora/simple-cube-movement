using UnityEngine;

namespace Scripts.World.Entities.Mobs.Behaviour.Move
{
    public class MovController : MonoBehaviour
    {
        [Header("Properties")]
        public float speed;
        public float distance;

        [Header("Dependencies")]
        [Tooltip("The library that handles the movement of the entity.")]
        [SerializeField] MovUtilities movUtils;

        void Awake()
        {
            movUtils = new(transform.position);
        }

        void Update()
        {
            float xInput = Input.GetAxisRaw("Horizontal");
            float zInput = Input.GetAxisRaw("Vertical");

            if (movUtils.CheckWall(movUtils.targetPosition))
                movUtils.Jump(transform, speed);
            else
            if (!movUtils.CheckWall(movUtils.targetPosition + Vector3.down))
                movUtils.Fall(transform, speed);
            if (!movUtils.isJumping && !movUtils.isFalling)
                movUtils.Move(transform, distance, speed, xInput, zInput);
        }
    }
}