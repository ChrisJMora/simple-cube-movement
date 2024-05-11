using Scripts.CustomAttributes;
using Scripts.World.Entities.Mobs.Behaviour.Move.Utils.Data;
using UnityEngine;

namespace Scripts.World.Entities.Mobs.Behaviour.Move.Utils.Data 
{
    [System.Serializable]
    public class MovInputData
    {
        [SerializeField] [ReadOnly] private float _horizontal;
        [SerializeField] [ReadOnly] private float _vertical;
        public float Horizontal { get => _horizontal; set => _horizontal = value; }
        public float Vertical { get => _vertical; set => _vertical = value; }
    }
}