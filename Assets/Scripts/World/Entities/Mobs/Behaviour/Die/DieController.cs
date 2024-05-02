using UnityEngine;

namespace Scripts.World.Entities.Mobs.Behaviour.Die {
    public class DieController : MonoBehaviour {
        [Header("Dependencies")]
        public DieUtilities dieUtils;
        public Animator animator;

        
        // Delegates
        public delegate void _Die(Animator animator, GameObject entity);
        // Events
        public static event _Die Die;

        void Start() {
            dieUtils = new();
            gameObject.AddComponent<DieHandler>();
        }

        void FixedUpdate() {
            if (dieUtils.CheckDeath(transform.position)) {
                Debug.Log("Game Over!");
                Die?.Invoke(animator, gameObject);
            }
        }
    }
}