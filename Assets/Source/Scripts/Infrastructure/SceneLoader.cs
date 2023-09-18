using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Source.Scripts.Infrastructure
{
    public class SceneLoader
    {
        public void Load(string nextScene, Action onLoaded = null) => 
            Coroutines.StartRoutine(LoadScene(nextScene, onLoaded));

        private IEnumerator LoadScene(string name, Action onLoaded)
        {
            if (SceneManager.GetActiveScene().name == name)
            {
                onLoaded?.Invoke();
                yield break;
            }

            AsyncOperation waitNextScene = SceneManager.LoadSceneAsync(name);

            while (!waitNextScene.isDone)
                yield return null;
            
            onLoaded?.Invoke();
        }
    }
}