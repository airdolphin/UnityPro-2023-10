using System.Collections;
using TMPro;
using UnityEngine;

namespace ShootEmUp
{
    public class StartButton : MonoBehaviour
    {
        [SerializeField] private GameManager gameManager;
        [SerializeField] private int delay;
        [SerializeField] private float waitSeconds;
        [SerializeField] private TMP_Text countdownText;

        public void StartGame()
        {
            StartCoroutine(StartGameCoroutine());
        }

        private IEnumerator StartGameCoroutine()
        {
            for (int i = delay; i > 0; i--)
            {
                countdownText.text = i.ToString();
                yield return new WaitForSeconds(waitSeconds);
            }

            countdownText.enabled = false;
            gameManager.StartGame();
        }
    }
}