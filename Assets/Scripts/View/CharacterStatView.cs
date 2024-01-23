using TMPro;
using UnityEngine;

namespace MVP
{
    public class CharacterStatView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _statName;
        [SerializeField] private TMP_Text _statValue;

        public void ChangeStatData(string statName, int statValue)
        {
            _statName.text = statName;
            _statValue.text = statValue.ToString();
        }
    }
}