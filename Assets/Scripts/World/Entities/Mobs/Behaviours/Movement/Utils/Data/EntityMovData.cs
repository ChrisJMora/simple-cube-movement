using UnityEngine;
using Scripts.CustomAttributes;

namespace Scripts.World.Entities.Mobs.Behaviours.Movement.Utils.Data
{
    public class EntityMovData : MonoBehaviour
    {
        [Header("External Data")]
        [SerializeField] private Transform _entityTransform;
        [SerializeField] private MovPropertiesData _movPropertiesData;
        [Header("Internal Data")]
        [SerializeField][ReadOnly] private float _currentSpeed;
        [SerializeField] private EntityPositionData _positionData;
        [SerializeField] private EntityTrayectoryData _trayectoryData;
        [Header("States")]
        [SerializeField] [ReadOnly] private bool _isJumping;
        [SerializeField] [ReadOnly] private bool _isFalling;

        private void Awake()
        {
            _positionData = new EntityPositionData(_entityTransform);
            _trayectoryData = new EntityTrayectoryData(_entityTransform);
        }

        public MovPropertiesData MovPropertiesData { get => _movPropertiesData; }
        public EntityPositionData PositionData { get => _positionData; }
        public EntityTrayectoryData TrayectoryData { get => _trayectoryData; }
        public float CurrentSpeed { get => _currentSpeed; set => _currentSpeed = value; }
        public bool IsJumping { get => _isJumping; set => _isJumping = value; }
        public bool IsFalling { get => _isFalling; set => _isFalling = value; }
    }
}