using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace ShootEmUp
{
    [Serializable]
    public sealed class LevelBackground : 
        GameListeners.IGameStartListener,
        GameListeners.IGameFixedUpdateListener
    {
        private float _startPositionY;
        private float _endPositionY;
        private float _movingSpeedY;
        private float _positionX;
        private float _positionZ;
        private Transform _myTransform;

        [SerializeField] private Params _m_params;

        public void Construct(Transform levelTransform)
        {
            _myTransform = levelTransform;
        }

        public void OnStart()
        {
            _startPositionY = _m_params.m_startPositionY;
            _endPositionY = _m_params.m_endPositionY;
            _movingSpeedY = _m_params.m_movingSpeedY;
            var position = _myTransform.position;
            _positionX = position.x;
            _positionZ = position.z;
        }

        public void OnFixedUpdate(float deltaTime)
        {
            if (_myTransform.position.y <= _endPositionY)
            {
                _myTransform.position = new Vector3(
                    _positionX,
                    _startPositionY,
                    _positionZ
                );
            }

            _myTransform.position -= new Vector3(
                _positionX,
                _movingSpeedY * Time.fixedDeltaTime,
                _positionZ
            );
        }

        [Serializable]
        public sealed class Params
        {
            [SerializeField] public float m_startPositionY;
            [SerializeField] public float m_endPositionY;
            [SerializeField] public float m_movingSpeedY;
        }
    }
}