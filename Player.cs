using System;
using System.Collections.Generic;
using System.Text;

namespace BankruptConsole.Classes
{
    public class Player
    {
        public int idPlayer, coins, countWin = 0;
        public String name;
        public Boolean exit = false;
        public Property currentProperty = null;



        public Player(int idPlayer, String name)
        {
            this.idPlayer = idPlayer;
            this.coins = 300;
            this.name = name;
        }

        // Function onde o player compra a propertie
        public virtual void Buy(Property property)
        {
        }
        // Function onde o player paga o aluguel pro owner e se não tiver grana FIM
        public Boolean Rent(Property property)
        {
            if (this.coins >= property.vlRent && property.bought)
            {
                this.coins -= property.vlRent;
                property.owner.coins += property.vlRent;
                return true;
            }
            else//morreu perdeu
            {
                foreach(Property prop in Program.properties)
                {
                    if (prop.owner == this)
                    {
                        prop.owner = null;
                        prop.bought = false;
                    }
                }

                exit = true;
                return false;
            }
        }
    }
}
