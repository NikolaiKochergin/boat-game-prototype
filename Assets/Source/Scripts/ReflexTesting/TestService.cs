using UnityEngine;

namespace Source.Scripts.ReflexTesting
{
    public class TestService
    {
        public TestService()
        {
            Debug.Log("Test service is created");
        }

        public void DoSomethingFrom(string source)
        {
            
            Debug.Log("Do something " + source);
        }
    }
}