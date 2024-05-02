using UnityEngine;

namespace Scripts.World.Entities.Mobs.Behaviour.Shoot {
    public class ShootController : MonoBehaviour{
        public GameObject bullet;
        public Transform shootPoint;

        void Update() {
            if (Input.GetMouseButtonDown(0)) {
                GameObject bala = Instantiate(bullet, shootPoint.position, shootPoint.rotation);
            }
        }
    }
}