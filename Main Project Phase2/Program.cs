using System;
using System.Collections.Generic;
using System.Net.Http;

namespace ProjectPhase2
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
            repeat:
            Console.WriteLine("Enter 1:To Add Player 2:To Remove Player by Id 3.Get Player By Id 4.Get Player by Name 5.Get All Players:");
            int ch = Convert.ToInt32(Console.ReadLine());
            switch (ch)
            {
                case 1:
                    OneDayTeam o = new OneDayTeam();
                    if (OneDayTeam.oneDayTeam.Count <= OneDayTeam.oneDayTeam.Capacity)
                    {
                        Console.WriteLine("Enter Player ID");
                        o.PlayerId = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter Player Name:");
                        o.PlayerName = Console.ReadLine();
                        Console.WriteLine("Enter Player Age:");
                        o.PlayerAge = Convert.ToInt32(Console.ReadLine());
                        o.Add(o);
                    }
                    else
                    {
                        Console.WriteLine("You cannot add more than 11 Players.");
                    }
                    break;
                case 2:
                    OneDayTeam o1 = new OneDayTeam();
                    Console.WriteLine("Enter Player ID to Remove:");
                    int id = Convert.ToInt32(Console.ReadLine());
                    o1.Remove(id);
                    break;
                case 3:
                    OneDayTeam o2 = new OneDayTeam();
                    Console.WriteLine("Enter Player ID:");
                    int id1 = Convert.ToInt32(Console.ReadLine());
                    Player p = o2.GetPlayerById(id1);
                    Console.WriteLine("Player ID: " + p.PlayerId);
                    Console.WriteLine("Player Name: " + p.PlayerName);
                    Console.WriteLine("Player Age: " + p.PlayerAge);
                    break;
                case 4:
                    OneDayTeam o3 = new OneDayTeam();
                    Console.WriteLine("Enter Player Name:");
                    string name = Console.ReadLine();
                    Player p1 = o3.GetPlayerByName(name);
                    Console.WriteLine("Player ID: " + p1.PlayerId);
                    Console.WriteLine("Player Name: " + p1.PlayerName);
                    Console.WriteLine("Player Age: " + p1.PlayerAge);
                    break;
                case 5:
                    Console.WriteLine("All Players details:");
                    List<Player> all = new List<Player>();
                    OneDayTeam o4 = new OneDayTeam();
                    all = o4.GetAllPlayers();
                    foreach (var i in all)
                    {
                        Console.WriteLine("Player ID: " + i.PlayerId);
                        Console.WriteLine("Player Name: " + i.PlayerName);
                        Console.WriteLine("Player Age: " + i.PlayerAge);
                    }
                    break; 
                default:
                    Environment.Exit(0);
                    break;
                    
            }
            Console.WriteLine("Do you want to continue (yes/no)?");
            string ch1 = Console.ReadLine();
            if (ch1 == "yes")
            {
                goto repeat;
            }
            else if (ch1 == "no")
            {
                Environment.Exit(0);
            }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }
    }
}
