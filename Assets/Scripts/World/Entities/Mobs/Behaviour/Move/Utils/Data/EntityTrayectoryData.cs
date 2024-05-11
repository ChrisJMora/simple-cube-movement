using UnityEngine;
using Scripts.CustomAttributes;

namespace Scripts.World.Entities.Mobs.Behaviour.Move.Utils.Data
{
    [System.Serializable]
    public class EntityTrayectoryData
    {
        [SerializeField] [ReadOnly] private Vector3 direction;
        [SerializeField] [ReadOnly] private Quaternion orientation;

        public EntityTrayectoryData(Transform entityTransform)
        {
            Direction = entityTransform.forward;
            Orientation = entityTransform.rotation;
        }

        public Vector3 Direction { get => direction; set => direction = value; }
        public Quaternion Orientation { get => orientation; set => orientation = value; }
    }
}