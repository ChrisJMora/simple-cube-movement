using Scripts.World.Entities.Mobs.Behaviour.Move.Utils.Data;
using UnityEngine;

namespace Scripts.World.Entities.Mobs.Behaviour.Move.Utils
{
    public class PositionManager
    {
        private const float MinDist = 0.05f;

        private PositionManager() { } // Private constructor to prevent instantiation

        public static void UpdateCurrentPosition(EntityPositionData posData, Vector3 targPos, float speed)
        {
            posData.CurrentPosition = Vector3.MoveTowards(posData.CurrentPosition, targPos, speed * Time.deltaTime);
        }

        public static bool ReachPosition(Vector3 currPos, Vector3 targPos)
        {
            return Vector3.Distance(currPos, targPos) <= MinDist;
        }

        public static void GetNextTargetPosition(EntityPositionData posData, Vector3 direction)
        {
            bool reachTarg = ReachPosition(posData.CurrentPosition, posData.TargetPosition);
            bool reachDest = ReachPosition(posData.CurrentPosition, posData.DestinyPosition);

            if (reachTarg && !reachDest)
            {
                posData.TargetPosition += direction;
            }
        }

        public static void GetNextDestinyPosition(EntityPositionData posData, Vector3 direction, float distance)
        {
            if (ReachPosition(posData.CurrentPosition, posData.DestinyPosition))
            {
                posData.DestinyPosition += direction * distance;
            }
        }
    }
}