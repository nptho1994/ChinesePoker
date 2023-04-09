using pk_Application.Model.CardSetting;

namespace pk_Application.Common;

public class InitDeskCard
{
    public List<Card> PokerInitiation()
    {
        var result = new List<Card>();
        for (var i = 0; i < Constant.Setting.MaxNumberOfCardsOfUser; i++)
        {
            for (var j = 0; j < Constant.Setting.MaxNumberOfUser; j++)
            {
                var initCard = new Card(i, j);
                result.Add(initCard);
            }
        }

        return result;
    }

    public List<Card> RandomSwap(List<Card> pokerStandard)
    {
        var result = new List<Card>();
        for (int i = 0; i < Constant.Setting.MaxNumberOfCardsOfDeck; i++)
        {
            Random rnd = new Random();
            var numberRandomCard = rnd.Next(Constant.Setting.MaxNumberOfCardsOfDeck - i);
            var randomCard = pokerStandard[numberRandomCard];
            result.Add(randomCard);
            pokerStandard.Remove(randomCard);
        }

        return result;
    }

    public List<Card> GetCardForUser(int indexOfUser, List<Card> poker)
    {
        if (indexOfUser < 0 || indexOfUser > 4 || poker == null || poker.Count != 52)
        {
            throw new Exception();
        }

        var result = new List<Card>();
        for (int i = 0; i < poker.Count; i++)
        {
            if (i % 4 == indexOfUser)
            {
                result.Add(poker[i]);
            }
        }

        return result;
    }
}
