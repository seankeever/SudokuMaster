using SudokuMaster.Models;
using SudokuMaster.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace SudokuMaster
{
    class Program
    {
        static void Main(string[] args)
        {
            string puzzlePath = @"C:\Repos\SudokuMaster\Puzzles\";
            string puzzleName = "puzzle1.txt";
            
            SudokuGrid grid = LogicService.InitializePuzzle(puzzlePath,puzzleName);

            if(grid!=null)
            {
                int count = 0;
                while (!grid.IsSolved)
                {
                    LogicService.NarrowDownCanidates(ref grid);
                    while (LogicService.PopulateSingledOutCanidates(ref grid))
                        ValidationService.CheckIfSolved(ref grid);
                    count++;
                    if (count == (9 * 81))
                    {
                        Console.WriteLine("Puzzle could not be solved without guessing");
                        Console.WriteLine("Puzzle could potentially be solved with recursive backtracking algorithm comming in version 2");
                        break;
                    }
                }
                if(grid.IsSolved)
                {
                    bool wasExported = ImportExportService.ExportCompletedPuzzleSolution(grid, puzzlePath + puzzleName);
                    if (wasExported)
                    {
                        Console.WriteLine("Puzzle Solved, Solution exported to " + puzzlePath + "\n\nSolution is printed bellow for your reference\n");
                        PrintingService.PrintGrid(grid);
                    }
                }
            }
        }
    }
}
//static void Main(string[] args)
//{
//    string puzzlePath = @"C:\Users\sean\source\repos\SudokuSolver\Puzzles\";
//    string puzzleName = "puzzle4.txt";

//    SudokuGrid grid = LogicService.InitializePuzzle(puzzlePath, puzzleName);

//    while (!grid.IsSolved)
//    {
//        LogicService.NarrowDownCanidates(ref grid);
//        while (LogicService.PopulateSingledOutCanidates(ref grid))
//            ValidationService.CheckIfSolved(ref grid);
//    }
//    ImportExportService.ExportCompletedPuzzleSolution(grid, puzzlePath + puzzleName);
//}