using pk_Application.Model;

namespace pk_Application.Common;

public class InitPoker
{
    public List<CardUnit> PokerInitiation()
    {
        var result = new List<CardUnit>();
        for (var i = 0; i < Constant.Setting.MaxNumberOfCardsOfUser; i++)
        {
            for (var j = 0; j < Constant.Setting.MaxNumberOfUser; j++)
            {
                var initCard = new CardUnit
                {
                    CardNumber = i + 1,
                    IndexOfDeck = i * 4 + j,
                    Type = j + 1
                };
                result.Add(initCard);
            }
        }

        return result;
    }

    public List<CardUnit> RandomSwap(List<CardUnit> pokerStandard)
    {
        var result = new List<CardUnit>();
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

    public List<CardUnit> GetCardForUser(int indexOfUser, List<CardUnit> poker)
    {
        if (indexOfUser < 0 || indexOfUser > 4 || poker == null || poker.Count != 52)
        {
            throw new Exception();
        }

        var result = new List<CardUnit>();
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
