using System;
using UnityEngine;

namespace ShootEmUp
{
    [Serializable]
    public sealed class LevelBackground : 
        GameListeners.IGameStartListener,
        GameListeners.IGameFixedUpdateListener
    {
        private float startPositionY;
        private float endPositionY;
        private float movingSpeedY;
        private float positionX;
        private float positionZ;
        private Transform myTransform;

        [SerializeField] private Params m_params;

        public void Construct(Transform levelTransform)
        {
            myTransform = levelTransform;
        }

        public void OnStart()
        {
            startPositionY = m_params.m_startPositionY;
            endPositionY = m_params.m_endPositionY;
            movingSpeedY = m_params.m_movingSpeedY;
            var position = myTransform.position;
            positionX = position.x;
            positionZ = position.z;
        }

        public void OnFixedUpdate(float deltaTime)
        {
            if (myTransform.position.y <= endPositionY)
            {
                myTransform.position = new Vector3(
                    positionX,
                    startPositionY,
                    positionZ
                );
            }

            myTransform.position -= new Vector3(
                positionX,
                movingSpeedY * Time.fixedDeltaTime,
                positionZ
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