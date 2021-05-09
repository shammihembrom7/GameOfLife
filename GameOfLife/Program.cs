using System;
using System.Collections.Generic;

namespace GameOfLife
{
    class Cell
    {
        public bool is_alive;
        public int x,y;
    }

    class Program
    {
        List<int> current_cell_coords;
        List<Cell> alive_cells;
        List<Cell> dead_cells;

        static void Main(string[] args)
        {
            Program p = new Program();
            p.current_cell_coords = new List<int>();
            p.alive_cells = new List<Cell>();
            p.dead_cells = new List<Cell>();

            p.RecieveInput(Console.ReadLine());
            Console.WriteLine(p.alive_cells.Count);
            foreach (Cell cell in p.alive_cells) Console.WriteLine(cell.x + ", " + cell.y);
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
                cell.x = current_cell_coords[0];
                cell.y = current_cell_coords[1];

                alive_cells.Add(cell);
            }
            else
            {
                Console.WriteLine("'INCORRECT INPUT' : enter co ordinates of the alive cell in (X, Y) format example '2, 3' and then press ENTER");
            }
            
            current_cell_coords.Clear();
            RecieveInput(Console.ReadLine());
        }
    }
}
