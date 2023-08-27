using System.Collections.Generic;
using Components;
using CustomPool;
using UnityEngine;

namespace Generate_Environment
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private TownRoad[] townRoads;
        [SerializeField] private CrossroadsTurnRoad[] crossroadsTurnRoads;
        [SerializeField] private Crossroad[] crossroads;
        [SerializeField] private TownEnvironment[] townEnvironments;
        [SerializeField] private CrossroadTownEnvironment[] crossroadTownEnvironments;
    
        private CustomPool<Road> _crossroadsTurnRoadsPool;
        private CustomPool<Road> _roadsPool;
        private CustomPool<Crossroad> _crossroadPool;
        private CustomPool<Environment> _townEnvironmentsPool; 
        private CustomPool<Environment> _crossroadTownEnvironmentsPool;
        private List<Road> _inSceneRoadQueue = new List<Road>();
        private List<Crossroad> _inSceneCrossroadQueue = new List<Crossroad>();

        private Vector3 _pointToSpawnNewRoad;

        private void Awake()
        {
            _pointToSpawnNewRoad = Vector3.zero;
        
            _roadsPool = new CustomPool<Road>(townRoads, 20);
            _crossroadPool = new CustomPool<Crossroad>(crossroads, 20);
            _crossroadsTurnRoadsPool = new CustomPool<Road>(crossroadsTurnRoads, 20);
            _townEnvironmentsPool = new CustomPool<Environment>(townEnvironments, 20);
            _crossroadTownEnvironmentsPool = new CustomPool<Environment>(crossroadTownEnvironments, 20);

            for (int i = 0; i < 8; i++)
            {
                GenerateNewRoadPart();
            }
        }

        private void GenerateRoad()
        {
            var newRoad = _roadsPool.Get();
            newRoad.ResetObject();
            newRoad.FillEnvironment(_townEnvironmentsPool);
            newRoad.transform.position = _pointToSpawnNewRoad;
            _pointToSpawnNewRoad = newRoad.roadEndPoint.position;
            _inSceneRoadQueue.Add(newRoad);
        }

        private void GenerateCrossroad()
        {
            var newCrossroad = _crossroadPool.Get();
            newCrossroad._spawner = this;
            newCrossroad.CreateTurns(_crossroadsTurnRoadsPool);
            newCrossroad.CreateEnvironment(_crossroadTownEnvironmentsPool);
            newCrossroad.transform.position = _pointToSpawnNewRoad;
            _pointToSpawnNewRoad = newCrossroad.crossroadEndPoint.position;
            _inSceneCrossroadQueue.Add(newCrossroad);
        }

        public void GenerateNewRoadPart()
        {
            GenerateRoad();
            GenerateCrossroad();
        }

        public void DeleteFirstRoadPart()
        {
            _inSceneCrossroadQueue[0].gameObject.SetActive(false);
            _inSceneRoadQueue[0].gameObject.SetActive(false);
        
            _inSceneCrossroadQueue.Remove(_inSceneCrossroadQueue[0]);
            _inSceneRoadQueue.Remove(_inSceneRoadQueue[0]);
        }
    }
}