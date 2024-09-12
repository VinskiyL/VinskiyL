using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _1883
{
    internal class DeShifrator
    {
        string key;
        string deshifr = "";
        int j = 0;
        char[] alf = new char[33];
        public DeShifrator(string key)
        {
            this.key = key;
            for (char i = 'а'; i <= 'я'; i++)
            {
                alf[j] = i;
                if(i == 'е')
                {
                    j++;
                    alf[j] = 'ё';
                }
                j++;
            }
        }
        void Desh(string shifr)
        {
            shifr = shifr.ToLower();
            j = 0;
            int index;
            for(int i = 0; i<shifr.Length; i++)
            {
                if (alf.Contains(shifr[i]))
                {
                    if(j == key.Length)
                    {
                        j = 0;
                    }
                    index = Array.IndexOf(alf, shifr[i]) - Array.IndexOf(alf, key[j]);
                    if (index < 0)
                    {
                        index = 33 + index;
                    }
                    deshifr += alf[index].ToString();
                    j++;
                }
                else
                {
                    deshifr += shifr[i].ToString();
                }
            }
        }
        public string Info(string shifr)
        {
            Desh(shifr);
            return deshifr;
        }
    }
}
