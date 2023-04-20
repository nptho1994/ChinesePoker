using pk_Application.Model.CardSetting;
using pk_Application.Model.Type;

namespace pk_Application.Function;

public class MiddlePokerCard
{
    public List<Card> Cards { get; set; }
    public int Level { get; set; }
    public decimal Score { get; set; } = 0;
    public int WinBet { get; set; } = 1;

    public MiddlePokerCard(List<Card> cards, int topLevel)
    {
        if (cards == null || cards.Count != 5)
        {
            throw new Exception("Can not init MiddlePokerCard");
        }
        Cards = cards;
        Level = topLevel;
        CalculateScore();
    }

    private void CalculateScore()
    {
        switch (Level)
        {
            case 1:
                var maxFiveCard = new MaxFiveCard(Cards);
                Score = maxFiveCard.Score;
                break;
            case 2:
                var doubleCard = new DoubleCard(Cards);
                Score = doubleCard.Score;
                break;
            case 3:
                var twoDoubleCard = new TwoDoubleCard(Cards);
                Score = twoDoubleCard.Score;
                break;
            case 4:
                var threeCard = new ThreeCard(Cards);
                Score = threeCard.Score;
                break;
            case 5:
                var straightCard = new StraightCard(Cards);
                Score = straightCard.Score;
                break;
            case 6:
                var flushCard = new FlushCard(Cards);
                Score = flushCard.Score;
                break;
            case 7:
                var boatCard = new BoatCard(Cards);
                Score = boatCard.Score;
                WinBet = 2;
                break;
            case 8:
                var quadCard = new QuadCard(Cards);
                Score = quadCard.Score;
                WinBet = 3;
                break;
            case 9:
                var typeCard = new StraightFlushCard(Cards);
                Score = typeCard.Score;
                WinBet = 4;
                break;

            default:
                break;
        }
    }
}
