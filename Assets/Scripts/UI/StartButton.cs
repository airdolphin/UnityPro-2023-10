using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

namespace ShootEmUp
{
    public class StartButton : MonoBehaviour
    {
        [SerializeField] private GameManager gameManager;
        [SerializeField] private int delay;
        [SerializeField] private float waitSeconds;
        [SerializeField] private TMP_Text countdownText;
        [SerializeField] private Button button;

        public void StartGame()
        {
            Debug.Log("Start button pressed");
            // gameObject.SetActive(false);
            StartCoroutine(StartGameCoroutine());
        }

        private IEnumerator StartGameCoroutine()
        {
            // for (int i = delay; i > 0; i--)
            for (int i = 1; i > 0; i--)
            {
            countdownText.text = i.ToString();
            yield return new WaitForSeconds(waitSeconds);
            }

            countdownText.enabled = false;
            gameManager.StartGame();
        }
    }
}