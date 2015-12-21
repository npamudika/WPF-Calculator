using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Model
{
    /// <summary>
    /// Model class for the Calculator with Business Logic
    /// </summary>
    class CalculatorModel
    {
        public int Add(int firstNumber, int secondNumber)
        {
            return firstNumber + secondNumber;
        }
        public int Sub(int firstNumber, int secondNumber)
        {
            return firstNumber - secondNumber;
        }
        public int Mul(int firstNumber, int secondNumber)
        {
            return firstNumber * secondNumber;
        }
        public int Div(int firstNumber, int secondNumber)
        {
            return firstNumber / secondNumber;
        }
    }
}
