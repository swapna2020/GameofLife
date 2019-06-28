using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{

    public class LifeSimulation
    {
        private readonly int Height;
        private readonly int Width;
        private readonly bool[,] cells;

        private void GenerateField()
        {
            Random generator = new Random();
            int number;
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    number = generator.Next(2);
                    cells[i, j] = ((number == 0) ? false : true);
                }
            }
        }
        public LifeSimulation(int Height, int Width)
        {
            this.Height = Height;
            this.Width = Width;
            cells = new bool[Height, Width];
            GenerateField();
        }
                     
        public void DrawAndGrow()
        {
            DrawGame();
            Grow();
        }

        private void DrawGame()
        {


            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    Console.Write(cells[i, j] ? "o" : " ");
                    if (j == Width - 1) Console.WriteLine("\r");
                }
            }
            Console.SetCursorPosition(0, Console.WindowTop);
        }
       

        private void Grow()
        {
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    int numOfAliveNeighbours = GetNeighbours(i, j);

                    if (cells[i, j])
                    {
                        if (numOfAliveNeighbours < 2)
                        {
                            cells[i, j] = false;
                        }

                        if (numOfAliveNeighbours > 3)
                        {
                            cells[i, j] = false;
                        }
                    }
                    else
                    {
                        if (numOfAliveNeighbours == 2)
                        {
                            cells[i, j] = true;
                        }
                        if (numOfAliveNeighbours == 3)
                        {
                            cells[i, j] = true;
                        }
                    }
                }
            }
        }

         
        private int GetNeighbours(int x, int y)
        {
            int NumOfAliveNeighbours = 0;

            for (int i = x - 1; i < x + 2; i++)
            {
                for (int j = y - 1; j < y + 2; j++)
                {
                    if (!((i < 0 || j < 0) || (i >= Height || j >= Width)))
                    {
                        if (cells[i, j] == true) NumOfAliveNeighbours++;
                    }
                }
            }
            return NumOfAliveNeighbours--;
        }

      }

    class Program
    {

      
        private const int Height = 20;
        private const int Width = 30;
        private const uint MaxRuns = 100;

        private static void Main(string[] args)
        {
           
            int runs = 0;
            LifeSimulation sim = new LifeSimulation(Height, Width);

            while (runs++ < MaxRuns)
            {
                sim.DrawAndGrow();

                System.Threading.Thread.Sleep(500);
            }
            
        }
        
    }
}