using UnityEngine;

namespace Scripts.World.Entities.Collectables.Utils.Data
{
    [CreateAssetMenu(fileName = "LootProperties", menuName = "new Collectable Properties", order = 1)]
    public class CollectableProperties : ScriptableObject
    {
        [SerializeField] private GameObject _collectablePrefab;
        [SerializeField] private float _probabilityOfAppear;

        public GameObject CollectablePrefab { get => _collectablePrefab; set => _collectablePrefab = value; }
        public float ProbabilityOfAppear { get => _probabilityOfAppear; set => _probabilityOfAppear = value; }
    }
}
