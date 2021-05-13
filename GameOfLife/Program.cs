using System;
using System.Collections.Generic;
using System.Numerics;

using GameOfLife;
using GameOfLife.Core;
using GameOfLife.Utils;

class Program
{
    CellEvaluations cell_evaluation_methods;
    CellCreations cell_creation_methods;

    Simulation utils_simulation;
    CellPreparation utils_cell_preparation;

    List<int> current_cell_coords;
    List<Cell> alive_cells;
    List<Cell> dead_cells;



    static void Main(string[] args)
    {
        Program p = new Program();

        p.current_cell_coords = new List<int>();
        p.alive_cells = new List<Cell>();
        p.dead_cells = new List<Cell>();

        p.cell_evaluation_methods = new CellEvaluations(p.alive_cells, p.dead_cells);
        p.cell_creation_methods = new CellCreations();

        p.utils_simulation = new Simulation(p.alive_cells, p.dead_cells);
        p.utils_cell_preparation = new CellPreparation(p.alive_cells, p.dead_cells);


        p.RecieveInput(Console.ReadLine());
        p.RunSimulation();

        Console.WriteLine("\npress any key to exit application...");
        Console.ReadKey();
    }




    void RunSimulation()
    {
        utils_cell_preparation.Perform();
        utils_simulation.Perform();
        cell_evaluation_methods.Perform();

        foreach (Cell cell in alive_cells)
        {
            if (cell.is_alive) Console.WriteLine(cell.coords.X + ", " + cell.coords.Y);
        }
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
            cell_creation_methods.AddCorrespondingAliveCell(new Vector2(current_cell_coords[0], current_cell_coords[1]), alive_cells);
        }
        else
        {
            Console.WriteLine("'INCORRECT INPUT' : enter coordinates of the alive cell in (X, Y) format example '2, 3' and then press ENTER");
        }

        current_cell_coords.Clear();
        RecieveInput(Console.ReadLine());
    }

}
