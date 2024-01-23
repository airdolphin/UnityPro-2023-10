using UnityEngine;
using System;
    

namespace ShootEmUp
{
    [Serializable]
    public class CharacterFireInteractor
    {
        private WeaponComponent _weapon;
        private BulletSystem _bulletSystem;
        [SerializeField] private BulletConfig _bulletConfig;
        
        [Inject]
        public void Construct(BulletSystem bulletSystem, CharacterService characterService)
        {
            _bulletSystem = bulletSystem;
            _weapon =  characterService.Character.GetComponent<WeaponComponent>();
        }
        
        public void Fire()
        {
            Debug.Log("FIRE");
            
            _bulletSystem.FlyBulletByArgs(new BulletSystem.Args
            {
                isPlayer = true,
                physicsLayer = (int)_bulletConfig.physicsLayer,
                color = _bulletConfig.color,
                damage = _bulletConfig.damage,
                position = _weapon.Position,
                velocity = _weapon.Rotation * Vector3.up * _bulletConfig.speed
            });
        }
    }
}