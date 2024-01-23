using UnityEngine;

namespace MVP
{
    public class CharacterStatMainView : MonoBehaviour
    {
        [SerializeField] private Transform characterStatRoot;
        [SerializeField] private CharacterStatView characterStatViewPrefab;
        
        public CharacterStatView CreateStat(CharacterStat stat)
        {
            var characterStatView = Instantiate(characterStatViewPrefab, characterStatRoot);
            characterStatView.ChangeStatData(stat.Name,stat.Value);
            return characterStatView;
        }
        
        public void DestroyStat(CharacterStatView characterStatView)
        {
            Destroy(characterStatView.transform.gameObject);
        }
    }
}