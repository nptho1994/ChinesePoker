using pk_Application.Common;
using pk_Application.Model;

namespace pk_Application.Function;

public static class Mapping
{
    public static TreeCard MappingStackPoker(TreeTypeCard typeCard)
    {
        var result = new TreeCard();

        for (int i = 0; i < Constant.ChinesePoker.MaxNumberOfCardsOfUser; i++)
        {
            var card = new CardUnit();
            if (typeCard.Spade[i] != null)
            {
                card = typeCard.Spade[i];
            }
            else if (typeCard.Clover[i] != null)
            {
                card = typeCard.Clover[i];
            }
            else if (typeCard.Diamonds[i] != null)
            {
                card = typeCard.Diamonds[i];
            }
            else if (typeCard.Hearts[i] != null)
            {
                card = typeCard.Hearts[i];
            }

            if (i < Constant.ChinesePoker.MaxNumberOfStact1)
            {
                result.Stack1.Add(card);
            }
            else if (i < Constant.ChinesePoker.MaxNumberOfStact1 + Constant.ChinesePoker.MaxNumberOfStact2)
            {
                result.Stack2.Add(card);
            }
            else
            {
                result.Stack3.Add(card);
            }
        }

        return result;
    }

    public static TreeTypeCard MappingTypeCard(List<CardUnit> poker)
    {
        var result = new TreeTypeCard();

        for (int i = 0; i < poker.Count; i++)
        {
            if (poker[i].Type == 1)
            {
                result.Spade[poker[i].Point] = poker[i];
            }
            else if (poker[i].Type == 1)
            {
                result.Clover[poker[i].Point] = poker[i];
            }
            else if (poker[i].Type == 1)
            {
                result.Diamonds[poker[i].Point] = poker[i];
            }
            else if (poker[i].Type == 1)
            {
                result.Hearts[poker[i].Point] = poker[i];
            }
        }

        return result;
    }
}
