using Components;
using CustomPool;
using UnityEngine;
using System;

namespace Generate_Environment
{
    [Serializable]
    public class RoadsPoolController
    {
        [SerializeField] private TownRoad[] townRoads;
        [SerializeField] private CrossroadsTurnRoad[] crossroadsTurnRoads;
        [SerializeField] private Crossroad[] crossroads;
        [SerializeField] private int poolCapacityPerObject;

        private CustomPool<Road> _crossroadsTurnRoadsPool;
        private CustomPool<Road> _roadsPool;
        private CustomPool<Crossroad> _crossroadPool;

        public void Init()
        {
            _roadsPool = new CustomPool<Road>(townRoads, poolCapacityPerObject);
            _crossroadPool = new CustomPool<Crossroad>(crossroads, poolCapacityPerObject);
            _crossroadsTurnRoadsPool = new CustomPool<Road>(crossroadsTurnRoads, poolCapacityPerObject);
        }

        public Road GetRoad()
        {
            return _roadsPool.Get();
        }

        public Crossroad GetCrossroad()
        {
            return _crossroadPool.Get();
        }

        public Road GetCrossroadsTurnRoad()
        {
            return _crossroadsTurnRoadsPool.Get();
        }
    }
}