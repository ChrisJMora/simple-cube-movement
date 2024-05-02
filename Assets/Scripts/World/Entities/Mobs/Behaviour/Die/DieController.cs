using UnityEngine;

namespace Scripts.World.Entities.Mobs.Behaviour.Die {
    public class DieController : MonoBehaviour {
        [Header("Dependencies")]
        public DieUtilities dieUtils;

        
        // Delegates
        public delegate void _Die(GameObject entity);
        // Events
        public static event _Die Die;

        void Start() {
            dieUtils = new();
            gameObject.AddComponent<DieHandler>();
        }

        void FixedUpdate() {
            if (dieUtils.CheckDeath(transform.position)) {
                Debug.Log("Death detected!");
                Die?.Invoke(gameObject);
            }
        }
    }
}