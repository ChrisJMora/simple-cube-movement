using Scripts.World.Entities.Mobs.Behaviour.Move.Utils.Data;
using UnityEngine;

namespace Scripts.World.Entities.Mobs.Behaviour.Move.Utils
{
    public class OrientationManager
    {
        private OrientationManager() { } // Private constructor to prevent instantiation

        public static void GetDirection(EntityTrayectoryData entityTrayectoryData, MovInputData movInputData)
        {
            if (Mathf.Abs(movInputData.Horizontal) == 1f)
            {
                entityTrayectoryData.Direction = new Vector3(movInputData.Horizontal, 0f, 0f);
            }
            else if (Mathf.Abs(movInputData.Vertical) == 1f)
            {
                entityTrayectoryData.Direction = new Vector3(0f, 0f, movInputData.Vertical);
            }
            else // In case of invalid orientation
            {
                throw new System.Exception("Invalid orientation");
            }
        }

        public static void GetOrientation(EntityTrayectoryData entityTrayectoryData, MovInputData movInputData)
        {
            if (Mathf.Abs(movInputData.Horizontal) == 1f)
            {
                entityTrayectoryData.Orientation = Quaternion.Euler(0f, movInputData.Horizontal * 90f, 0f);
            }
            else if (Mathf.Abs(movInputData.Vertical) == 1f)
            {
                entityTrayectoryData.Orientation = Quaternion.Euler(0f, movInputData.Vertical == 1f ? 0f : 180f, 0f);
            }
            else // In case of invalid orientation
            {
                throw new System.Exception("Invalid orientation");
            }
        }
    }
}