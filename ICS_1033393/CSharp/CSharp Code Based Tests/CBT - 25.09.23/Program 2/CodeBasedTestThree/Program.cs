using System;


namespace CodeBasedTestThree
{
    public class Box
    {
        static double toBeAdded;
        public double Len { get; set; }
        public double Brd { get; set; }
        public Box(double length, double breadth)
        {
            Len = length;
        }
        public Box(double breadth)
        {
            Brd = breadth;
        }
        public static Box AddBoxes(Box box1, Box box2)
        {
            toBeAdded = box1.Len + box2.Brd;

            return new Box(toBeAdded);
        }
        public void DisplayDetails()
        {
            Console.WriteLine($"\nWhen Added: {toBeAdded}");
        }
    }


    class Testing
    {
        static void Main()
        {
            Console.Write("Length: ");
            double l = double.Parse(Console.ReadLine());
            Console.Write("Breadth: ");
            double b = double.Parse(Console.ReadLine());
            Box boxOne = new Box(l,b);
            Box boxTwo = new Box(b);
            Box box3 = Box.AddBoxes(boxOne, boxTwo);
            box3.DisplayDetails();
            Console.Read();
        }
    }
}