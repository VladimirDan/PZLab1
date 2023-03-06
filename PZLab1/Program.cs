using System;

namespace PZLab1
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }
    }

    class QuadraticEquation
    {
        public QuadraticEquation(EquationMultipliers equationMultipliers)
        {
            this.multipliers = equationMultipliers;
        }

        protected string solution;

        protected EquationMultipliers multipliers;
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

    struct EquationMultipliers
    {
        public double a;
        public double b;
        public double c;

        public EquationMultipliers(int _a, int _b, int _c)
        {
            this.a = _a;
            this.b = _b;
            this.c = _c;
        }
    }
}
