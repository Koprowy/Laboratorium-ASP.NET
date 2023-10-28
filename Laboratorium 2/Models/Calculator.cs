using System.Numerics;

namespace Laboratorium_2.Models
{ 
    public enum Operators
    {
        Unknown, Add, Mul, Sub, Div
    }
    public class Calculator
    {
        public Operators? Operator { get; set; }
        public double? X { get; set; }
        public double? Y { get; set; }

        public String Op
        {
            get
            {
                switch (Operator)
                {
                    case Operators.Add:
                        return "+";
                    case Operators.Mul:
                        return "*";
                    case Operators.Div:
                        return "/";
                    case Operators.Sub:
                        return "-";
                    case Operators.Unknown:
                        return "?";
                default:
                        return "";
                }
            }
        }

        public bool IsValid()
        {
            return Operator != null && X != null && Y != null;
        }

        public double Calculate()
        {
            switch (Operator)
            {
                case Operators.Add:
                    return (double)(X + Y);
                case Operators.Sub:
                    return (double)(X - Y);
                case Operators.Mul: 
                    return (double)(X * Y);
                case Operators.Div:
                //sprawdzam czy y nie jest zerem
                return Y != 0 ? (double)(X / Y) : double.NaN;
            default: return double.NaN;

            }
        }
    }
}
