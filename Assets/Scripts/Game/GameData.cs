using UnityEngine;

namespace Scripts.Game
{
    [CreateAssetMenu(fileName = "GameData", menuName = "new GameData")]
    public class GameData : ScriptableObject
    {
        [SerializeField] private float _scoreForWinning;
        [SerializeField] private float _numberOfEnemies;

        public float ScoreForWinning { get => _scoreForWinning; set => _scoreForWinning = value; }
        public float NumberOfEnemies { get => _numberOfEnemies; set => _numberOfEnemies = value; }
    }
}
