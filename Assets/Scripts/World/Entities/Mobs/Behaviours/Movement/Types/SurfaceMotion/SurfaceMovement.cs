using Scripts.World.Entities.Mobs.Behaviours.Movement.Utils.Data;
using UnityEngine;

namespace Scripts.World.Entities.Mobs.Behaviours.Movement.Types.SurfaceMotion
{
    public abstract class SurfaceMovement : MonoBehaviour
    {
        [SerializeField] protected MovementData movData;

        private void Update()
        {
            Move(); Run();
        }

        public abstract void Move();
        public abstract void Run();
    }
}