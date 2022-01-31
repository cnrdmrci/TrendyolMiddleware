namespace SampleApi.Services;

public class TestService : ITestService
{
    public string GetTestMessage()
    {
        return "Test message";
    }
}