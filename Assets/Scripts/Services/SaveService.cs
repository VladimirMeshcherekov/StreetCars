using System.IO;
using UnityEngine;

namespace Services
{
    public class SaveService<T>
    {
        private T _saveDataStruct;
        private readonly string _saveFIlePath;
        
        public SaveService(string saveFIlePath)
        {
            _saveFIlePath = saveFIlePath;
        }

        public T LoadFromFile<T>()
        {
            if (!File.Exists(_saveFIlePath))
            {
                SaveToFile(_saveDataStruct);
            }

            var json = File.ReadAllText(_saveFIlePath);
            return JsonUtility.FromJson<T>(json);
        }
        
        public void SaveToFile<T>(T saveDataStruct)
        {
            var json = JsonUtility.ToJson(saveDataStruct);
            File.WriteAllText(_saveFIlePath, json);
        }
        
    }
}
