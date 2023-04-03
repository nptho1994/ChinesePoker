using pk_Application.Common;
using pk_Application.Model;

namespace pk_Application.Funtion;

public class SortCard
{
    public TreeCard FindBest(List<CardUnit> poker)
    {
        if (poker == null || poker.Count != 13)
        {
            throw new Exception();
        }

        var typeCard = Mapping.MappingTypeCard(poker);
        var result = new TreeCard();

        // Dragon hall
        if (FindDragonHall(typeCard) != null)
        {
            result = FindDragonHall(typeCard);
        }

        return result;
    }

    private TreeCard? FindDragonHall(TreeTypeCard typeCard)
    {
        for (int i = 0; i < Constant.ChinesePoker.MaxNumberOfCardsOfUser; i++)
        {
            if (typeCard.Spade[i] == null && typeCard.Clover[i] == null && typeCard.Diamonds[i] == null && typeCard.Hearts[i] == null)
            {
                return null;
            }
        }

        return MappingStackPoker(typeCard);
    }
}
