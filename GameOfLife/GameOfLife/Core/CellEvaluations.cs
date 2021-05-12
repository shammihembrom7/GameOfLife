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

    namespace Core
    {
        public class CellEvaluations
        {

            Utils.Simulation simulation_utils = new Utils.Simulation();
            Utils.CellFinder cellfind_utils = new Utils.CellFinder();

            public void EvaluateNextGenCells(List<Cell> alive_cells, List<Cell> dead_cells)
            {
                cellfind_utils.CheckForAdjacentDeadCells(alive_cells, dead_cells);

                simulation_utils.SimulateAliveToDead(alive_cells, dead_cells);
                simulation_utils.SimulateDeadToAlive(alive_cells, dead_cells);
            }

            public void AssignNextGenCells(List<Cell> alive_cells, List<Cell> dead_cells)
            {
                for (int i = alive_cells.Count - 1; i >= 0; i--)
                {
                    if (!alive_cells[i].is_alive)
                    {
                        dead_cells.Add(alive_cells[i]);
                        alive_cells.RemoveAt(i);
                    }
                }

                for (int i = dead_cells.Count - 1; i >= 0; i--)
                {
                    if (dead_cells[i].is_alive)
                    {
                        alive_cells.Add(dead_cells[i]);
                        dead_cells.RemoveAt(i);
                    }
                }
            }
        }



        public class CellCreations
        {
            public void AddCorrespondingAliveCell(Vector2 coords, List<Cell> alive_cells)
            {
                Cell cell = new Cell();
                cell.is_alive = true;
                cell.coords = coords;

                alive_cells.Add(cell);
            }
            public void AddCorrespondingDeadCell(Cell cell, Vector2 offset, List<Cell> dead_cells)
            {
                Cell d_cell = new Cell();
                d_cell.coords = cell.coords + offset;
                dead_cells.Add(d_cell);
            }
        }
    }    
}