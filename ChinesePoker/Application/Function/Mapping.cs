using pk_Application.Common;
using pk_Application.Model;

namespace pk_Application.Function;

public static class Mapping
{
    public static TreeCard MappingStackPoker(UserCard userCard)
    {
        var result = new TreeCard();

        for (int i = 0; i < Constant.Setting.MaxNumberOfCardsOfUser; i++)
        {
            var card = new CardUnit();
            if (userCard.Spade.Collection[i] != null)
            {
                card = userCard.Spade.Collection[i];
            }
            else if (userCard.Clover.Collection[i] != null)
            {
                card = userCard.Clover.Collection[i];
            }
            else if (userCard.Diamonds.Collection[i] != null)
            {
                card = userCard.Diamonds.Collection[i];
            }
            else if (userCard.Hearts.Collection[i] != null)
            {
                card = userCard.Hearts.Collection[i];
            }

            if (card == null)
            {
                throw new Exception("The card is null");
            }

            if (i < Constant.Setting.MaxNumberOfStack1)
            {
                result.Stack1.Add(card);
            }
            else if (i < Constant.Setting.MaxNumberOfStack1 + Constant.Setting.MaxNumberOfStack2)
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
}
