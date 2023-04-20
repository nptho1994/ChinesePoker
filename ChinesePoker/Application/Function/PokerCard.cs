using pk_Application.Model.CardSetting;

namespace pk_Application.Function;

/// <summary>
/// The cards are sorted
/// RealCards: total card
/// TopPokerCard: The card of top (5 cards with with bigest score)
/// MiddlePokerCard: The card of top (5 cards)
/// BottomPokerCard: The card of top (3 cards with with samillest score)
/// </summary>
public class PokerCard
{
    public List<Card> RealCards { get; set; }
    public TopPokerCard TopPokerCard { get; set; }
    public MiddlePokerCard MiddlePokerCard { get; set; }
    public BottomPokerCard BottomPokerCard { get; set; }
    public decimal Score { get; set; }
    public int Level { get; set; }


    public PokerCard(List<Card> init, int topLevel, int middleLevel, int bottomLevel)
    {
        if (init == null || init.Count != 13)
        {
            throw new Exception("Can not init poker card");
        }
        RealCards = init;
        TopPokerCard = new TopPokerCard(init.Take(5).ToList(), topLevel);
        MiddlePokerCard = new MiddlePokerCard(init.Skip(5).Take(5).ToList(), middleLevel);
        BottomPokerCard = new BottomPokerCard(init.Skip(10).Take(3).ToList(), bottomLevel);
        Score = TopPokerCard.Score * MiddlePokerCard.Score * BottomPokerCard.Score;
    }
}
