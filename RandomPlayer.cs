using System;
using System.Collections.Generic;
using System.Text;

namespace BankruptConsole.Classes
{
    class RandomPlayer : Player
    {
        public RandomPlayer(int idPlayer, String name) : base(idPlayer, name)
        {
        }
        public override void Buy(Property property)
        {
            if (new Random().Next(1, 3) == 2 && !property.bought && coins >= property.vlBuy)
            {
                property.owner = this;
                coins -= property.vlBuy;
                property.bought = true;
            }
        }
    }
}
