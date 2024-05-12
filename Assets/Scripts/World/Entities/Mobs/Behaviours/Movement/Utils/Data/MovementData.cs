using UnityEngine;
using Scripts.CustomAttributes;

namespace Scripts.World.Entities.Mobs.Behaviours.Movement.Utils.Data
{
    public class MovementData : MonoBehaviour
    {
        [Header("External Data")]
        [SerializeField] private MovementProperties _movPropertiesData;
        [Header("Internal Data")]
        [SerializeField][ReadOnly] private float _currentSpeed;
        [SerializeField] private PositionData _positionData;
        [SerializeField] private TrayectoryData _trayectoryData;
        [Header("States")]
        [SerializeField] [ReadOnly] private bool _isMoving = true;
        [SerializeField] [ReadOnly] private bool _isJumping;
        [SerializeField] [ReadOnly] private bool _isFalling;

        private void Awake()
        {
            _positionData = new PositionData(transform);
            _trayectoryData = new TrayectoryData(transform);
        }

        public MovementProperties MovPropertiesData { get => _movPropertiesData; }
        public PositionData PositionData { get => _positionData; }
        public TrayectoryData TrayectoryData { get => _trayectoryData; }
        public float CurrentSpeed { get => _currentSpeed; set => _currentSpeed = value; }
        public bool IsMoving { get => _isMoving; set => _isMoving = value; }
        public bool IsJumping { get => _isJumping; set => _isJumping = value; }
        public bool IsFalling { get => _isFalling; set => _isFalling = value; }
    }
}