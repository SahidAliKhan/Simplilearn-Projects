using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPhase2
{
    public class Player
    {
        private int _playerid;
        public int PlayerId
        {
            get { return _playerid; }
            set { _playerid = value; }
        }
        private string _playername;

        public string PlayerName
        {
            get { return _playername; }
            set { _playername = value; }
        }
        private int _playerage;

        public int PlayerAge
        {
            get { return _playerage; }
            set { _playerage = value; }
        }
    }
}
