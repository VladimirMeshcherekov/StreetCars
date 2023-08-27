using CustomPool;
using Generate_Environment;
using UnityEngine;

namespace Components
{
    public class Crossroad : MonoBehaviour
    {
        public Transform crossroadEndPoint;
        [SerializeField] private Transform[] turnsDirection;
        [SerializeField] private Transform[] environmentPlaceholder;
        private CustomPool<Road> _roadPool;
        public Spawner _spawner;

      // [Inject]
        private void Construct(Spawner spawner)
        {
            print(123);
           _spawner = spawner;
        }

        public void CreateTurns(CustomPool<Road> roadPool)
        {
            _roadPool = roadPool;
            for (int i = 0; i < turnsDirection.Length; i++)
            {
                var newRoad = _roadPool.Get();
                newRoad.ResetObject();
                newRoad.transform.SetParent(this.transform);
                newRoad.transform.position = turnsDirection[i].localPosition;
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
                _spawner.GenerateNewRoadPart();
                _spawner.DeleteFirstRoadPart();
            }
        }
    }
}