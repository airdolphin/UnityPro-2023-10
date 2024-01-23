using UnityEngine;

namespace MVP
{
    public class PopupView : MonoBehaviour
    {
        [SerializeField] private CharacterInfoView characterInfoView;
        [SerializeField] private CharacterStatMainView characterStatMainView;
        [SerializeField] private CharacterStatView characterStatView;
        [SerializeField] private LevelupButtonView levelupButtonView;
        [SerializeField] private CloseButtonView closeButtonView;
        [SerializeField] private LevelProgressBarView levelProgressBarView;

        public CharacterInfoView CharacterInfoView => characterInfoView;
        public CharacterStatMainView CharacterStatMainView => characterStatMainView;
        public CharacterStatView CharacterStatView => characterStatView;
        public CloseButtonView CloseButtonView => closeButtonView;
        public LevelProgressBarView LevelProgressBarView => levelProgressBarView;
        public LevelupButtonView LevelupButtonView => levelupButtonView;

        private void Awake()
        {
            gameObject.SetActive(false);
        }
    }
}