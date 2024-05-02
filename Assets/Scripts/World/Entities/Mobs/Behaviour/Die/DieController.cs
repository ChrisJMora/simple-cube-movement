using Scripts.World.Entities.Mobs.Behaviour.Move;
using UnityEngine;

namespace Scripts.World.Entities.Mobs.Behaviour.Die {
    public class DieController : MonoBehaviour {
        [Header("Dependencies")]
        public MovUtilities movUtils;
        public Animator animator;

        
        // Delegates
        public delegate void _Die(Animator animator, GameObject entity);
        // Events
        public static event _Die Die;

        void Start() {
            movUtils = new();
            gameObject.AddComponent<DieHandler>();
        }

        void FixedUpdate() {
            if (movUtils.CheckGround(transform.position, "LethalBlock")) {
                Debug.Log("Game Over!");
                Die?.Invoke(animator, gameObject);
            }
        }
    }
}