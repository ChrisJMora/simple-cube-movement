using UnityEngine;
using Scripts.CustomAttributes;

namespace Scripts.World.Entities.Mobs.Behaviour.Move.Utils.Data
{
    [System.Serializable]
    public class EntityMovData
    {
        private readonly MovPropertiesData _movPropertiesData;
        [SerializeField] private EntityPositionData _positionData;
        [SerializeField] private EntityTrayectoryData _trayectoryData;
        [SerializeField] [ReadOnly] private bool _isJumping;
        [SerializeField] [ReadOnly] private bool _isFalling;

        public EntityMovData(Transform entityTransform, MovPropertiesData movPropData)
        {
            _movPropertiesData = movPropData;
            _positionData = new EntityPositionData(entityTransform);
            _trayectoryData = new EntityTrayectoryData(entityTransform);
        }

        public MovPropertiesData MovPropertiesData { get => _movPropertiesData; }
        public EntityPositionData PositionData { get => _positionData; }
        public EntityTrayectoryData TrayectoryData { get => _trayectoryData; }
        public bool IsJumping { get => _isJumping; set => _isJumping = value; }
        public bool IsFalling { get => _isFalling; set => _isFalling = value; }
    }
}