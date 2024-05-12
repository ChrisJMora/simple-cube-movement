using Scripts.World.Entities.Mobs.Behaviours.Movement.Utils.Data;
using UnityEngine;

namespace Scripts.World.Entities.Mobs.Behaviours.Movement.Types.DepthMotion
{
    public abstract class DepthMovement : MonoBehaviour
    {
        [SerializeField] protected MovementData movData;

        private void Update()
        {
            Jump(); Fall();
        }

        public abstract void Jump();
        public abstract void Fall();
    }
}
