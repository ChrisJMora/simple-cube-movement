using UnityEngine;

namespace Scripts.World.Entities.Mobs.Behaviour.Move.Utils.Data 
{
    [CreateAssetMenu(fileName = "MovPropertiesData", menuName = "New MovPropertiesData", order = 1)]
    public class MovPropertiesData : ScriptableObject
    {
        public float speed;
        public float distance;
        public float jumpHeight;
    }
}