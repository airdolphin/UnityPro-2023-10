using UnityEngine;

namespace ShootEmUp
{
    public class PauseButton : MonoBehaviour
    {
        [SerializeField] private GameManager gameManager;
        
        public void PauseGame()
        {
            if (gameManager.GameState ==  GameState.PAUSED)
            {
                gameManager.ResumeGame();
                return;
            }

            gameManager.PauseGame();
        }
    }
}