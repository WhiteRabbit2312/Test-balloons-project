using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace TestProject
{
    public class LevelSpawner : MonoBehaviour
    {
        private LevelManager _levelManager;
        private DiContainer _container;

        [Inject]
        public void Construct(LevelManager levelManager, DiContainer container)
        {
            _levelManager = levelManager;
            _container = container;
        }

        private void Start()
        {
            GameObject levelPrefab = _levelManager.CurrentLevelToLoad.LevelPrefab;

            if (levelPrefab != null)
            {
                GameObject levelInstance = _container.InstantiatePrefab(levelPrefab, Vector3.zero, Quaternion.identity, null);
                //LevelContext context = levelInstance.GetComponent<LevelContext>();
                //context.Data = _levelManager.CurrentLevelToLoad;
            }
        }
    }
}