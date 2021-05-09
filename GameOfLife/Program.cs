using System;
using System.Collections.Generic;
using System.Numerics;

namespace GameOfLife
{
    class Cell
    {
        public bool is_alive;
        public Vector2 coords;
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
            foreach (Cell cell in p.alive_cells) Console.WriteLine(cell.coords.X + ", " + cell.coords.Y);

            p.EvaluteNextGenCells();
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
                Console.WriteLine("'INCORRECT INPUT' : enter co ordinates of the alive cell in (X, Y) format example '2, 3' and then press ENTER");
            }
            
            current_cell_coords.Clear();
            RecieveInput(Console.ReadLine());
        }

        void EvaluteNextGenCells()
        {
            GetCurrentDeadCells();
        }

        void GetCurrentDeadCells()
        {
            dead_cells.Clear();
            bool already_exist;
            foreach(Cell cell in alive_cells)
            {
                //north
                already_exist = false;
                foreach (Cell dead_cell in dead_cells)
                {
                    if (dead_cell.coords == cell.coords + Vector2.UnitY) already_exist = true;
                }
                foreach (Cell dead_cell in alive_cells)
                {
                    if (dead_cell.coords == cell.coords + Vector2.UnitY) already_exist = true;
                }
                if (!already_exist)
                {
                    Cell dead_north = new Cell();
                    dead_north.coords = cell.coords + Vector2.UnitY;
                    dead_cells.Add(dead_north);
                }


                //east
                already_exist = false;
                foreach (Cell dead_cell in dead_cells)
                {
                    if (dead_cell.coords == cell.coords + Vector2.UnitX) already_exist = true;
                }
                foreach (Cell dead_cell in alive_cells)
                {
                    if (dead_cell.coords == cell.coords + Vector2.UnitX) already_exist = true;
                }
                if (!already_exist)
                {
                    Cell dead_east = new Cell();
                    dead_east.coords = cell.coords + Vector2.UnitX;
                    dead_cells.Add(dead_east);
                }

                //south
                already_exist = false;
                foreach (Cell dead_cell in dead_cells)
                {
                    if (dead_cell.coords == cell.coords - Vector2.UnitY) already_exist = true;
                }
                foreach (Cell dead_cell in alive_cells)
                {
                    if (dead_cell.coords == cell.coords - Vector2.UnitY) already_exist = true;
                }
                if (!already_exist)
                {
                    Cell dead_south = new Cell();
                    dead_south.coords = cell.coords - Vector2.UnitY;
                    dead_cells.Add(dead_south);
                }


                //west
                already_exist = false;
                foreach (Cell dead_cell in dead_cells)
                {
                    if (dead_cell.coords == cell.coords - Vector2.UnitX) already_exist = true;
                }
                foreach (Cell dead_cell in alive_cells)
                {
                    if (dead_cell.coords == cell.coords - Vector2.UnitX) already_exist = true;
                }
                if (!already_exist)
                {
                    Cell dead_west = new Cell();
                    dead_west.coords = cell.coords - Vector2.UnitX;
                    dead_cells.Add(dead_west);
                }


                //north_east
                already_exist = false;
                foreach (Cell dead_cell in dead_cells)
                {
                    if (dead_cell.coords == cell.coords + Vector2.One) already_exist = true;
                }
                foreach (Cell dead_cell in alive_cells)
                {
                    if (dead_cell.coords == cell.coords + Vector2.One) already_exist = true;
                }
                if (!already_exist)
                {
                    Cell dead_north_east = new Cell();
                    dead_north_east.coords = cell.coords + Vector2.One;
                    dead_cells.Add(dead_north_east);
                }

                //south_east
                already_exist = false;
                foreach (Cell dead_cell in dead_cells)
                {
                    if (dead_cell.coords == cell.coords + Vector2.UnitX - Vector2.UnitY) already_exist = true;
                }
                foreach (Cell dead_cell in alive_cells)
                {
                    if (dead_cell.coords == cell.coords + Vector2.UnitX - Vector2.UnitY) already_exist = true;
                }
                if (!already_exist)
                {
                    Cell dead_south_east = new Cell();
                    dead_south_east.coords = cell.coords + Vector2.UnitX - Vector2.UnitY;
                    dead_cells.Add(dead_south_east);
                }

                //south_west
                already_exist = false;
                foreach (Cell dead_cell in dead_cells)
                {
                    if (dead_cell.coords == cell.coords - Vector2.One) already_exist = true;
                }
                foreach (Cell dead_cell in alive_cells)
                {
                    if (dead_cell.coords == cell.coords - Vector2.One) already_exist = true;
                }
                if (!already_exist)
                {
                    Cell dead_south_west = new Cell();
                    dead_south_west.coords = cell.coords - Vector2.One;
                    dead_cells.Add(dead_south_west);
                }

                //north_west
                already_exist = false;
                foreach (Cell dead_cell in dead_cells)
                {
                    if (dead_cell.coords == cell.coords - Vector2.UnitX + Vector2.UnitY) already_exist = true;
                }
                foreach (Cell dead_cell in alive_cells)
                {
                    if (dead_cell.coords == cell.coords - Vector2.UnitX + Vector2.UnitY) already_exist = true;
                }
                if (!already_exist)
                {
                    Cell dead_north_west = new Cell();
                    dead_north_west.coords = cell.coords - Vector2.UnitX + Vector2.UnitY;
                    dead_cells.Add(dead_north_west);
                }
            }


            Console.WriteLine("----");
            Console.WriteLine(dead_cells.Count);
            foreach (Cell cell in dead_cells) Console.WriteLine(cell.coords.X + ", " + cell.coords.Y);
        }
    }
}
