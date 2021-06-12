using System;

namespace bakejoon_1012
{
    public class Program
    {
        static void Main(string[] args)
        {

            var firstLine = Console.ReadLine();
            var testCaseCount = Convert.ToInt32(firstLine);

            for (int i = 0; i < testCaseCount; i++)
            {
                var secondLine = Console.ReadLine();
                var secondLineArray = secondLine.Split(' ');


                var fieldWidth = Convert.ToInt32(secondLineArray[0]);
                var fieldHegiht = Convert.ToInt32(secondLineArray[1]);
                var cabageCount = Convert.ToInt32(secondLineArray[2]);

                var cabageFieldMap = new bool[fieldWidth, fieldHegiht];
                for (int j = 0; j < cabageCount; j++)
                {
                    var thisLine = Console.ReadLine();
                    var thisLineArray = thisLine.Split(' ');

                    var positionX = Convert.ToInt32(thisLineArray[0]);
                    var positionY = Convert.ToInt32(thisLineArray[1]);

                    cabageFieldMap[positionX, positionY] = true;

                }
                var solver = new Solver();
                var answer = solver.Solve(cabageFieldMap);

                Console.WriteLine(answer);
            }


        }
    }


    public class Solver
    {
        bool[,] cabageField;
        public int Solve(bool[,] field)
        {
            int resultCount = 0;
            this.cabageField = field;
            for (int i = 0; i < cabageField.GetLength(0); i++)
            {
                for (int j = 0; j < cabageField.GetLength(1); j++)
                {
                    if (cabageField[i, j] == true)
                    {
                        SearchDepthFirstly(i, j);
                        resultCount++;
                    }
                }
            }
            return resultCount;
        }

        void SearchDepthFirstly(int x, int y)
        {
            if (cabageField[x, y] == true)
            {
                cabageField[x, y] = false;
                if (x + 1 < cabageField.GetLength(0))
                {
                    SearchDepthFirstly(x + 1, y);
                }
                if (x - 1 >= 0)
                {
                    SearchDepthFirstly(x - 1, y);
                }
                if (y + 1 < cabageField.GetLength(1))
                {
                    SearchDepthFirstly(x, y + 1);
                }
                if (y - 1 >= 0)
                {
                    SearchDepthFirstly(x, y - 1);
                }
            }
        }
    }
}