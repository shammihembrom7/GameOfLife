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
                already_exist = CheckCellsInDirection(cell, Vector2.UnitY, dead_cells);
                if (!already_exist) already_exist = CheckCellsInDirection(cell, Vector2.UnitY, alive_cells);
                if (!already_exist) AddCorrespondingDeadCell(cell, Vector2.UnitY, dead_cells);


                //east
                already_exist = false;
                already_exist = CheckCellsInDirection(cell, Vector2.UnitX, dead_cells);
                if (!already_exist) already_exist = CheckCellsInDirection(cell, Vector2.UnitX, alive_cells);
                if (!already_exist) AddCorrespondingDeadCell(cell, Vector2.UnitX, dead_cells);

                //south
                already_exist = false;
                already_exist = CheckCellsInDirection(cell, -Vector2.UnitY, dead_cells);
                if (!already_exist) already_exist = CheckCellsInDirection(cell, -Vector2.UnitY, alive_cells);
                if (!already_exist) AddCorrespondingDeadCell(cell, -Vector2.UnitY, dead_cells);

                //west
                already_exist = false;
                already_exist = CheckCellsInDirection(cell, -Vector2.UnitX, dead_cells);
                if (!already_exist) already_exist = CheckCellsInDirection(cell, -Vector2.UnitX, alive_cells);
                if (!already_exist) AddCorrespondingDeadCell(cell, -Vector2.UnitX, dead_cells);

                //north_east
                already_exist = false;
                already_exist = CheckCellsInDirection(cell, Vector2.One, dead_cells);
                if (!already_exist) already_exist = CheckCellsInDirection(cell, Vector2.One, alive_cells);
                if (!already_exist) AddCorrespondingDeadCell(cell, Vector2.One, dead_cells);

                //south_east
                already_exist = false;
                already_exist = CheckCellsInDirection(cell, Vector2.UnitX - Vector2.UnitY, dead_cells);
                if (!already_exist) already_exist = CheckCellsInDirection(cell, Vector2.UnitX - Vector2.UnitY, alive_cells);
                if (!already_exist) AddCorrespondingDeadCell(cell, Vector2.UnitX - Vector2.UnitY, dead_cells);

                //south_west
                already_exist = false;
                already_exist = CheckCellsInDirection(cell, -Vector2.One, dead_cells);
                if (!already_exist) already_exist = CheckCellsInDirection(cell, -Vector2.One, alive_cells);
                if (!already_exist) AddCorrespondingDeadCell(cell, -Vector2.One, dead_cells);

                //north_west
                already_exist = false;
                already_exist = CheckCellsInDirection(cell, Vector2.UnitY - Vector2.UnitX, dead_cells);
                if (!already_exist) already_exist = CheckCellsInDirection(cell, Vector2.UnitY - Vector2.UnitX, alive_cells);
                if (!already_exist) AddCorrespondingDeadCell(cell, Vector2.UnitY - Vector2.UnitX, dead_cells);
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

        bool CheckCellsInDirection(Cell cell, Vector2 offset, List<Cell> list_cells)
        {
            bool match_found = false;

            foreach (Cell cell_obj in list_cells)
            {
                if (cell_obj.coords == cell.coords + offset) match_found = true;
                if(match_found) return true;
            }

            return match_found;
        }
        void AddCorrespondingDeadCell(Cell cell, Vector2 offset, List<Cell> dead_cells)
        {
            Cell d_cell = new Cell();
            d_cell.coords = cell.coords + offset;
            dead_cells.Add(d_cell);
        }
    }
}