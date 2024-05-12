using Scripts.World.Entities.Mobs.Behaviours.Movement.Utils.Data;
using UnityEngine;

namespace Scripts.World.Entities.Mobs.Behaviours.Movement.Utils
{
    public class OrientationManager
    {
        private OrientationManager() { } // Private constructor to prevent instantiation

        public static void GetDirection(EntityTrayectoryData entityTrayectoryData, Vector2 inputData)
        {
            if (Mathf.Abs(inputData.x) == 1f)
            {
                entityTrayectoryData.Direction = new Vector3(inputData.x, 0f, 0f);
            }
            else if (Mathf.Abs(inputData.y) == 1f)
            {
                entityTrayectoryData.Direction = new Vector3(0f, 0f, inputData.y);
            }
            else // In case of invalid orientation
            {
                throw new System.Exception("Invalid orientation");
            }
        }

        public static void GetOrientation(EntityTrayectoryData entityTrayectoryData, Vector2 inputData)
        {
            if (Mathf.Abs(inputData.x) == 1f)
            {
                entityTrayectoryData.Orientation = Quaternion.Euler(0f, inputData.x * 90f, 0f);
            }
            else if (Mathf.Abs(inputData.y) == 1f)
            {
                entityTrayectoryData.Orientation = Quaternion.Euler(0f, inputData.y == 1f ? 0f : 180f, 0f);
            }
            else // In case of invalid orientation
            {
                throw new System.Exception("Invalid orientation");
            }
        }
    }
}