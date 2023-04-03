using pk_Application.Common;
using System.Collections.Generic;

namespace pk_Application.Model;

public class UserCard
{
    public List<CardUnit> TotalUserCard { get; set; }
    public TypeCard Spade { get; set; }
    public TypeCard Clover { get; set; }
    public TypeCard Diamonds { get; set; }
    public TypeCard Hearts { get; set; }

    public UserCard(List<CardUnit> initCard)
    {
        TotalUserCard = initCard;
        var emptyCardType = new CardUnit?[13];
        var type1 = emptyCardType.ToList();
        var type2 = emptyCardType.ToList();
        var type3 = emptyCardType.ToList();
        var type4 = emptyCardType.ToList();
        for (int i = 0; i < initCard.Count; i++)
        {
            var card = initCard[i];
            if (card.IndexOfDeck % 4 == 0)
            {
                type1[card.CardNumber - 1] = card;
            }
            else if (card.IndexOfDeck % 4 == 1)
            {
                type2[card.CardNumber - 1] = card;
            }
            else if (card.IndexOfDeck % 4 == 2)
            {
                type3[card.CardNumber - 1] = card;
            }
            else if (card.IndexOfDeck % 4 == 3)
            {
                type4[card.CardNumber - 1] = card;
            }
        }

        Spade = new TypeCard(type1);
        Clover = new TypeCard(type2);
        Diamonds = new TypeCard(type3);
        Hearts = new TypeCard(type4);
    }   
}
