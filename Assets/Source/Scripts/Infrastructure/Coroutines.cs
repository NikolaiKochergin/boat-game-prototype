using System.Collections;
using UnityEngine;

namespace Source.Scripts.Infrastructure
{
    public class Coroutines : MonoBehaviour
    {
        private static Coroutines m_instance;

        private static Coroutines Instance
        {
            get
            {
                if (m_instance == null)
                {
                    GameObject go = new("[COROUTINES]");
                    m_instance = go.AddComponent<Coroutines>();
                    DontDestroyOnLoad(go);
                }

                return m_instance;
            }
        }

        public static Coroutine StartRoutine(IEnumerator enumerator)
        {
            return Instance.StartCoroutine(enumerator);
        }

        public static void StopRoutine(Coroutine routine)
        {
            Instance.StopCoroutine(routine);
        }
    }
}