using System;
using System.Collections.Generic;
using System.Text;

namespace BankruptConsole.Classes
{
    public class Match
    {
        public int turn = 0;
        public Player winner;
        public Boolean end = false;
        public SortedDictionary<Int32, Player> playerDices;
        public int playersDefeated = 0; 


        public Match(List <Player> players)
        {
            turn = 0;
            end = false;
            playersDefeated = 0;
            this.playerDices = new SortedDictionary <Int32, Player>();
            foreach (Player player in players)
            {
                player.coins = 300;
                
            }

            foreach (Player player in players)
            {
                
                Int32 diceValue = 0;
                while(diceValue == 0)
                {
                    diceValue = RollDice();
                    if (playerDices.ContainsKey(diceValue))
                    {
                        diceValue = 0;
                    }
                }
                playerDices.Add(diceValue, player);
            }                   
        }

        public static int RollDice()
        {
            return new Random().Next(1, 7);
        }

        public void Turn()
        {
            
            foreach (KeyValuePair<Int32, Player> line in playerDices)
            {
                Player player = line.Value;

                if (!player.exit)//se o player não tiver grana pra pagar o aluguel ele vai a falência e não entra nesse if. NO GAME
                {
                    if (player.currentProperty == null)
                    {
                        player.currentProperty = Program.properties[RollDice()];
                    }
                    else
                    {
                        int dice = RollDice();
                        if (player.currentProperty.idProperty + dice > Program.properties.Length - 1) //comparando a soma do idproperty + roll, com o tamanho do array property
                        {
                            player.coins += 100;
                            player.currentProperty = Program.properties[(player.currentProperty.idProperty + dice) - Program.properties.Length - 1];
                        }
                        else
                        {
                            player.currentProperty = Program.properties[player.currentProperty.idProperty + dice];
                        }

                    }
                    
                    if (!player.Rent(player.currentProperty)){//se player morreu aumenta a var que controla os mortos
                        if (playersDefeated < 3)
                        {
                            playersDefeated++;
                            player.exit = true;
                        }
                        else
                        {
                            winner = player;
                            end = true;
                            playersDefeated = 0;
                        }

                    }
                    player.Buy(player.currentProperty);


                }
                
            }
            turn++;
            if (turn>= 1000)
            {
                
                this.end = true;
                Player richestPlayer = null;
                foreach (KeyValuePair<Int32, Player> line in playerDices)
                {
                    if (richestPlayer == null)
                    {
                        richestPlayer = line.Value;
                    }
                    else
                    {
                        if(richestPlayer.coins < line.Value.coins)
                        {
                            richestPlayer = line.Value;
                        }
                    }
                }
                winner = richestPlayer;
            }
            else if(playersDefeated >= playerDices.Keys.Count - 1)
            {
                this.end = true;
                foreach(KeyValuePair<Int32, Player> line in playerDices)
                {
                    if (!line.Value.exit)
                    {
                        winner = line.Value;

                    } 
                }
                
            }
        }

    }
}
