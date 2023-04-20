using pk_Application.Model.CardSetting;
using pk_Application.Model.Type;

namespace pk_Application.Function;

public class BottomPokerCard
{
    public List<Card> Cards { get; set; }
    public int Level { get; set; }
    public decimal Score { get; set; } = 0;
    public int WinBet { get; set; } = 1;

    public BottomPokerCard(List<Card> cards, int topLevel)
    {
        if (cards == null || cards.Count != 4)
        {
            throw new Exception("Can not init BottomPokerCard");
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
                var threeCardWithSingle = new ThreeCardWithSingle(Cards);
                Score = threeCardWithSingle.Score;
                break;
            case 2:
                var threeCardWithDouble = new ThreeCardWithDouble(Cards);
                Score = threeCardWithDouble.Score;
                break;
            case 3:
                var threeCardWithTriple = new ThreeCardWithTriple(Cards);
                Score = threeCardWithTriple.Score;
                WinBet = 2;
                break;

            default:
                break;
        }
    }
}
