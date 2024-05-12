using UnityEngine;
using Scripts.CustomAttributes;

namespace Scripts.World.Entities.Mobs.Behaviours.Movement.Utils.Data 
{
    [System.Serializable]
    public class EntityPositionData
    {
        [SerializeField] [ReadOnly] private Vector3 currentPosition;
        [SerializeField] [ReadOnly] private Vector3 targetPosition;
        [SerializeField] [ReadOnly] private Vector3 destinyPosition;
        [SerializeField] [ReadOnly] private float currentHeight;

        public EntityPositionData(Transform entityTransform)
        {
            CurrentPosition = TargetPosition = DestinyPosition = entityTransform.position;
            CurrentHeight = CurrentPosition.y;
        }

        public Vector3 CurrentPosition { get => currentPosition; set => currentPosition = value; }
        public Vector3 TargetPosition { get => targetPosition; set => targetPosition = value; }
        public Vector3 DestinyPosition { get => destinyPosition; set => destinyPosition = value; }
        public float CurrentHeight { get => currentHeight; set => currentHeight = value; }
    }
}