using System;

// Abstraction
abstract class Fruit
{
    protected IEatingMethod eatingMethod;

    public Fruit(IEatingMethod method)
    {
        this.eatingMethod = method;
    }

    public abstract void Eat();
}

// Implementation
interface IEatingMethod
{
    void Eat();
}

class BiteEating : IEatingMethod
{
    public void Eat()
    {
        Console.WriteLine("Biting the fruit.");
    }
}

class CutEating : IEatingMethod
{
    public void Eat()
    {
        Console.WriteLine("Cutting and eating the fruit.");
    }
}

// Concrete Fruits
class Apple : Fruit
{
    public Apple(IEatingMethod method) : base(method)
    {
    }

    public override void Eat()
    {
        Console.Write("Eating an Apple by ");
        eatingMethod.Eat();
    }
}

class Banana : Fruit
{
    public Banana(IEatingMethod method) : base(method)
    {
    }

    public override void Eat()
    {
        Console.Write("Eating a Banana by ");
        eatingMethod.Eat();
    }
}

class Program
{
    static void Main(string[] args)
    {
        IEatingMethod biteMethod = new BiteEating();
        IEatingMethod cutMethod = new CutEating();

        Fruit apple = new Apple(biteMethod);
        Fruit banana = new Banana(cutMethod);

        apple.Eat(); // Output: Eating an Apple by Biting the fruit.
        banana.Eat(); // Output: Eating a Banana by Cutting and eating the fruit.
    }
}
