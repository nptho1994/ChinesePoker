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
                result.StackThree.Add(card);
            }
            else if (i < Constant.Setting.MaxNumberOfStack1 + Constant.Setting.MaxNumberOfStack2)
            {
                result.StackTwo.Add(card);
            }
            else
            {
                result.StackFirst.Add(card);
            }
        }

        return result;
    }
}
