using System;

namespace HighLevelProgramming
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var yarden = new Student();

            yarden.Name = "Yarden";
            yarden.ComputerGrade = 100;
            yarden.DadName = "Gidy";
            yarden.MathGrade = 55;
        }
    }
}