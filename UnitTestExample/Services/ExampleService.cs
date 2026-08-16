using UnitTestExample.Entities;

namespace UnitTestExample.Services;

public class ExampleService(IExampleExternalService _service)
{
    public string ExampleMethodA()
    {
        //...
        return "Success: Code Executed!";
    }
    public int ExampleMethodB(int numberA, int numberB)
    {
        //...
        return numberA + numberB;
    }
    public DateTime ExampleMethodC()
    {
        //...
        return DateTime.Now;
    }
    public ExampleEntity ExampleMethodD()
    {
        //...
        return new()
        {
            Text = "Hello",
            Number = 10
        };
    }
    public ExampleEntity[] ExampleMethodE()
    {
        //...
        return new[]{
            new ExampleEntity() {
                Text = "Hello1",
                Number = 11
            },
            new ExampleEntity() {
                Text = "Hello2",
                Number = 12
            }
        };
    }
    public string ExampleMethodF()
    {
        //...
        var result = _service.ExampleExternalMethodA();
        if (result) return "Success: Code Executed";
        else return "Fail: Code Could'n Executed";
    }
}