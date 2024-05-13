using UnityEngine;

namespace Scripts.Game
{
    [CreateAssetMenu(fileName = "GameController", menuName = "new GameController")]
    public class GameController : ScriptableObject
    {
        [SerializeField] private float _currentScore;
        [SerializeField] private float _currentNumberOfEnemies;

        public float CurrentScore { get => _currentScore; set => _currentScore = value; }
        public float CurrentNumberOfEnemies 
        {
            get => _currentNumberOfEnemies;
            set => _currentNumberOfEnemies = value; 
        }
    }
}
