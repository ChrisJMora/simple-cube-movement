using UnityEngine;

namespace Scripts.World.Entities.Mobs.Behaviours.Movement.Utils.Data 
{
    [CreateAssetMenu(fileName = "MovPropertiesData", menuName = "new MovPropertiesData", order = 1)]
    public class MovPropertiesData : ScriptableObject
    {
        [SerializeField] private float _minSpeed;
        [SerializeField] private float _speed;
        [SerializeField] private float _maxSpeed;
        [SerializeField] private float _distance;
        [SerializeField] private float _jumpHeight;

        public float MinSpeed { get => _minSpeed; set => _minSpeed = value; }
        public float Speed { get => _speed; set => _speed = value; }
        public float MaxSpeed { get => _maxSpeed; set => _maxSpeed = value; }
        public float Distance { get => _distance; set => _distance = value; }
        public float JumpHeight { get => _jumpHeight; set => _jumpHeight = value; }
    }
}