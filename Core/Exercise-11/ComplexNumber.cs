using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise_11
{
    class ComplexNumber
    {
        private double real;
        private double imaginary;

        public ComplexNumber(double real, double imaginary)
        {
            this.real = real;
            this.imaginary = imaginary;
        }

        public void Display()
        {
            Console.WriteLine($"{String.Format("D2", real)} + {String.Format("D2", imaginary)}i");
        }

        public void Add(ComplexNumber complexNumber)
        {
            real += complexNumber.real;
            imaginary += complexNumber.imaginary;
        }

        public void Substract(ComplexNumber complexNumber)
        {
            real -= complexNumber.real;
            imaginary -= complexNumber.imaginary;
        }

        public void Multiply(ComplexNumber complexNumber)
        {
            real *= complexNumber.real;
            imaginary *= complexNumber.imaginary;
        }

        public void Inc()
        {
            real++;
        }
    }
}
