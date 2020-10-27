using System;
using System.Collections.Generic;

namespace PlayerData
{
    public class Player
    {
        public int score;
        public string  name;
        public static List<Player> playerList = new List<Player>();

        public Player()
        {

        }

        public Player(int scr, string nm)
        {
            this.score = scr;
            this.name = nm;
        }

        public void MySort(List<Player> list)
        {

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
            playerList.Add(prs);
            playerList.Sort((x, y) => y.score.CompareTo(x.score));
        }
        public int CountPlayers()
        {
            return playerList.Count;
        }
    }
}
