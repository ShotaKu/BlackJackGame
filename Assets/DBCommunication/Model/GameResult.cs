using System;
using System.Collections.Generic;

namespace BlackJackGame.Models
{
    [Serializable]
    public class GameResult : Result
    {
        public int GameID;
        public string DealerName;
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
        public long? PlayerID;
        public int? PlayerBet;
        public string PlayerLastAction;
        public bool isGameFinished;
    }
    [Serializable]
    public class GameResultList
    {
        public List<GameResult> GameResults;
    }
}