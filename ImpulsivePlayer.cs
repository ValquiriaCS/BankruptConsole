using System;
using System.Collections.Generic;
using System.Text;

namespace BankruptConsole.Classes
{
    class ImpulsivePlayer : Player
    {
        public ImpulsivePlayer(int idPlayer, String name) : base(idPlayer, name)
        {
        }
        public override void Buy(Property property)
        {
            if (this.coins >= property.vlBuy && !property.bought)
            {
                property.owner = this;
                coins -= property.vlBuy;
                property.bought = true;
            }
        }
    }
}
