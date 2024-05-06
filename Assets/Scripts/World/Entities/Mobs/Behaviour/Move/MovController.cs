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
            movUtils.Move(transform, distance, speed, zInput, xInput);
        }
    }
}