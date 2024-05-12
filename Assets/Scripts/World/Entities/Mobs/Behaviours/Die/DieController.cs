using UnityEngine;

namespace Scripts.World.Entities.Mobs.Behaviour.Die {
    public class DieController : MonoBehaviour {
        [Header("Dependencies")]
        // public MovUtilities movUtils;
        public DieHandler dieHandler;
        
        // Delegates
        public delegate void _Die();
        // Events
        public static event _Die Die;

        void Start() {
            // movUtils = new();
        }

        void FixedUpdate() {
            // if (movUtils.CheckBlock(transform.position, transform.position + Vector3.down, "LethalBlock")) {
            //     Debug.Log("Game Over!");
            //     Die?.Invoke();
            // }
        }
    }
}