using Reflex.Core;
using UnityEngine;

namespace Source.Scripts.ReflexTesting
{
    public class LoadingSceneInstaller : MonoBehaviour , IInstaller
    {
        public Container Container { get; private set; }
        
        public void InstallBindings(ContainerDescriptor descriptor)
        {
            descriptor.AddInstance("World");
            descriptor.AddSingleton(typeof(LoadingScene), typeof(IStartable));
            Container = descriptor.Build();
        }
    }
}