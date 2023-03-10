using System;
using System.IO;

namespace PZLab1
{
    class Program
    {
        static void Main(string[] args)
        {
            string mode;

            Console.WriteLine("Enter '1' for console input, or '2' for file input");
            mode = Console.ReadLine();
            while (mode != "1" && mode != "2")
            {
                Console.WriteLine("Enter '1' for console input, or '2' for file input");
                mode = Console.ReadLine();
            }
            if(mode == "1")
            {
                ConsolMultipliersInputSolving consolMultipliersInputSolving = new ConsolMultipliersInputSolving();
                consolMultipliersInputSolving.MultipliersInput();
                consolMultipliersInputSolving.equationSolving();
            }
            if(mode == "2")
            {
                string path;
                Console.WriteLine("Enter a path to file");
                path = Console.ReadLine();

                FileMultipliersInputSolving fileMultipliersInputSolving = new FileMultipliersInputSolving();
                fileMultipliersInputSolving.MultipliersInput(path);
                fileMultipliersInputSolving.equationSolving();
            }
        }
    }

    class QuadraticEquation
    {
        public QuadraticEquation(EquationMultipliers equationMultipliers)
        {
            this.multipliers = equationMultipliers;
        }

        private string solution;

        private EquationMultipliers multipliers;
        public void printSolution()
        {
            Console.WriteLine(this.solution);
        }

        public void findSolution()
        {
            double a = this.multipliers.a;
            double b = this.multipliers.b;
            double c = this.multipliers.c;

            this.solution = "Equation is: (" + a.ToString("F1") + ") x ^ 2 + (" 
                + b.ToString("F1") + ") x + ("
                + c.ToString("F1") + ") \n";

            double d = b * b - 4 * a * c;

            if(d < 0)
            {
                this.solution += "There are 0 roots";
            }
            else if(d == 0)
            {
                double x1 = -b / (2 * a);
                this.solution += "There are 1 roots \nx1 = "
                    + x1.ToString("F1");
            }
            else
            {
                double x1 = (-b + Math.Sqrt(d)) / (2 * a);
                double x2 = (-b - Math.Sqrt(d)) / (2 * a);
                this.solution += "There are 2 roots \nx1 = "
                    + x1.ToString("F1") + "\nx2 = "
                    + x2.ToString("F1");
            }
        }

    }

    class ConsolMultipliersInputSolving
    {
        private EquationMultipliers multipliers;
        public void MultipliersInput()
        {
            double a;
            string aString;
            double b;
            string bString;
            double c;
            string cString;

            Console.Write("a = ");
            aString = Console.ReadLine();

            while (!Double.TryParse(aString, out a) || a == 0)
            {
                Console.WriteLine("Error. Expected a valid real number, got " + aString + " instead");
                Console.Write("a = ");
                aString = Console.ReadLine();
            }

            Console.Write("b = ");
            bString = Console.ReadLine();

            while (!Double.TryParse(bString, out b))
            {
                Console.WriteLine("Error. Expected a valid real number, got " + bString + " instead");
                Console.Write("b = ");
                bString = Console.ReadLine();
            }

            Console.Write("c = ");
            cString = Console.ReadLine();

            while (!Double.TryParse(cString, out c))
            {
                Console.WriteLine("Error. Expected a valid real number, got " + cString + " instead");
                Console.Write("c = ");
                cString = Console.ReadLine();
            }

            this.multipliers = new EquationMultipliers(a, b, c);
        }

        public void equationSolving()
        {
            QuadraticEquation quadraticEquation = new QuadraticEquation(multipliers);
            quadraticEquation.findSolution();
            quadraticEquation.printSolution();
        }
    }

    class FileMultipliersInputSolving
    {
        private EquationMultipliers multipliers;

        public int MultipliersInput(string path)
        {
            //path = @"C:\Users\user\source\repos\PZLab1\mults.txt";
            FileInfo fileInfo = new FileInfo(path);

            if (!fileInfo.Exists)
            {
                Console.WriteLine("File " + path + " does not exist");
                throw new FileNotFoundException("file does not exist", path);
            }

            string inputString = File.ReadAllText(path);

            double a;
            string aString = "";
            double b;
            string bString = "";
            double c;
            string cString = "";

            int i = 0;
            while(i < 100)
            {
                aString += inputString[i];
                if(inputString[i++] == ' ')
                {
                    break;
                }
            }

            while (i < 100)
            {
                bString += inputString[i];
                if (inputString[i++] == ' ')
                {
                    break;
                }
            }

            while (i < 100)
            {
                cString += inputString[i];
                if (inputString[i++] == '\n')
                {
                    break;
                }
            }

            if(!Double.TryParse(aString, out a) || !Double.TryParse(bString, out b) || !Double.TryParse(cString, out c))
            {
                Console.WriteLine("Invalid file format");
                throw new ArgumentException("Invalid file format.");
            }

            if(a == 0)
            {
                Console.WriteLine("Error. a cannot be 0");
                throw new ArgumentException("Error. a cannot be 0.");
            }

            this.multipliers = new EquationMultipliers(a, b, c);

            return 0;
        }
        public void equationSolving()
        {
            QuadraticEquation quadraticEquation = new QuadraticEquation(multipliers);
            quadraticEquation.findSolution();
            quadraticEquation.printSolution();
        }
    }

    struct EquationMultipliers
    {
        public double a;
        public double b;
        public double c;

        public EquationMultipliers(double _a, double _b, double _c)
        {
            this.a = _a;
            this.b = _b;
            this.c = _c;
        }
    }
}
