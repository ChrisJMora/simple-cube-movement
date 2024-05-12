using Scripts.World.Entities.Mobs.Behaviours.Movement.Utils.Data;
using Scripts.World.Entities.Mobs.Behaviours.Movement.Utils;
using UnityEngine;

namespace Assets.Scripts.World.Entities.Mobs.Behaviours.Movement.Utils
{
    public class MovementIn3D
    {
        private MovementIn3D() { } // Private constructor to prevent instantiation

        public static void Jump(EntityMovData movData)
        {
            EntityPositionData positionData = movData.PositionData;
            Vector3 currentPosition = positionData.CurrentPosition;
            Vector3 currentTopPosition = positionData.CurrentPosition + Vector3.up;
            float targetHeight = positionData.CurrentHeight + movData.MovPropertiesData.JumpHeight;
            float speed = movData.MovPropertiesData.Speed;
            bool reachTargetHeight = currentPosition.y >= targetHeight;

            movData.IsJumping = true;
            PositionManager.UpdateCurrentPosition(positionData, currentTopPosition, speed);
            if (reachTargetHeight) FinishJump(movData);
            movData.transform.position = positionData.CurrentPosition;
        }

        private static void FinishJump(EntityMovData movData)
        {
            EntityPositionData posData = movData.PositionData;
            float jumpHeight = movData.MovPropertiesData.JumpHeight;

            posData.CurrentHeight += jumpHeight;
            posData.TargetPosition += Vector3.up;
            posData.DestinyPosition += Vector3.up;
            movData.IsJumping = false;
        }

        public static void Fall(EntityMovData movData)
        {
            EntityPositionData positionData = movData.PositionData;
            Vector3 currentPosition = positionData.CurrentPosition;
            Vector3 targetPosition = positionData.TargetPosition;
            float speed = movData.MovPropertiesData.Speed;
            bool reachNextStep = PositionManager.ReachPosition(currentPosition, targetPosition);

            movData.IsFalling = true;
            PositionManager.UpdateCurrentPosition(positionData, targetPosition, speed);
            if (reachNextStep) FinishFall(movData);
            movData.transform.position = positionData.CurrentPosition;
        }

        private static void FinishFall(EntityMovData movData)
        {
            EntityPositionData posData = movData.PositionData;
            float jumpHeight = movData.MovPropertiesData.JumpHeight;

            posData.CurrentHeight -= jumpHeight;
            posData.TargetPosition += Vector3.down;
            posData.DestinyPosition += Vector3.down;
            movData.IsFalling = false;
        }
    }
}