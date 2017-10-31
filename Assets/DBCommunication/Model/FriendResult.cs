
using System;

namespace BlackJackGame.Models
{
    [Serializable]
    public class FriendResult : Result
    {
        public long PlayerID;
        public string PlayerName;
        public void setIDAndName(long id, string name)
        {
            PlayerID = id;
            PlayerName = name;
        }
    }
}