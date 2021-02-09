using System;
using System.Collections.Generic;
using System.Text;

namespace Velha_Console 
{ 
    public class Tabuleiro
    {
        public char[] Matriz { get; set; }

        public Tabuleiro()
        {
            Matriz = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        }

    }
}
