using UnityEngine;

namespace Scripts.World.Entities.Mobs.Behaviour.Die {
    public class DieHandler : MonoBehaviour {
        public void Die() {
            Destroy(gameObject);
        }
    }
}