
using BlackJackClass;
using BlackJackGame.Models;

public static class PlayerConstructor
{
    public static Player Player(GameInformation gi)
    {
        Player p = new Player(gi.PlayerName,-1);
        p.Id = gi.PlayerID;
        return p;
    }
}
