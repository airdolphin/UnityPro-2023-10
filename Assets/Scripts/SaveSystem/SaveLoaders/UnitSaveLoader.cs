using System;
using System.Collections.Generic;
using System.Linq;
using GameEngine;
using UnityEngine;
using Zenject;

namespace SaveLoaders
{
    public class UnitSaveLoader : SaveLoader<UnitData[], UnitManager>
    {
        private List<Unit> _unitPrefabList;
        
        [Inject]
        public void Construct(List<Unit> unitPrefabList)
        {
            _unitPrefabList = unitPrefabList;
        }
        
        protected override UnitData[] ConvertToData(UnitManager service)
        {
            var units = service.GetAllUnits().ToArray();
            var unitsData = new UnitData[units.Length];
            for (int i = 0; i < units.Length; i++)
            {
                unitsData[i].type = units[i].Type;
                unitsData[i].hitPoints = units[i].HitPoints;
                unitsData[i].position = JsonUtility.ToJson(units[i].Position);
                unitsData[i].rotation = JsonUtility.ToJson(units[i].Rotation);
            }
            return unitsData;
        }

        protected override void SetupData(UnitData[] data, UnitManager service)
        {
            var unitList = service.GetAllUnits().ToList();
            var loadedUnitList = data.ToList();

            for (int i = unitList.Count - 1; i >= 0; i--)
            {
                service.DestroyUnit(unitList[i]);
            }

            foreach (var unitData in loadedUnitList)
            {
                var unitPrefab = _unitPrefabList.First(u=>u.Type == unitData.type);

                if (!unitPrefab)
                {
                    throw new NullReferenceException($"No such type of Unit - {unitData.type}");
                }

                var position = JsonUtility.FromJson<Vector3>(unitData.position);
                var rotation = JsonUtility.FromJson<Vector3>(unitData.rotation);

                var spawnedUnit = service.SpawnUnit(unitPrefab,position,Quaternion.Euler(rotation));
                spawnedUnit.HitPoints = unitData.hitPoints;
            }
        }
    }
}