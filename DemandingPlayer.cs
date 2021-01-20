using System;
using System.Collections.Generic;
using System.Text;

namespace BankruptConsole.Classes
{
    class DemandingPlayer : Player
    {
        public DemandingPlayer(int idPlayer, String name) : base(idPlayer, name)
        {
        }
        public override void Buy(Property property)
        {
            if (this.coins >= property.vlBuy && !property.bought && property.vlRent > 50)
            {
                property.owner = this;
                coins -= property.vlBuy;
                property.bought = true;
            }
        }
    }
}
