using UnityEngine;

namespace Scripts.Game
{
    public class WinHandler : MonoBehaviour
    {
        [SerializeField] private GameController _gameController;
        [SerializeField] private GameData _gameData;
        private void Update()
        {
            if (_gameController.CurrentScore >= _gameData.ScoreForWinning)
            {
                Debug.Log("You win!");
            }
        }
    }
}
