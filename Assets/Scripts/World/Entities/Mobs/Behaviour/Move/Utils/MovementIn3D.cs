using Scripts.World.Entities.Mobs.Behaviour.Move.Utils.Data;
using Scripts.World.Entities.Mobs.Behaviour.Move.Utils;
using UnityEngine;

namespace Assets.Scripts.World.Entities.Mobs.Behaviour.Move.Utils
{
    public class MovementIn3D
    {
        private MovementIn3D() { } // Private constructor to prevent instantiation

        public static void Move(EntityMovData movData, MovInputData movInputData)
        {
            EntityPositionData positionData = movData.PositionData;
            bool wallDetected = CollisionDetection.BlockDetected(positionData.TargetPosition, "Wall");
            bool floorDetected = CollisionDetection.BlockDetected(positionData.TargetPosition + Vector3.down, "Wall");
            bool feetOnFloor = !movData.IsJumping && !movData.IsFalling;

            if (wallDetected) Jump(movData);

            if (!floorDetected) Fall(movData);

            if (feetOnFloor) MovementIn2D.Move(movData, movInputData);
        }

        public static void Jump(EntityMovData movData)
        {
            EntityPositionData positionData = movData.PositionData;
            Vector3 currentPosition = positionData.CurrentPosition;
            Vector3 currentTopPosition = positionData.CurrentPosition + Vector3.up;
            float targetHeight = positionData.CurrentHeight + movData.MovPropertiesData.jumpHeight;
            float speed = movData.MovPropertiesData.speed;
            bool reachTargetHeight = currentPosition.y >= targetHeight;

            movData.IsJumping = true;
            PositionManager.UpdateCurrentPosition(positionData, currentTopPosition, speed);
            if (reachTargetHeight) FinishJump(movData);
        }

        private static void FinishJump(EntityMovData movData)
        {
            EntityPositionData posData = movData.PositionData;
            float jumpHeight = movData.MovPropertiesData.jumpHeight;

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
            float speed = movData.MovPropertiesData.speed;
            bool reachNextStep = PositionManager.ReachPosition(currentPosition, targetPosition);

            movData.IsFalling = true;
            PositionManager.UpdateCurrentPosition(positionData, targetPosition, speed);
            if (reachNextStep) FinishFall(movData);
        }

        private static void FinishFall(EntityMovData movData)
        {
            EntityPositionData posData = movData.PositionData;
            float jumpHeight = movData.MovPropertiesData.jumpHeight;

            posData.CurrentHeight -= jumpHeight;
            posData.TargetPosition += Vector3.down;
            posData.DestinyPosition += Vector3.down;
            movData.IsFalling = false;
        }
    }
}