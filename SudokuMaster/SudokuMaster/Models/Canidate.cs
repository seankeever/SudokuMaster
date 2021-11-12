using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuMaster.Models
{
    public class Canidate
    {
        public Canidate(int Value, bool IsCrossedOff)
        {
            this.Value = Value;
            this.IsCrossedOff = IsCrossedOff;
        }

        public int Value { get; set; }
        public bool IsCrossedOff { get; set; }


    }
}
