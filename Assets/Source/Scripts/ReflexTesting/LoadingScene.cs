using System.Collections.Generic;
using Reflex.Core;
using UnityEngine;

namespace Source.Scripts.ReflexTesting
{
    public class LoadingScene : IStartable
    {
        public LoadingScene(IEnumerable<string> strings)
        {
            Debug.Log(string.Join(" ", strings));
        }
        
        public void Start()
        {
        }
    }
}