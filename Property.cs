using System;
using System.Collections.Generic;
using System.Text;

namespace BankruptConsole.Classes
{
    public class Property
    {
        public int idProperty, vlBuy, vlRent;
        public Boolean bought;
        public string name;
        public Player owner;

        public Property(int idProperty, int vlBuy, int vlRent)
        {
            this.idProperty = idProperty;
            this.vlBuy = vlBuy;
            this.vlRent = vlRent;
            this.bought = false;

        }
    }
}
