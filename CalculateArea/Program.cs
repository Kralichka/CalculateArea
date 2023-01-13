using System;

namespace CalculateArea
{
    class Program
    {      
        /// <summary>
        /// Types of figures, for which you can calculate area.
        /// </summary>
        public enum FigureType
        {
            Exit = 0,
            Circle = 1,
            Triangle = 2
        }

        public static void Main(string[] args)
        {
            FigureType figureType;
            while ((figureType = GetFigureType()) != FigureType.Exit)
            {
                ICalculateArea shape = null;

                switch (figureType)
                {
                    case FigureType.Triangle:
                        shape = CreateTriangle();
                        break;
                    case FigureType.Circle:
                        shape = CreateCircle();
                        break;
                    default:
                        break;
                }

                Console.WriteLine("The area of the {0} is {1}", figureType, shape.Area);    
                
                if(shape is Triangle triangle && triangle.IsCheckForRightCanExecute == true)
                {
                    if(triangle.IsTriangleRight())
                        Console.WriteLine("And triangle is right.");
                    else
                        Console.WriteLine("And triangle is not right.");
                }

                Console.WriteLine();
            }

            Console.ReadKey(true);
        }

        /// <summary>
        /// Returns a type of shape for which area will be calculated.
        /// </summary>
        /// <returns>FigureType.</returns>
        public static FigureType GetFigureType()
        {
            Console.WriteLine("Choose what shape you would like to calculate the area for:");
            Console.WriteLine("\t{0} - Exit", (int)FigureType.Exit);
            Console.WriteLine("\t{0} - Circle", (int)FigureType.Circle);
            Console.WriteLine("\t{0} - Triangle", (int)FigureType.Triangle);
            Console.Write("Enter name or value: ");
            string value = Console.ReadLine();

            FigureType choice;
            if (!Enum.TryParse(value, out choice) || !Enum.IsDefined(typeof(FigureType), choice))
            {
                Console.WriteLine("Invalid value, please try again.");
                return GetFigureType();
            }

            return choice;
        }

        /// <summary>
        /// Ask for radius, height, etc. and parse it into a number.
        /// </summary>
        /// <param name="message">What value is needed.</param>
        /// <returns>Value of radius, length of side, etc.</returns>
        private static double GetValue(string message)
        {
            bool isValid = false;
            double value = 0;

            while (!isValid)
            {
                Console.Write(message);
                isValid = double.TryParse(Console.ReadLine(), out value);
                if (!isValid) Console.WriteLine("Invalid number, please try again.");
            }

            return value;
        }

        /// <summary>
        /// Create a triangle with 3 known sides or height and base.
        /// </summary>
        /// <returns>Triangle.</returns>
        private static Triangle CreateTriangle()
        {            
            Console.WriteLine("Do you know all 3 sides of triangle? Enter 'yes' if you do.");
            if (Console.ReadLine().ToLower() == "yes")
            {
                double sideA = GetValue("Side a: ");
                double sideB = GetValue("Side b: ");
                double sideC = GetValue("Side c: ");
                return new Triangle() { SideA = sideA, SideB = sideB, SideC = sideC };
            }
            else
            {                
                Console.WriteLine("Then you should know height and base width.");
                double baseWidth = GetValue("Base Width: ");
                double height = GetValue("Height: ");
                return new Triangle() { BaseWidth = baseWidth, Height = height };
            }
        }

        /// <summary>
        /// Create a circle with known radius.
        /// </summary>
        /// <returns>Circle.</returns>
        private static Circle CreateCircle()
        {
            double radius = GetValue("Radius: ");
            return new Circle() { Radius = radius};
        }

    }

    public interface ICalculateArea
    {
        double Area { get; }

        public double CalcArea()
        {
            return 0;
        }
    }

    public class Triangle : ICalculateArea
    {
        public double Area
        {
            get
            {
                if (Height != 0 && BaseWidth != 0)
                {
                    IsCheckForRightCanExecute = false;
                    return Math.Round(BaseWidth * Height / 2, 2);
                }
                else if (SideA != 0 && SideB != 0 && SideC != 0)
                {
                    IsCheckForRightCanExecute = true;
                    double s = (SideA + SideB + SideC) / 2;
                    return Math.Round(Math.Sqrt(s * (s - SideA) * (s - SideB) * (s - SideC)), 2);
                }
                else
                    return 0;
            }
        }

        public double BaseWidth { get; set; }
        public double Height { get; set; }
        public double SideA { get; set; }
        public double SideB { get; set; }
        public double SideC { get; set; }

        public bool IsCheckForRightCanExecute { get; private set; } = false;

        public bool IsTriangleRight()
        {
            bool isRight = false;
            if (SideA > SideB && SideA > SideC)
                isRight = Math.Pow(SideA, 2) == Math.Pow(SideB, 2) + Math.Pow(SideC, 2) ? true : false;
            if (SideB > SideA && SideB > SideC)
                isRight = Math.Pow(SideB, 2) == Math.Pow(SideA, 2) + Math.Pow(SideC, 2) ? true : false;
            if (SideC > SideB && SideC > SideA)
                isRight = Math.Pow(SideC, 2) == Math.Pow(SideB, 2) + Math.Pow(SideA, 2) ? true : false;

            return isRight;
        }

    }

    public class Circle : ICalculateArea
    {
        public double Area { get { return Math.Round(Math.PI * Math.Pow(Radius, 2), 2); } }

        public double Radius { get; set; }

    }
}
