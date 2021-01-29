using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using System.Windows.Forms;

namespace lab12zavd1
{
    
    class Program
    {
        static bool Inputdata(ref double p, string buk)
        {
            string inp;

        vvod:
            inp = Interaction.InputBox(buk, "vvedenia", $"{p}");
            try
            {
                p = Convert.ToDouble(inp);
            }
            catch (System.FormatException)
            {
                if (MessageBox.Show("vi vveli ne 4islo" + "\npovtorit?", "uvaga", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    goto vvod;
                else
                    return false;
            }
            return true;
        }
        static void Main(string[] args)
        {
            double min = 10, max = 40;
            double n = 10;
        start:
            string outp = "";
            int i = 0;
            double[] arr;

            //input min & max 
            if (!Inputdata(ref n, "vvedit rozmir masyvu:"))
                return;
            if (!Inputdata(ref min, "vvedit minimalne 4slo:"))
                return;
            if (!Inputdata(ref max, "vvedit maxsimalne 4slo:"))
                return;

            int n2 = (int)n;
            arr = new double[n2];

            Random random = new Random();

            for (; i < n2; i++)
                arr[i] = min + random.NextDouble() * (max - min);
                
            outp += "array 1:\n";

            for (i = 0; i < n2; i++)
                outp += $" array[{i}]={arr[i]}";

            //array N2
            Array.Resize(ref arr, arr.Length + 4);

            for (; i < n2+4; i++)
                arr[i] = min + random.NextDouble() * (max - min);
            
            outp += "\n\narray 2:\n";

            for (i = 0; i < n2+4; i++)
                outp += $" array[{i}]={arr[i]}";

            // output
            if (MessageBox.Show(outp  + "\n\nPovtor?", "Rezultat", MessageBoxButtons.YesNo) == DialogResult.Yes)
                goto start;
        }
    }
}
