using System;

// Паттерн "Фабричный метод" (Factory Method)
public interface ITransport
{
    void Deliver();
}

public class Truck : ITransport
{
    public void Deliver()
    {
        Console.WriteLine("Delivering by truck");
    }
}

public class Ship : ITransport
{
    public void Deliver()
    {
        Console.WriteLine("Delivering by ship");
    }
}

public abstract class Logistics
{
    public abstract ITransport CreateTransport();

    public void PlanDelivery()
    {
        ITransport transport = CreateTransport();
        transport.Deliver();
    }
}

public class RoadLogistics : Logistics
{
    public override ITransport CreateTransport()
    {
        return new Truck();
    }
}

public class SeaLogistics : Logistics
{
    public override ITransport CreateTransport()
    {
        return new Ship();
    }
}

// Паттерн "Декоратор" (Decorator)
public interface IComponent
{
    void Operation();
}

public class ConcreteComponent : IComponent
{
    public void Operation()
    {
        Console.WriteLine("ConcreteComponent.Operation()");
    }
}

public abstract class Decorator : IComponent
{
    protected IComponent component;

    public Decorator(IComponent component)
    {
        this.component = component;
    }

    public virtual void Operation()
    {
        component.Operation();
    }
}

public class ConcreteDecoratorA : Decorator
{
    public ConcreteDecoratorA(IComponent component) : base(component)
    {
    }

    public override void Operation()
    {
        base.Operation();
        Console.WriteLine("ConcreteDecoratorA.Operation()");
    }
}

public class ConcreteDecoratorB : Decorator
{
    public ConcreteDecoratorB(IComponent component) : base(component)
    {
    }

    public override void Operation()
    {
        base.Operation();
        Console.WriteLine("ConcreteDecoratorB.Operation()");
    }
}

// Паттерн "Наблюдатель" (Observer)
public interface IObserver
{
    void Update();
}

public class ConcreteObserverA : IObserver
{
    public void Update()
    {
        Console.WriteLine("ConcreteObserverA.Update()");
    }
}

public class ConcreteObserverB : IObserver
{
    public void Update()
    {
        Console.WriteLine("ConcreteObserverB.Update()");
    }
}

public class Subject
{
    private readonly List<IObserver> observers = new List<IObserver>();

    public void Attach(IObserver observer)
    {
        observers.Add(observer);
    }

    public void Detach(IObserver observer)
    {
        observers.Remove(observer);
    }

    public void Notify()
    {
        foreach (var observer in observers)
        {
            observer.Update();
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        // Использование паттерна "Фабричный метод"
        Logistics roadLogistics = new RoadLogistics();
        roadLogistics.PlanDelivery();

        Logistics seaLogistics = new SeaLogistics();
        seaLogistics.PlanDelivery();

        // Использование паттерна "Декоратор"
        IComponent component = new ConcreteComponent();
        IComponent decoratedComponent = new ConcreteDecoratorA(new ConcreteDecoratorB(component));
        decoratedComponent.Operation();

        // Использование паттерна "Наблюдатель"
        Subject subject = new Subject();
        IObserver observerA = new ConcreteObserverA();
        IObserver observerB = new ConcreteObserverB();

        subject.Attach(observerA);
        subject.Attach(observerB);

        subject.Notify();

        subject.Detach(observerB);

        subject.Notify();
    }
}
