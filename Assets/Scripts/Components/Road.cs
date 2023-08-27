using CustomPool;
using UnityEngine;

namespace Components
{
   public class Road : MonoBehaviour
   {
      [SerializeField] private Transform[] environmentPlaceHolder;
      public Transform roadEndPoint;

      private CustomPool<Environment> _environmentPool;
      public void ResetObject()
      {
         transform.SetParent(null);
         transform.position = Vector3.zero;
         transform.rotation = Quaternion.identity;
      }

      public void FillEnvironment(CustomPool<Environment> environmentPool)
      {
         _environmentPool = environmentPool;
         
         for (int i = 0; i < environmentPlaceHolder.Length; i++)
         {
            var newEnvironment = environmentPool.Get();
            newEnvironment.transform.SetParent(environmentPlaceHolder[i]);
            newEnvironment.transform.position = environmentPlaceHolder[i].position;
            newEnvironment.transform.rotation = environmentPlaceHolder[i].rotation;
         }
      }
   }
}
