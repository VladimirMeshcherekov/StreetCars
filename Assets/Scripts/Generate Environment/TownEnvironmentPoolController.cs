using Components;
using CustomPool;
using UnityEngine;
using System;
using Environment = Components.Environment;

namespace Generate_Environment
{
    [Serializable]
    public class TownEnvironmentPoolController
    {
        [SerializeField] private TownEnvironment[] townEnvironments;
        [SerializeField] private CrossroadTownEnvironment[] crossroadTownEnvironments;
        [SerializeField] private int poolCapacityPerObject;
        private CustomPool<Environment> _townEnvironmentsPool;
        private CustomPool<Environment> _crossroadTownEnvironmentsPool;

        public void Init()
        {
            _townEnvironmentsPool = new CustomPool<Environment>(townEnvironments, poolCapacityPerObject);
            _crossroadTownEnvironmentsPool = new CustomPool<Environment>(crossroadTownEnvironments, poolCapacityPerObject);
        }

        public Environment GetTownEnvironment()
        {
            return _townEnvironmentsPool.Get();
        }

        public Environment GetCrossroadTownEnvironments()
        {
            return _crossroadTownEnvironmentsPool.Get();
        }
    }
}