using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace MVP
{
    public class CloseButtonView : MonoBehaviour
    {
        [SerializeField] private Button closeButton;

        public void AddListener(UnityAction action)
        {
            closeButton.onClick.AddListener(action);
        }

        public void RemoveListener(UnityAction action)
        {
            closeButton.onClick.RemoveListener(action);
        }
    }
}