using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MVP
{
    public class LevelProgressBarView : MonoBehaviour
    {
        [SerializeField] private Slider xpSlider;
        [SerializeField] private TextMeshProUGUI sliderText;
        [SerializeField] private Sprite normalSlider;
        [SerializeField] private Sprite finishedSlider;

        public void ChangeExperienceValue(int xpValue, int maxXPValue, string textForSlider, bool canLevelUp)
        {
            xpSlider.maxValue = maxXPValue;
            xpSlider.value = xpValue;
            sliderText.text = textForSlider;
            xpSlider.fillRect.GetComponent<Image>().sprite = canLevelUp ? finishedSlider : normalSlider;
        }
    }
}