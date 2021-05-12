using System;
using System.Collections.Generic;
using System.Numerics;

namespace GameOfLife.Utils
{
    public class Simulation
    {
        public void SimulateAliveToDead(List<Cell> alive_cells, List<Cell> dead_cells)
        {
            for (int i = 0; i < alive_cells.Count; i++)
            {
                int adj_cell_count = 0;

                for (int j = 0; j < alive_cells.Count; j++)
                {
                    if (i != j && Vector2.Distance(alive_cells[i].coords, alive_cells[j].coords) < 1.5f)
                    {
                        adj_cell_count += 1;
                    }
                }

                if (adj_cell_count > 3 || adj_cell_count < 2) alive_cells[i].is_alive = false;
            }
        }


        public void SimulateDeadToAlive(List<Cell> alive_cells, List<Cell> dead_cells)
        {
            foreach (Cell d_cell in dead_cells)
            {
                int adj_cell_count = 0;

                foreach (Cell alive_cell in alive_cells)
                {
                    if (Vector2.Distance(d_cell.coords, alive_cell.coords) < 1.5f) adj_cell_count += 1;
                }

                if (adj_cell_count == 3) d_cell.is_alive = true;
            }
        }
    }
}