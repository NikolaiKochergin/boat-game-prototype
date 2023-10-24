namespace Source.Scripts.ReflexTesting
{
    public class TestableNonMono
    {
        private readonly TestService _testService;

        public TestableNonMono(TestService testService)
        {
            _testService = testService;
            _testService.DoSomethingFrom("Testable non mono from constructor");
        }

        public void AnotherFuckupCall()
        {
            _testService.DoSomethingFrom("Testable non mono from another fuckup mono call");
        }
    }
}