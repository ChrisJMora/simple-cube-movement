using UnityEngine;

namespace Scripts.World.Entities.Mobs.Behaviour.Win {
    public class WinHandler : MonoBehaviour {

        void OnEnable() {
            WinController.Win += HandleWin;
        }

        void OnDisable() {
            WinController.Win += HandleWin;
        }

        public void HandleWin(Animator animator, GameObject entity) {
            animator.SetTrigger("WinTheGame");
        }
    }
}