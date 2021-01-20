using System;
using BankruptConsole.Classes;
using System.Collections.Generic;

namespace BankruptConsole
{
    class Program
    {
        
        public static Property[] properties;
        public static Match[] matches;

        static void Main(string[] args)
        {
            //Console.WriteLine(Match.RollDice());

            List<Player> playerL = new List<Player>();
            playerL.Add(new CautiousPlayer(1, "Catrina, a Cautelosa"));
            playerL.Add(new DemandingPlayer(2, "Danilo, o Exigente"));
            playerL.Add(new ImpulsivePlayer(3, "Iago, o Impulsivo"));
            playerL.Add(new RandomPlayer(4, "Rita, a Aleatória"));
            properties = new Property[20];
            matches = new Match[300];
            new Match(playerL);
            string[] propertiesAL = new string[20];
            int counter = 0;
            string line;            
 
            System.IO.StreamReader file = new System.IO.StreamReader(@"C:\Users\Vegelove\source\repos\BankruptConsole\Files\gameConfig.txt");//lê o arquivo gameconfig
            while ((line = file.ReadLine()) != null)
            {
                propertiesAL[counter] = line;
                properties[counter] = new Property(counter, Int32.Parse(propertiesAL[counter].Substring(0, 3)), Int32.Parse(propertiesAL[counter].Substring(4, 2)));
                counter++;

            }
            file.Close();
            int timeoutMatches = 0, turns = 0;
            for (int i = 0; i < 300; i++)//fazer os 300 jogos
            {

               
                matches[i] = new Match(playerL);
                
                while (!matches[i].end)
                {
                    matches[i].Turn();
                    turns++;
                    
                }
                if (matches[i].turn >= 1000)
                {
                    timeoutMatches++;

                }
                matches[i].winner.countWin++;
                
            }
            
            Console.WriteLine("Quantas partidas terminam por time out: " + timeoutMatches);
            Console.WriteLine("Quantas turnos (rodadas), em média, demora uma partida: " + turns/300);
            Player playerWinner = null;
            foreach(Player p in playerL)
            {
                Console.WriteLine("O jogador " + p.name + " ganhou: " + (p.countWin*100)/300 + "%");
                if (playerWinner == null)
                {
                    playerWinner = p;
                }else if (playerWinner.countWin < p.countWin)
                {
                    playerWinner = p;
                }
            }
            Console.WriteLine("Qual jogador possui mais vitórias: " + playerWinner.name);

        }
    }
}
