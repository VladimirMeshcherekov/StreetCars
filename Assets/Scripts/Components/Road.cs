using CustomPool;
using NPC;
using UnityEngine;
using UnityEngine.Serialization;

namespace Components
{
   public class Road : MonoBehaviour
   {
      [SerializeField] private Transform[] environmentPlaceHolder;
      [SerializeField] private Transform[] npcCarsPlaceHolder;
      public Transform roadEndPoint;
      
      public void ResetObject()
      {
         transform.SetParent(null);
         transform.position = Vector3.zero;
         transform.rotation = Quaternion.identity;
      }

      public void FillEnvironment(CustomPool<Environment> environmentPool)
      {
         foreach (var spawnPoint in environmentPlaceHolder)
         {
            var newEnvironment = environmentPool.Get();
            newEnvironment.transform.SetParent(spawnPoint);
            newEnvironment.transform.position = spawnPoint.position;
            newEnvironment.transform.rotation = spawnPoint.rotation;
         }
      }

      public void FillNpcCars(NpcPoolController npcPoolController)
      {
         foreach (var spawnPoint in npcCarsPlaceHolder)
         {
            var newCar = npcPoolController.TyrGetVehicle();
            newCar.transform.position = spawnPoint.position;
            newCar.transform.rotation = spawnPoint.rotation;
            newCar.transform.SetParent(this.transform);
         }
      }
   }
}
