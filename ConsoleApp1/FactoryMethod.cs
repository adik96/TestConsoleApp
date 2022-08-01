using System;

namespace DesignPatternsSamples;

public static class TestFactoryMethod
{
    public static void TestFM()
    {
        var creators = new List<ChairCreator>() { new WhiteChairCreator(), new BlackChairCreator() };
        var whiteChair = creators[0].Create_FactoryMethod();
        var blackChair = creators[1].Create_FactoryMethod();
    }
}



public abstract class Chair
{

}

public class WhiteChair : Chair
{

}

public class BlackChair : Chair
{

}


public abstract class ChairCreator
{
    public ChairCreator() {}
    public abstract Chair Create_FactoryMethod();
    
}

public class WhiteChairCreator :  ChairCreator
{
    public WhiteChairCreator() { }
    public override Chair Create_FactoryMethod()
    {
        Console.WriteLine("white chair");
        return new WhiteChair();
    }
}

public class BlackChairCreator : ChairCreator
{
    public BlackChairCreator() { }
    public override Chair Create_FactoryMethod()
    {
        Console.WriteLine("black chair");
        return new BlackChair();
    }
}


public class Client
{
    private ITarget target;

    public Client(ITarget target)
    {
        this.target = target;
    }

    public IEnumerable<string> MakeRequest()
    {
        return target.Method_Adaptujaca(new List<int> { 1, 2, 3, 4 });
    }
}

public interface ITarget
{
    IEnumerable<string> Method_Adaptujaca(List<int> intList);
}

public class Adapter : Adaptee, ITarget
{
    public IEnumerable<string> Method_Adaptujaca(List<int> intList)
    {
        return Method_Adaptowana(intList);
    }
}

public class Adaptee
{
    public IEnumerable<string> Method_Adaptowana(List<int> intList)
    {
        return intList.Select(x => x.ToString("F2", System.Globalization.CultureInfo.InvariantCulture));
    }
}


//////ADAPTER////////////////
public class Facade
{
    public Facade(Repository repo, MyConverter conv)
    {
        repository = repo;
        converter = conv;
    }
    
    private Repository repository;
    private MyConverter converter;

    public string DoSmthConnectedWithTwoSubsystems()
    {
        var result = "Facade result";
        result += repository.operation1();
        result += converter.operationZ();

        return result;
    }
}
public class Repository
{
    public string operation1()
    {
        return "Subsystem1: Ready!\n";
    }

    public string operationN()
    {
        return "Subsystem1: Go!\n";
    }
}

// Some facades can work with multiple subsystems at the same time.
public class MyConverter
{
    public string operation1()
    {
        return "Subsystem2: Get ready!\n";
    }

    public string operationZ()
    {
        return "Subsystem2: Fire!\n";
    }
}
