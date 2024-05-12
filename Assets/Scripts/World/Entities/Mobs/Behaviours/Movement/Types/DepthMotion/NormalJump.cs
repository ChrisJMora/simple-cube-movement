using Assets.Scripts.World.Entities.Mobs.Behaviours.Movement.Utils;
using Scripts.World.Entities.Mobs.Behaviours.Movement.Utils.Data;
using Scripts.World.Entities.Mobs.Behaviours.Movement.Utils;
using UnityEngine;

namespace Scripts.World.Entities.Mobs.Behaviours.Movement.Types.DepthMotion
{
    public class NormalJump : DepthMovement
    {
        public override void Jump()
        {
            PositionData positionData = movData.PositionData;
            bool wallDetected = CollisionDetection.BlockDetected(positionData.TargetPosition, "Wall");
            if (wallDetected) MovementIn3D.Jump(movData);
        }

        public override void Fall()
        {
            PositionData positionData = movData.PositionData;
            bool floorDetected = CollisionDetection.BlockDetected(positionData.TargetPosition + Vector3.down, "Wall");
            if (!floorDetected) MovementIn3D.Fall(movData);
        }
    }
}
