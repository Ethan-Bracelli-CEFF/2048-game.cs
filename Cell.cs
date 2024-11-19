using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game_2048
{
    public class Cell
    {
        public int Value { get; set; }

        public Cell() 
        { 
            this.Value = Value;
        }

        public override string ToString()
        {
            string ret = "[";
            if (this.Value == 0)
            {
                ret += "    ";
            }
            else if (this.Value > 0 && this.Value < 10)
            {
                ret += "   ";
                ret += this.Value.ToString();
            }
            else if (this.Value >= 10 && this.Value < 100)
            {
                ret += "  ";
                ret += this.Value.ToString();
            }
            else if (this.Value >= 100 && this.Value < 1000)
            {
                ret += " ";
                ret += this.Value.ToString();
            }
            else if (this.Value >= 1000)
            {
                ret += this.Value.ToString();
            }

            ret += "]";
            return ret.ToString();
        }

    }
}
