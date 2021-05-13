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
        public class CellEvaluations:IPerform
        {
            private List<Cell> alive_cells;
            private List<Cell> dead_cells;

            public CellEvaluations(List<Cell> a_cells, List<Cell> d_cells)
            {
                alive_cells = a_cells;
                dead_cells = d_cells;
            }

            public void Perform()
            {
                AssignNextGenCells();
            }



            private void AssignNextGenCells()
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