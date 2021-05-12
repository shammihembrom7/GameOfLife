using System;
using System.Collections.Generic;
using System.Numerics;

using GameOfLife;
using GameOfLife.Core;

class Program
{
    CellEvaluations cell_evaluation_methods;
    CellCreations cell_creation_methods;

    List<int> current_cell_coords;
    List<Cell> alive_cells;
    List<Cell> dead_cells;



    static void Main(string[] args)
    {
        Program p = new Program();
        p.cell_evaluation_methods = new CellEvaluations();
        p.cell_creation_methods = new CellCreations();

        p.current_cell_coords = new List<int>();
        p.alive_cells = new List<Cell>();
        p.dead_cells = new List<Cell>();


        p.RecieveInput(Console.ReadLine());
        p.RunSimulation();

        Console.WriteLine("\npress any key to exit application...");
        Console.ReadKey();
    }




    void RunSimulation()
    {
        cell_evaluation_methods.EvaluateNextGenCells(alive_cells, dead_cells);
        cell_evaluation_methods.AssignNextGenCells(alive_cells, dead_cells);

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
