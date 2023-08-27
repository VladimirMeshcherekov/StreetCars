using CustomPool;
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
        private CustomPool<Road> _roadPool;
        private EnvironmentSpawner _environmentSpawner;

       [Inject]
        private void Construct(EnvironmentSpawner environmentSpawner)
        {
            print(123);
           _environmentSpawner = environmentSpawner;
        }

        public void CreateTurns(CustomPool<Road> roadPool)
        {
            _roadPool = roadPool;
            for (int i = 0; i < turnsDirection.Length; i++)
            {
                var newRoad = _roadPool.Get();
                newRoad.ResetObject();
                newRoad.transform.SetParent(this.transform);
                newRoad.transform.localPosition = turnsDirection[i].localPosition;
                newRoad.transform.forward = turnsDirection[i].forward;
            }
        }

        public void CreateEnvironment(CustomPool<Environment> pool)
        {
            for (int i = 0; i < environmentPlaceholder.Length; i++)
            {
                var env = pool.Get();
                env.transform.SetParent(this.transform);
                env.transform.position = environmentPlaceholder[i].transform.position;
                env.transform.rotation = environmentPlaceholder[i].transform.rotation;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent(out Player player))
            {
                _environmentSpawner.GenerateNewRoadPart();
                _environmentSpawner.DeleteFirstRoadPart();
            }
        }
    }
}