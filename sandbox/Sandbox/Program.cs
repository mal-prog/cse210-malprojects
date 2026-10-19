class Program
{
    static void Main()
    {

        int x = 10;

        Console.WriteLine("Hello Circle");

        Circle myCircle = new Circle(10);
        myCircle.SetRadius(10);
        
        double area = myCircle.GetArea();
        
        Console.WriteLine(area); 
    }
}