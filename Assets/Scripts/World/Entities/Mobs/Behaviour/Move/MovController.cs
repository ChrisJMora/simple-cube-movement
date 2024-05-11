using Assets.Scripts.World.Entities.Mobs.Behaviour.Move.Utils;
using Scripts.World.Entities.Mobs.Behaviour.Move.Utils.Data;
using UnityEngine;

namespace Scripts.World.Entities.Mobs.Behaviour.Move
{
    public class MovController : MonoBehaviour
    {
        [SerializeField] private MovPropertiesData movPropertiesData;
        [SerializeField] private MovInputData movementInputData;
        [SerializeField] private EntityMovData movementData;

        void Awake()
        {
            movementData = new EntityMovData(transform, movPropertiesData);
            movementInputData = new MovInputData();
        }

        void Update()
        {
            movementInputData.Horizontal = Input.GetAxisRaw("Horizontal");
            movementInputData.Vertical = Input.GetAxisRaw("Vertical");
            MovementIn3D.Move(movementData, movementInputData);
            transform.position = movementData.PositionData.CurrentPosition;
        }
    }
}