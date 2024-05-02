using Scripts.World.Entities.Mobs.Behaviour.Move;
using UnityEngine;

namespace Scripts.World.Entities.Mobs.Behaviour.Win {
    public class WinController : MonoBehaviour {
        [Header("Dependencies")]
        public MovUtilities movUtils;
        public Animator animator;

        
        // Delegates
        public delegate void _Win(Animator animator, GameObject entity);
        // Events
        public static event _Win Win;

        void Start() {
            movUtils = new();
            gameObject.AddComponent<WinHandler>();
        }

        void FixedUpdate() {
            if (movUtils.CheckGround(transform.position, "WinBlock")) {
                Debug.Log("You win!");
                Win?.Invoke(animator, gameObject);
            }
        }
    }
}