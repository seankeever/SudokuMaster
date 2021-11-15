using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuMaster.Models
{
    public class SudokuSquare
    {
        public SudokuSquare()
        {
            this.Value = 0;//set all to 0 initially then fill in based on text file
            this.IsSet = false;
        }


        public int SquareID { get; set; }
        public bool IsSet { get; set; }//this is false until the square is set to a single digit
        public int Value { get; set; }//blank or X value is represented by 0


        public int Row { get; set; }
        public int Column { get; set; }
        public int Region { get; set; }


    }
}
