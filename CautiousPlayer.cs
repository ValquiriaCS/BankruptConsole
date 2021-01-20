using System;
using System.Collections.Generic;
using System.Text;

namespace BankruptConsole.Classes
{
    class CautiousPlayer : Player
    {

        public CautiousPlayer(int idPlayer, String name) : base(idPlayer, name)
        {
        }
        

        public override void Buy(Property property)
        {
            if (!property.bought && coins - property.vlBuy >= 80)
            {
                property.owner = this;
                coins -= property.vlBuy;
                property.bought = true;
            }
        }
    }
}
