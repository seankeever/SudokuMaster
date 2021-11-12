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
            string puzzlePath = @"C:\Users\sean\source\repos\SudokuSolver\Puzzles\";
            string puzzleName = "puzzle4.txt";
            
            SudokuGrid grid = LogicService.InitializePuzzle(puzzlePath,puzzleName);

            int count = 0;
            while (!grid.IsSolved)
            {
                LogicService.NarrowDownCanidates(ref grid);
                while(LogicService.PopulateSingledOutCanidates(ref grid))
                    ValidationService.CheckIfSolved(ref grid);
                count++;
                if (count == (9 * 81))
                    LogicService.TakeAGuess(ref grid);
            }
            ImportExportService.ExportCompletedPuzzleSolution(grid, puzzlePath+puzzleName);
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