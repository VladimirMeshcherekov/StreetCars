using Generate_Environment;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class LevelGenerationInstaller : MonoInstaller
    {
        [SerializeField] private LevelGenerator levelGenerator;
        public override void InstallBindings()
        {
            Container.BindInstance(levelGenerator).AsSingle();
        }
    }
}