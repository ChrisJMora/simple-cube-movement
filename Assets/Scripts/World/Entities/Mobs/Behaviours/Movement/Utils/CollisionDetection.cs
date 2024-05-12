using UnityEngine;

namespace Scripts.World.Entities.Mobs.Behaviours.Movement.Utils 
{
    public class CollisionDetection
    {
        private CollisionDetection() { } // Private constructor to prevent instantiation

        public static bool BlockDetected(Vector3 targetPosition, string layer)
        {
            return Physics.CheckSphere(targetPosition, .05f, LayerMask.GetMask(layer));
        }
    }
}