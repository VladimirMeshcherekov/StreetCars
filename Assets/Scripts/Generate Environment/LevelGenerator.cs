using System.Collections.Generic;
using Components;
using NPC;
using UnityEngine;
using UnityEngine.Serialization;

namespace Generate_Environment
{
    public class LevelGenerator : MonoBehaviour
    {
        [SerializeField] private TownEnvironmentPoolController townEnvironmentPoolController;
        [SerializeField] private RoadsPoolController roadsPoolController;
        [SerializeField] private NpcPoolController npcPoolController;
        [Space] 
        [SerializeField] private int roadPartToSpawnInStart;
        
        private List<Road> _inSceneRoadQueue = new List<Road>();
        private List<Crossroad> _inSceneCrossroadQueue = new List<Crossroad>();
        private Vector3 _pointToSpawnNewRoad;

        private void Start()
        {
            _pointToSpawnNewRoad = Vector3.zero;
            
            townEnvironmentPoolController.Init();
            roadsPoolController.Init();
            npcPoolController.Init();

            for (var i = 0; i < roadPartToSpawnInStart; i++)
            {
                GenerateNewRoadPart();
            }
        }

        private void GenerateRoad()
        {
            var newRoad = roadsPoolController.GetRoad();
            newRoad.ResetObject();
            newRoad.FillEnvironment(townEnvironmentPoolController);
            newRoad.FillNpcCars(npcPoolController);
            newRoad.transform.position = _pointToSpawnNewRoad;
            _pointToSpawnNewRoad = newRoad.roadEndPoint.position;
            _inSceneRoadQueue.Add(newRoad);
        }

        private void GenerateCrossroad()
        {
            var newCrossroad = roadsPoolController.GetCrossroad();
            newCrossroad.CreateTurns(roadsPoolController);
            newCrossroad.CreateEnvironment(townEnvironmentPoolController);
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