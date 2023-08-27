using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CustomPool
{
    public class CustomPool<T> where T : MonoBehaviour
    {
        private T[] _prefabs;
        private List<T> _objects;

        public CustomPool(T[] prefabs, int prewarmObjects)
        {
            _prefabs = prefabs;
            _objects = new List<T>();

            for (int i = 0; i < prewarmObjects; i++)
            {
                var obj = GameObject.Instantiate(_prefabs[Random.Range(0, _prefabs.Length)]);
                obj.gameObject.SetActive(false);
                _objects.Add(obj);
            }
        }

        public T Get()
        {
            var obj = _objects.FirstOrDefault(x => !x.isActiveAndEnabled);

            if (obj == null)
            {
                obj = Create();
            }

            obj.gameObject.SetActive(true);
            return obj;
        }

        public void Release(T obj)
        {
            obj.gameObject.SetActive(false);
        }

        private T Create()
        {
            var obj = GameObject.Instantiate(_prefabs[Random.Range(0, _prefabs.Length)]);
            _objects.Add(obj);
            return obj;
        }
    }
}