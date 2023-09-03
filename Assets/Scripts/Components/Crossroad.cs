using Generate_Environment;
using UnityEngine;
using Zenject;

namespace Components
{
    public class Crossroad : MonoBehaviour
    {
        public Transform crossroadEndPoint;
        [SerializeField] private Transform[] turnsDirection;
        [SerializeField] private Transform[] environmentPlaceholder;
        private LevelGenerator _levelGenerator;

       [Inject]
        private void Construct(LevelGenerator levelGenerator)
        {
            _levelGenerator = levelGenerator;
        }

        public void CreateTurns(RoadsPoolController townEnvironmentPoolController)
        {
            for (int i = 0; i < turnsDirection.Length; i++)
            {
                var newRoad = townEnvironmentPoolController.GetCrossroadsTurnRoad();
                newRoad.ResetObject();
                newRoad.transform.SetParent(this.transform);
                newRoad.transform.localPosition = turnsDirection[i].localPosition;
                newRoad.transform.forward = turnsDirection[i].forward;
            }
        }

        public void CreateEnvironment(TownEnvironmentPoolController townEnvironmentPoolController)
        {
            for (int i = 0; i < environmentPlaceholder.Length; i++)
            {
                var env = townEnvironmentPoolController.GetCrossroadTownEnvironments();
                env.transform.SetParent(this.transform);
                env.transform.position = environmentPlaceholder[i].transform.position;
                env.transform.rotation = environmentPlaceholder[i].transform.rotation;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent(out PlayerCollider player))
            {
                _levelGenerator.GenerateNewRoadPart();
                _levelGenerator.DeleteFirstRoadPart();
            }
        }
    }
}