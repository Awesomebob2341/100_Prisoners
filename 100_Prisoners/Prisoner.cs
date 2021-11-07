using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _100_Prisoners
{
    class Prisoner
    {
        private List<int> cupboardsChecked = new List<int>();
        public int id { get; }

        public Prisoner(int id)
        {
            this.id = id;
        }

        public void AddCupboard(int cupboard)
        {
            cupboardsChecked.Add(cupboard);
        }

        public bool AlreadyChecked(int n)
        {
            if (cupboardsChecked.Contains(n))
                return true;
            else
                return false;
        }
    }
}