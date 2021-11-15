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
            string puzzleDir = @"C:\Users\seant\Source\Repos\SudokuMaster\Puzzles\"; // For Sean
            //string puzzleDir = @"../Puzzles/"; // For UNIX-style FS with curdir SudokuMaster
            string puzzleName = "puzzle5.txt";
            string puzzlePath = puzzleDir + puzzleName;
            if (args.Length > 0) puzzlePath = args[0]; // override puzzlePath by providing as first arg

            SudokuGrid grid = LogicService.InitializePuzzle(puzzlePath);
            if (LogicService.FastSolve(grid))
                grid.IsSolved = true;
            else
            {
                Console.WriteLine("No solution");
                System.Environment.Exit(1);
            } 

            if (ImportExportService.ExportCompletedPuzzleSolution(grid, puzzlePath))
            {
                Console.WriteLine("Puzzle Solved, Solution exported to " + puzzleDir + "\n\nSolution is printed bellow for your reference\n");
                PrintingService.PrintGrid(grid);
            }
        }
    }

}