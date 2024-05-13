using Assets.Scripts.World.Entities.Mobs.Behaviours.Movement.Utils;
using Scripts.World.Entities.Mobs.Behaviours.Movement.Utils.Data;
using Scripts.World.Entities.Mobs.Behaviours.Movement.Utils;
using UnityEngine;
using Scripts.World.Entities.Mobs.Behaviour.Death;

namespace Scripts.World.Entities.Mobs.Behaviours.Movement.Types.DepthMotion
{
    public class NormalJump : DepthMovement
    {
        [SerializeField] private DeathHandler _deathHandler;

        public delegate void _Die(GameObject entity);
        public static event _Die Die;

        public override void Jump()
        {
            PositionData positionData = movData.PositionData;
            bool wallDetected = CollisionDetection.BlockDetected(positionData.TargetPosition, "Block");
            if (wallDetected) MovementIn3D.Jump(movData);
        }

        public override void Fall()
        {
            PositionData positionData = movData.PositionData;
            bool floorDetected = CollisionDetection.BlockDetected(positionData.TargetPosition + Vector3.down, "Block");
            if (!floorDetected) MovementIn3D.Fall(movData);
            if (movData.PositionData.CurrentHeight <= -5) Die?.Invoke(gameObject);
        }
    }
}
