using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scripts.World.Entities.Mobs.Behaviour.Die {
    public class DieHandler : MonoBehaviour {
        
        public Animator animator;

        private void Start() {
            animator = GetComponent<Animator>();
        }

        private void OnEnable() {
            DieController.Die += HandleDie;
        }

        private void OnDisable() {
            DieController.Die -= HandleDie;
        }

        private void HandleDie() {
            // gameObject.GetComponentInParent<MovController>().enabled = false;
            animator.SetTrigger("TouchBullet");
        }

        public void RestartScene() {
            Debug.Log("Restarting scene...");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}