using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuMaster.Models
{
    //public class CanidateList : IEnumerable
    //public class CanidateList : IEnumerable<Canidate>
    public class CanidateList : IEnumerable
    {
        public CanidateList()
        {
            for(int i = 1; i<=9;i++)
                List.Add(new Canidate(i, false));
        }

        //List<Canidate> List { get; set; }
        List<Canidate> List = new List<Canidate>();

        public Canidate GetCanidateByValue(int Value)
        {
            return List.Single(c => c.Value == Value);
        }
        public IEnumerator GetEnumerator()
        {
            foreach (Canidate canidate in List)
            {
                if (canidate == null)
                    break;
                yield return canidate;
            }
        }

        public Canidate GetAnyValidCandiate()
        {
            foreach (Canidate canidate in List)
            {
                if (!canidate.IsCrossedOff)
                    return canidate;
            }
            return null;
        }

        //IEnumerator<Canidate> IEnumerable<Canidate>.GetEnumerator()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
