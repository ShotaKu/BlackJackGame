using System;
using System.Collections.Generic;

namespace BlackJackGame.Models
{
    [Serializable]
    public class GameResult : Result
    {
        public int GameID;

        public string DealerName;

        public int DealerBet;
        public DateTime CreateDateTime;
    }
    [Serializable]
    public class JoinResult : Result
    {
        public int GameID;

        public long DealerID;
        public int DealerBet;
        public int? DealerTotalHand;
        public string[] DealerHand;
        public string DealerLastAction;

        //PlayerID
        //PlayerBet
        //PlayerTotalHand
        public string[] PlayerHand;
        //PlayerLastAction
        public DateTime LastActionDateTime;
        //isTime


    }
    [Serializable]
    public class GameInformation : JoinResult
    {
        public long PlayerID;
        public string PlayerName;   //TODO: Add in db
        public int PlayerBet;
        public string PlayerLastAction;
        public bool isGameFinished;
        //public long GetPlayerID()
        //{
        //    return (long)PlayerID;
        //}
    }
    [Serializable]
    public class GameResultList
    {
        public List<GameResult> GameResults;

        public int Count()
        {
            return GameResults.Count;
        }
    }
}