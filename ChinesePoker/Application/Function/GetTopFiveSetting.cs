using pk_Application.Model.CardSetting;

namespace pk_Application.Function;

public class GetTopFiveSetting
{
    public CardOfTopFive CardOfTop;
    public GetTopFiveSetting(List<Card> cards)
    {
        if (cards.Count != 5)
        {
            throw new Exception("The top five invalid");
        }

        CardOfTop = new CardOfTopFive(cards);
    }
}
