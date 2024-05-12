using Scripts.World.Entities.Mobs.Behaviours.Movement.Utils.Data;
using UnityEngine;

namespace Scripts.World.Entities.Mobs.Behaviours.Movement.Types.SurfaceMotion
{
    public abstract class SurfaceMovement : MonoBehaviour
    {
        [SerializeField] protected EntityMovData movData;

        private void Update()
        {
            Move(); Run();
        }

        public abstract void Move();
        public abstract void Run();
        public void Stop()
        {
            movData.PositionData.DestinyPosition = movData.PositionData.TargetPosition;
        }
    }
}