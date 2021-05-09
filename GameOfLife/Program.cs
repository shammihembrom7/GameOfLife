using System;
using System.Collections.Generic;
using System.Numerics;

namespace GameOfLife
{
    public class Cell
    {
        public bool is_alive;
        public Vector2 coords;
    }

    class Program
    {
        CellEvaluations vector_methods;

        List<int> current_cell_coords;
        List<Cell> alive_cells;
        List<Cell> dead_cells;

        static void Main(string[] args)
        {
            Program p = new Program();
            p.vector_methods = new CellEvaluations();

            p.current_cell_coords = new List<int>();
            p.alive_cells = new List<Cell>();
            p.dead_cells = new List<Cell>();

            p.RecieveInput(Console.ReadLine());

            Console.WriteLine(p.alive_cells.Count);
            foreach (Cell cell in p.alive_cells) Console.WriteLine(cell.coords.X + ", " + cell.coords.Y);

            p.RunSimulation();
        }

        void RecieveInput(string text)
        {
            if (text.Length == 0) return;

            char[] delimiterChars = { ' ', ',', '.', ':', '\t' };
            string[] words = text.Split(delimiterChars);

            int n;
            foreach (string word in words)
            {
                if (int.TryParse(word, out n)) current_cell_coords.Add(n);
            }

            if (current_cell_coords.Count == 2)
            {
                Cell cell = new Cell();
                cell.is_alive = true;
                cell.coords.X = current_cell_coords[0];
                cell.coords.Y = current_cell_coords[1];

                alive_cells.Add(cell);
            }
            else
            {
                Console.WriteLine("'INCORRECT INPUT' : enter coordinates of the alive cell in (X, Y) format example '2, 3' and then press ENTER");
            }
            
            current_cell_coords.Clear();
            RecieveInput(Console.ReadLine());
        }

        void RunSimulation()
        {
            vector_methods.CheckForAdjacentDeadCells(alive_cells, dead_cells);
            Console.WriteLine("----");
            Console.WriteLine(dead_cells.Count);
            foreach (Cell cell in dead_cells) Console.WriteLine(cell.coords.X + ", " + cell.coords.Y);

            vector_methods.EvaluateNextGenCells(alive_cells, dead_cells);

            Console.WriteLine("----Answer-----------------");
            foreach (Cell cell in alive_cells)
            {
                if (cell.is_alive) Console.WriteLine(cell.coords);
            }
            Console.WriteLine("----dead cells count "+ dead_cells.Count);
            foreach (Cell cell in dead_cells)
            {
                if (cell.is_alive) Console.WriteLine(cell.coords);
            }
        }

    }
}
