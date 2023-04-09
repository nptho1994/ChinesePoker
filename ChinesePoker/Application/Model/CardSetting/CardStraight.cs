namespace pk_Application.Model.CardSetting;

public class CardStraight
{
    public List<Card> Straight1 { get; set; } = new List<Card>();
    public List<Card> Straight2 { get; set; } = new List<Card>();
    public List<Card> RealCards { get; set; } = new List<Card>();
    public decimal PointStraight1 { get; set; } = 0;
    public decimal PointStraight2 { get; set; } = 0;

    /// <summary>
    /// Get Straight card (the rank has only one suit)
    /// </summary>
    /// <param name="rankCards"></param>
    public CardStraight(RankCard rankCards)
    {
        // Validat to add Ace to lastest rank cards
        var tempRankCard = rankCards.RankCards;
        if (tempRankCard != null && tempRankCard.Any())
        {
            tempRankCard.Add(tempRankCard[0]);
        }

        if (tempRankCard == null || tempRankCard.Any() == false)
        {
            throw new Exception("Can not generate straight wtih empty cards");
        }

        for (var i = 0; i < tempRankCard.Count - 5; i++)
        {
            var item = tempRankCard[i];
            if (item == null || item.Any() == false)
            {
                continue;
            }

            var hasStraight = true;
            for (var j = 1; j < 5; j++)
            {               
                if (tempRankCard[i + j] == null || tempRankCard[i + j].Any() == false)
                {
                    hasStraight = false;
                    break;
                }
            }

            if (hasStraight == true)
            {
                if (Straight1.Count == 0)
                {
                    Straight1.AddRange(item);
                }
                else if (Straight1.Count > 0 && Straight1.Any(x => x != null && x.Rank.Index + 1 == item[0].Rank.Index))
                {
                    Straight1.AddRange(item);
                } 
                else
                {
                    Straight2.AddRange(item);
                }
                RealCards.AddRange(item);
            }

            var lastStraight1 = Straight1.LastOrDefault();
            var lastStraight2 = Straight2.LastOrDefault();
            if(lastStraight1 != null)
            {
                PointStraight1 = lastStraight1.Rank.Point - 5 + 1; // The straight has minximun point is 12345
            }

            if (lastStraight2 != null)
            {
                PointStraight2 = lastStraight2.Rank.Point - 5 + 1; // The straight has minximun point is 12345
            }
        }
    }
}