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
    public List<CardUnit> OneCard { get; set; }
    public List<CardUnit> CoupleCard { get; set; }
    public List<CardUnit> ThreeCard { get; set; }
    public List<CardUnit> FourCard { get; set; }
    public List<CardUnit> Straight { get; set; }

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

        OneCard = new List<CardUnit>();
        CoupleCard = new List<CardUnit>();
        ThreeCard = new List<CardUnit>();
        FourCard = new List<CardUnit>();
        Straight = new List<CardUnit>();
        var countStraight = 0;
        for (var i = 0; i < Constant.Setting.MaxNumberOfCardsOfUser; i++)
        {
            var numberOfCard = 0;
            numberOfCard += Spade.Collection[i] != null ? 1 : 0;
            numberOfCard += Clover.Collection[i] != null ? 1 : 0;
            numberOfCard += Diamonds.Collection[i] != null ? 1 : 0;
            numberOfCard += Hearts.Collection[i] != null ? 1 : 0;
            if (numberOfCard == 1)
            {
                if (Spade.Collection[i] != null)
                {
                    OneCard.Add(Spade.Collection[i]);
                }
                if (Clover.Collection[i] != null)
                {
                    OneCard.Add(Clover.Collection[i]);
                }
                if (Diamonds.Collection[i] != null)
                {
                    OneCard.Add(Diamonds.Collection[i]);
                }
                if (Hearts.Collection[i] != null)
                {
                    OneCard.Add(Hearts.Collection[i]);
                }
            }
            else if (numberOfCard == 2)
            {
                if (Spade.Collection[i] != null)
                {
                    CoupleCard.Add(Spade.Collection[i]);
                }
                if (Clover.Collection[i] != null)
                {
                    CoupleCard.Add(Clover.Collection[i]);
                }
                if (Diamonds.Collection[i] != null)
                {
                    CoupleCard.Add(Diamonds.Collection[i]);
                }
                if (Hearts.Collection[i] != null)
                {
                    CoupleCard.Add(Hearts.Collection[i]);
                }
            } 
            else if (numberOfCard == 3)
            {
                if (Spade.Collection[i] != null)
                {
                    ThreeCard.Add(Spade.Collection[i]);
                }
                if (Clover.Collection[i] != null)
                {
                    ThreeCard.Add(Clover.Collection[i]);
                }
                if (Diamonds.Collection[i] != null)
                {
                    ThreeCard.Add(Diamonds.Collection[i]);
                }
                if (Hearts.Collection[i] != null)
                {
                    ThreeCard.Add(Hearts.Collection[i]);
                }
            }
            else if (numberOfCard == 4)
            {
                if (Spade.Collection[i] != null)
                {
                    FourCard.Add(Spade.Collection[i]);
                }
                if (Clover.Collection[i] != null)
                {
                    FourCard.Add(Clover.Collection[i]);
                }
                if (Diamonds.Collection[i] != null)
                {
                    FourCard.Add(Diamonds.Collection[i]);
                }
                if (Hearts.Collection[i] != null)
                {
                    FourCard.Add(Hearts.Collection[i]);
                }
            }

            if (numberOfCard == 0)
            {
                countStraight = 0;
            } 
            else
            {
                countStraight++;
            }

            if (countStraight >= 5)
            {
                if (countStraight == 5)
                {
                    for (var j = 4; j >= 0; j--)
                    { 
                        var card = Spade.Collection[i - j];
                        if (card == null)
                        {
                            card = Clover.Collection[i - j];
                        }

                        if (card == null)
                        {
                            card = Diamonds.Collection[i - j];
                        }

                        if (card == null)
                        {
                            card = Hearts.Collection[i - j];
                        }

                        Straight.Add(card);
                    }
                } 
                else
                {
                    var card = Spade.Collection[i];
                    if (card == null)
                    {
                        card = Clover.Collection[i];
                    }

                    if (card == null)
                    {
                        card = Diamonds.Collection[i];
                    }

                    if (card == null)
                    {
                        card = Hearts.Collection[i];
                    }

                    Straight.Add(card);
                }
            }
        }
    }   
}
