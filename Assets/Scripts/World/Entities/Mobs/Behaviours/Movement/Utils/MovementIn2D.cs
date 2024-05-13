using Scripts.World.Entities.Mobs.Behaviours.Movement.Utils.Data;
using UnityEngine;

namespace Scripts.World.Entities.Mobs.Behaviours.Movement.Utils {
    public class MovementIn2D
    {
        private MovementIn2D() { } // Private constructor to prevent instantiation

        public static void Move(MovementData movData, Vector2 inputData)
        {
            bool anyInput = inputData.x != 0 || inputData.y != 0;
            MakeStepForward(movData);
            if (anyInput && !movData.IsStunned)
            {
                FigureOutTrayectory(movData, inputData);
                LookForNewDestination(movData);
            }
            movData.transform.position = movData.PositionData.CurrentPosition;
        }

        public static void Bounce(MovementData movData, Vector3 collisionDirection)
        {
            movData.TrayectoryData.Direction = collisionDirection;
            movData.PositionData.DestinyPosition += collisionDirection;
        }

        public static void Stop(MovementData movData)
        {
            Vector3 targetPosition = movData.PositionData.TargetPosition;

            movData.PositionData.DestinyPosition = targetPosition;
            movData.IsStunned = true;
        }

        private static void MakeStepForward(MovementData movData)
        {
            PositionData positionData = movData.PositionData;
            Vector3 targetPosition = positionData.TargetPosition;
            Vector3 direction = movData.TrayectoryData.Direction;
            float speed = movData.CurrentSpeed;
            
            PositionManager.GetNextTargetPosition(positionData, direction);
            PositionManager.UpdateCurrentPosition(positionData, targetPosition, speed);
        }

        private static void FigureOutTrayectory(MovementData movData, Vector2 inputData)
        {
            TrayectoryData trayectoryData = movData.TrayectoryData;
            Vector3 currentPosition = movData.PositionData.CurrentPosition;
            Vector3 destinyPosition = movData.PositionData.DestinyPosition;
            bool reachDestiny = PositionManager.ReachPosition(currentPosition, destinyPosition);

            if (reachDestiny)
            {
                OrientationManager.GetOrientation(trayectoryData, inputData);
                OrientationManager.GetDirection(trayectoryData, inputData);
            }
            movData.transform.rotation = trayectoryData.Orientation;
        }

        private static void LookForNewDestination(MovementData movData)
        {
            PositionData positionData = movData.PositionData;
            Vector3 direction = movData.TrayectoryData.Direction;
            float distance = movData.MovPropertiesData.Distance;

            PositionManager.GetNextDestinyPosition(positionData, direction, distance);
        }
    }
}