using UnityEngine;

namespace Scripts.World.Entities.Mobs.Behaviour.Die {
    public class DieHandler : MonoBehaviour {

        void OnEnable() {
            DieController.Die += HandleDie;
        }

        void OnDisable() {
            DieController.Die += HandleDie;
        }

        public void HandleDie(Animator animator, GameObject entity) {
            animator.SetTrigger("TouchBullet");
            Destroy(entity, 1);
        }
    }
}