using Expressions_3;

var container = new DependencyContainer();

// Sinflarni ro‘yxatga olish
container.Register<MyInterface, MyClass>();

// Obyektlarni olish
var car = container.Resolve<MyInterface>();
car.DoAnyThing();


public interface MyInterface
{
    void DoAnyThing();
}

public class MyClass : MyInterface
{
    public void DoAnyThing()
    {
        Console.WriteLine("DoAnyThing...");
    }
}