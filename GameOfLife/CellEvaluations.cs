using System;
using System.Collections.Generic;
using System.Numerics;

namespace GameOfLife
{
    public class CellEvaluations
    {
        public void CheckForAdjacentDeadCells(List<Cell> alive_cells, List<Cell> dead_cells)
        {
            dead_cells.Clear();
            bool already_exist;
            foreach (Cell cell in alive_cells)
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

        }

        public void EvaluateNextGenCells(List<Cell> alive_cells, List<Cell> dead_cells)
        {
            SimulateAliveToDead(alive_cells, dead_cells);
            SimulateDeadToAlive(alive_cells, dead_cells);
        }

        void SimulateAliveToDead(List<Cell> alive_cells, List<Cell> dead_cells)
        {

        }

        void SimulateDeadToAlive(List<Cell> alive_cells, List<Cell> dead_cells)
        {

        }
    }
}