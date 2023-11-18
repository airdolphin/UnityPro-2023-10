using UnityEngine;

namespace ShootEmUp
{
    public sealed class GameManager : MonoBehaviour
    {
        public void FinishGame()
        {
            Debug.Log("GAME OVER :(");
            Time.timeScale = 0;
        }
    }
}