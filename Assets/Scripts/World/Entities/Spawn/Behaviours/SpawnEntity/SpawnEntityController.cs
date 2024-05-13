using Scripts.Game;
using UnityEngine;

namespace Scripts.World.Entities.Spawn.Behaviours.SpawnEntity
{
    public class SpawnEntityController : MonoBehaviour
    {
        [SerializeField] private GameController _gameController;
        [SerializeField] private GameData _gameData;
        [SerializeField] private GameObject _entityPrefab;

        private void Start()
        {
            InvokeRepeating(nameof(SpawnEntity), 0, 20f);
        }

        private void SpawnEntity()
        {
            Instantiate(_entityPrefab, transform.position, Quaternion.identity);
        }
    }
}
