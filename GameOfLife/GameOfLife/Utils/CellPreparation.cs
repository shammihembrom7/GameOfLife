using System;
using System.Collections.Generic;
using System.Numerics;

namespace GameOfLife.Utils
{
    public class CellPreparation:IPerform
    {
        Vector2[] direction_offset_list = { Vector2.UnitY, Vector2.UnitX, -Vector2.UnitY, -Vector2.UnitX, Vector2.One, (Vector2.UnitX - Vector2.UnitY), (-Vector2.One), (Vector2.UnitY - Vector2.UnitX) };
        // Directions in order (north, east, south, west, north_east, south_east, south_west, north_west)

        Core.CellCreations cell_creation_methods = new Core.CellCreations();

        List<Cell> alive_cells;
        List<Cell> dead_cells;

        public CellPreparation(List<Cell> a_cells, List<Cell> d_cells)
        {
            alive_cells = a_cells;
            dead_cells = d_cells;
        }

        public void Perform()
        {
            CheckForAdjacentDeadCells();
        }





        private void CheckForAdjacentDeadCells()
        {
            dead_cells.Clear();

            bool already_exist;
            foreach (Cell cell in alive_cells)
            {
                foreach (Vector2 direction_offset in direction_offset_list)
                {
                    already_exist = false;
                    already_exist = CheckCellsInDirection(cell, direction_offset, dead_cells);
                    if (!already_exist) already_exist = CheckCellsInDirection(cell, direction_offset, alive_cells);

                    if (!already_exist) cell_creation_methods.AddCorrespondingDeadCell(cell, direction_offset, dead_cells);
                }
            }
        }

        private bool CheckCellsInDirection(Cell cell, Vector2 offset, List<Cell> list_cells)
        {
            bool match_found = false;

            foreach (Cell cell_obj in list_cells)
            {
                if (cell_obj.coords == cell.coords + offset) match_found = true;
                if (match_found) return true;
            }

            return match_found;
        }
    }

}