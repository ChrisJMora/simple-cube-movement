using UnityEngine;

namespace Scripts.World.Entities.Mobs.Behaviour.Win {
    public class WinHandler : MonoBehaviour {

        public Animator animator;

        private void Start() {
            animator = GetComponent<Animator>();
        }

        private void OnEnable() {
            WinController.Win += HandleWin;
        }

        private void OnDisable() {
            WinController.Win -= HandleWin;
        }

        public void HandleWin() {
            animator.SetTrigger("WinTheGame");
        }
    }
}