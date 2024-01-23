using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.UI;

namespace ShootEmUp
{
    public class GameUIManager : MonoBehaviour
    {
        [SerializeField] private GameManager gameManager;
        [SerializeField] private Button startButton;
        [SerializeField] private Button pauseButton;
        [SerializeField] private TMP_Text startCountdownText;
        [SerializeField] private int delay;
        [SerializeField] private float waitSeconds;

        private void Awake()
        {
            startButton.gameObject.SetActive(true);
            startCountdownText.gameObject.SetActive(false);
            pauseButton.gameObject.SetActive(true);
        }

        private void OnEnable()
        {
            startButton.onClick.AddListener(OnStartButtonClick);
            pauseButton.onClick.AddListener(OnPauseButtonClick);
        }

        private void OnDisable()
        {
            startButton.onClick.RemoveListener(OnStartButtonClick);
            pauseButton.onClick.RemoveListener(OnPauseButtonClick);
        }

        public void OnStartButtonClick()
        {
            startButton.gameObject.SetActive(false);
            startCountdownText.gameObject.SetActive(true);

            StartCoroutine(StartGameCoroutine());
        }

        public void OnPauseButtonClick()
        {
            if (gameManager.GameState == GameState.PAUSED)
            {
                gameManager.ResumeGame();
                return;
            }

            gameManager.PauseGame();
        }

        private IEnumerator StartGameCoroutine()
        {
            for (int i = delay; i > 0; i--)
            {
                Debug.Log(i);
                startCountdownText.text = i.ToString();
                yield return new WaitForSeconds(waitSeconds);
            }

            startCountdownText.enabled = false;
            gameManager.StartGame();
        }
    }
}