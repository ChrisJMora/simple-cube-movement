using Scripts.World.Entities.Mobs.Behaviour.Move.Utils.Data;
using UnityEngine;

namespace Scripts.World.Entities.Mobs.Behaviour.Move.Utils {
    public class MovementIn2D
    {
        private MovementIn2D() { } // Private constructor to prevent instantiation

        public static void Move(EntityMovData movData, MovInputData movInputData)
        {
            bool anyInput = movInputData.Horizontal != 0 || movInputData.Vertical != 0;
            MakeStepForward(movData);
            if (anyInput)
            {
                FigureOutTrayectory(movData, movInputData);
                LookForNewDestination(movData);
            }
        }

        private static void MakeStepForward(EntityMovData movData)
        {
            EntityPositionData positionData = movData.PositionData;
            Vector3 targetPosition = positionData.TargetPosition;
            Vector3 direction = movData.TrayectoryData.Direction;
            float speed = movData.MovPropertiesData.speed;
            
            PositionManager.GetNextTargetPosition(positionData, direction);
            PositionManager.UpdateCurrentPosition(positionData, targetPosition, speed);
        }

        private static void FigureOutTrayectory(EntityMovData movData, MovInputData movInputData)
        {
            EntityTrayectoryData trayectoryData = movData.TrayectoryData;
            Vector3 currentPosition = movData.PositionData.CurrentPosition;
            Vector3 destinyPosition = movData.PositionData.DestinyPosition;
            bool reachDestiny = PositionManager.ReachPosition(currentPosition, destinyPosition);

            if (reachDestiny)
            {
                OrientationManager.GetOrientation(trayectoryData, movInputData);
                OrientationManager.GetDirection(trayectoryData, movInputData);
            }
        }

        private static void LookForNewDestination(EntityMovData movData)
        {
            EntityPositionData positionData = movData.PositionData;
            Vector3 direction = movData.TrayectoryData.Direction;
            float distance = movData.MovPropertiesData.distance;

            PositionManager.GetNextDestinyPosition(positionData, direction, distance);
        }
    }
}