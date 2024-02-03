using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace ShootEmUp
{
    public class GameUIManager : MonoBehaviour
    {
        [SerializeField] private GameManager _gameManager;
        [SerializeField] private Button _startButton;
        [SerializeField] private Button _pauseButton;
        [SerializeField] private TMP_Text _startCountdownText;
        [SerializeField] private int _delay;
        [SerializeField] private float _waitSeconds;

        private void Awake()
        {
            _startButton.gameObject.SetActive(true);
            _startCountdownText.gameObject.SetActive(false);
            _pauseButton.gameObject.SetActive(true);
        }

        private void OnEnable()
        {
            _startButton.onClick.AddListener(OnStartButtonClick);
            _pauseButton.onClick.AddListener(OnPauseButtonClick);
        }

        private void OnDisable()
        {
            _startButton.onClick.RemoveListener(OnStartButtonClick);
            _pauseButton.onClick.RemoveListener(OnPauseButtonClick);
        }

        public void OnStartButtonClick()
        {
            _startButton.gameObject.SetActive(false);
            _startCountdownText.gameObject.SetActive(true);

            StartCoroutine(StartGameCoroutine());
        }

        public void OnPauseButtonClick()
        {
            if (_gameManager.GameState == GameState.PAUSED)
            {
                _gameManager.ResumeGame();
                return;
            }

            _gameManager.PauseGame();
        }

        private IEnumerator StartGameCoroutine()
        {
            for (int i = _delay; i > 0; i--)
            {
                Debug.Log(i);
                _startCountdownText.text = i.ToString();
                yield return new WaitForSeconds(_waitSeconds);
            }

            _startCountdownText.enabled = false;
            _gameManager.StartGame();
        }
    }
}