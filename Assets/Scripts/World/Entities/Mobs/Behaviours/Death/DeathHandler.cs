using Scripts.World.Entities.Mobs.Behaviours.ReceiveDamage;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scripts.World.Entities.Mobs.Behaviour.Death {
    public class DeathHandler : MonoBehaviour {
        
        // public Animator animator;

        private void Start() {
//            animator = GetComponent<Animator>();
        }

        private void OnEnable() {
            ReceiveDamageController.Die += DieWithNoLoot;
        }

        private void OnDisable() {
            ReceiveDamageController.Die -= DieWithNoLoot;
        }

        private void DieWithNoLoot(GameObject gameObject) {
            Destroy(gameObject);
        }

        public void RestartScene() {
            Debug.Log("Restarting scene...");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}