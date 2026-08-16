namespace UnitTestExample.Services
{
    public class ExampleExternalService : IExampleExternalService
    {
        public bool ExampleExternalMethodA()
        {
            //...
            return true;
        }
    }
    public interface IExampleExternalService
    {
        bool ExampleExternalMethodA();
    }

}
