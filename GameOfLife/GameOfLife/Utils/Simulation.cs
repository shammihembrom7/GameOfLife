using System;
using System.Collections.Generic;
using System.Numerics;

namespace GameOfLife.Utils
{
    public class Simulation:IPerform
    {
        List<Cell> alive_cells;
        List<Cell> dead_cells;

        public Simulation(List<Cell> a_cells, List<Cell> d_cells)
        {
            alive_cells = a_cells;
            dead_cells = d_cells;
        }

        public void Perform()
        {
            SimulateAliveToDead();
            SimulateDeadToAlive();
        }

        private void SimulateAliveToDead()
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


        private void SimulateDeadToAlive()
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