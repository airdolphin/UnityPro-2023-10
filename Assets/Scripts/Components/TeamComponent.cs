using UnityEngine;
using UnityEngine.Serialization;

namespace ShootEmUp
{
    public sealed class TeamComponent : MonoBehaviour
    {
        [SerializeField] private bool _isPlayer;

        public bool IsPlayer
        {
            get { return _isPlayer; }
        }
    }
}