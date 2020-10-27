using System;
using System.Collections.Generic;

namespace PersonData
{
    public class Player
    {
        int score;
        string name;
        public List<Player> playerList = new List<Player>();

        public Player()
        {

        }

        public Player(int scr,string nm)
        {
            this.score = scr;
            this.name = nm;
        }



        public List<Player> GetAllPlayers()
        {
            return playerList;
        }
        public void AddPlayer()
        {
            var prs = new Player();
            prs.name = name;
            prs.score = score;
            personList.Add(prs);
            personList.Sort();
        }
        public int CountPlayers()
        {
            return personList.Count;
        }
    }
    
}
