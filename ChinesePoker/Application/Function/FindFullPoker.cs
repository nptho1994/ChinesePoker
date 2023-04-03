using pk_Application.Common;
using pk_Application.Model;
using System.Net.Http.Headers;

namespace pk_Application.Function;

public static class FindFullPoker
{
    public static TreeCard FindBestFullPoker(UserCard userCard)
    {
        var result = new TreeCard();

        // 1 FindDragonHall
        var dragonHall = FindDragonHall(userCard);
        if (dragonHall != null)
        {
            return dragonHall;
        }

        // 2 Royal Flush
        var royalFlush = FindRoyalFlush(userCard);
        if (royalFlush != null)
        {
            return royalFlush;
        }

        //....

        // Default
        result = FindDefaultSort(userCard);

        return result;
    }

    private static TreeCard FindDefaultSort(UserCard userCard)
    {
        var result = new TreeCard();
        var cardUnits = new List<CardUnit>();
        cardUnits.AddRange(userCard.Spade.RealCard);
        cardUnits.AddRange(userCard.Clover.RealCard);
        cardUnits.AddRange(userCard.Diamonds.RealCard);
        cardUnits.AddRange(userCard.Hearts.RealCard);
        cardUnits = cardUnits.OrderByDescending(x => x.CardNumber)
            .ThenByDescending(x => x.Type).ToList();
        if (cardUnits.Count != 13)
        {
            throw new Exception("FindDefaultSort: Invalid card number");
        }    

        for (var i = 0; i < Constant.ChinesePoker.MaxNumberOfCardsOfUser; i++)
        {
            if (i < Constant.ChinesePoker.MaxNumberOfStack1)
            {
                result.Stack1.Add(cardUnits[i]);
            } else if (i < Constant.ChinesePoker.MaxNumberOfStack1 + Constant.ChinesePoker.MaxNumberOfStack2)
            {
                result.Stack2.Add(cardUnits[i]);
            } else
            {
                result.Stack3.Add(cardUnits[i]);
            }
        }

        return result;
    }

    private static TreeCard? FindDragonHall(UserCard userCard)
    {
        for (int i = 0; i < Constant.ChinesePoker.MaxNumberOfCardsOfUser; i++)
        {
            if (userCard.Spade.Collection[i] == null 
                && userCard.Clover.Collection[i] == null 
                && userCard.Diamonds.Collection[i] == null 
                && userCard.Hearts.Collection[i] == null)
            {
                return null;
            }
        }

        return Mapping.MappingStackPoker(userCard);
    }

    private static TreeCard? FindRoyalFlush(UserCard userCard)
    {
        var result = new TreeCard();
        var numberOfSpade = userCard.Spade.TotalCardNumber;
        var numberOfClover = userCard.Clover.TotalCardNumber;
        var numberOfDiamonds = userCard.Diamonds.TotalCardNumber;
        var numberOfHearts = userCard.Hearts.TotalCardNumber;

        var validSpade = numberOfSpade == 0 || numberOfSpade == 3 || numberOfSpade == 5 || numberOfSpade == 8 || numberOfSpade == 10; 
        var validClover = numberOfClover == 0 || numberOfClover == 3 || numberOfClover == 5 || numberOfClover == 8 || numberOfClover == 10;
        var validDiamonds = numberOfDiamonds == 0 || numberOfDiamonds == 3 || numberOfDiamonds == 5 || numberOfDiamonds == 8 || numberOfDiamonds == 10;
        var validHearts = numberOfHearts == 0 || numberOfHearts == 3 || numberOfHearts == 5 || numberOfHearts == 8 || numberOfHearts == 10;

        if (validSpade == false || validClover == false || validDiamonds == false || validHearts == false)
        {
            return null;
        }

        // Find Stack 3
        if (numberOfSpade == 3 || numberOfSpade == 8)
        {
            var newSpadeCollection = userCard.Spade.Collection;
            for (var i = 0; i < 3; i++)
            {
                var card = userCard.Spade.RealCard[i];
                result.Stack3.Add(card);
                newSpadeCollection[card.CardNumber] = null;
            }
            userCard.Spade = new TypeCard(newSpadeCollection);
            numberOfSpade = userCard.Spade.TotalCardNumber;
        } 
        else if (numberOfClover == 3 || numberOfClover == 8)
        {
            var newCloverCollection = userCard.Clover.Collection;
            for (var i = 0; i < 3; i++)
            {
                var card = userCard.Clover.RealCard[i];
                result.Stack3.Add(card);
                newCloverCollection[card.CardNumber] = null;
            }
            userCard.Clover = new TypeCard(newCloverCollection);
            numberOfClover = userCard.Clover.TotalCardNumber;
        }
        else if (numberOfDiamonds == 3 || numberOfDiamonds == 8)
        {
            var newDiamondsCollection = userCard.Diamonds.Collection;
            for (var i = 0; i < 3; i++)
            {
                var card = userCard.Diamonds.RealCard[i];
                result.Stack3.Add(card);
                newDiamondsCollection[card.CardNumber] = null;
            }
            userCard.Diamonds = new TypeCard(newDiamondsCollection);
            numberOfDiamonds = userCard.Diamonds.TotalCardNumber;
        }
        else if (numberOfHearts == 3 || numberOfHearts == 8)
        {
            var newHeartsCollection = userCard.Hearts.Collection;
            for (var i = 0; i < 3; i++)
            {
                var card = userCard.Hearts.RealCard[i];
                result.Stack3.Add(card);
                newHeartsCollection[card.CardNumber] = null;
            }
            userCard.Hearts = new TypeCard(newHeartsCollection);
            numberOfHearts = userCard.Hearts.TotalCardNumber;
        }

        // Find stack 1
        if (numberOfSpade > numberOfClover
            && numberOfSpade > numberOfDiamonds
            && numberOfSpade > numberOfHearts)
        {
            var newSpadeCollection = userCard.Spade.Collection;
            for (var i = 0; i < 5; i++)
            {
                var card = userCard.Spade.RealCard[i];
                result.Stack1.Add(card);
                newSpadeCollection[card.CardNumber] = null;
            }
            userCard.Spade = new TypeCard(newSpadeCollection);
            numberOfSpade = userCard.Spade.TotalCardNumber;
        } else if (numberOfClover > numberOfSpade
            && numberOfClover > numberOfDiamonds
            && numberOfClover > numberOfHearts)
        {
            var newCloverCollection = userCard.Clover.Collection;
            for (var i = 0; i < 5; i++)
            {
                var card = userCard.Clover.RealCard[i];
                result.Stack1.Add(card);
                newCloverCollection[card.CardNumber] = null;
            }
            userCard.Clover = new TypeCard(newCloverCollection);
            numberOfClover = userCard.Clover.TotalCardNumber;
        }
        else if (numberOfDiamonds > numberOfSpade
            && numberOfDiamonds > numberOfClover
            && numberOfDiamonds > numberOfHearts)
        {
            var newDiamondsCollection = userCard.Diamonds.Collection;
            for (var i = 0; i < 5; i++)
            {
                var card = userCard.Diamonds.RealCard[i];
                result.Stack1.Add(card);
                newDiamondsCollection[card.CardNumber] = null;
            }
            userCard.Diamonds = new TypeCard(newDiamondsCollection);
            numberOfDiamonds = userCard.Diamonds.TotalCardNumber;
        }
        else if (numberOfHearts > numberOfSpade
           && numberOfHearts > numberOfClover
           && numberOfHearts > numberOfDiamonds)
        {
            var newHeartsCollection = userCard.Hearts.Collection;
            for (var i = 0; i < 5; i++)
            {
                var card = userCard.Hearts.RealCard[i];
                result.Stack1.Add(card);
                newHeartsCollection[card.CardNumber] = null;
            }
            userCard.Hearts = new TypeCard(newHeartsCollection);
            numberOfHearts = userCard.Hearts.TotalCardNumber;
        }

        // Find stack 2
        if (numberOfSpade > 0)
        {
            var newSpadeCollection = userCard.Spade.Collection;
            for (var i = 0; i < 5; i++)
            {
                var card = userCard.Spade.RealCard[i];
                result.Stack2.Add(card);
                newSpadeCollection[card.CardNumber] = null;
            }
            userCard.Spade = new TypeCard(newSpadeCollection);
            numberOfSpade = userCard.Spade.TotalCardNumber;
        }
        else if (numberOfClover > 0)
        {
            var newCloverCollection = userCard.Clover.Collection;
            for (var i = 0; i < 5; i++)
            {
                var card = userCard.Clover.RealCard[i];
                result.Stack2.Add(card);
                newCloverCollection[card.CardNumber] = null;
            }
            userCard.Clover = new TypeCard(newCloverCollection);
            numberOfClover = userCard.Clover.TotalCardNumber;
        }
        else if (numberOfDiamonds > 0)
        {
            var newDiamondsCollection = userCard.Diamonds.Collection;
            for (var i = 0; i < 5; i++)
            {
                var card = userCard.Diamonds.RealCard[i];
                result.Stack2.Add(card);
                newDiamondsCollection[card.CardNumber] = null;
            }
            userCard.Diamonds = new TypeCard(newDiamondsCollection);
            numberOfDiamonds = userCard.Diamonds.TotalCardNumber;
        }
        else if (numberOfHearts > 0)
        {
            var newHeartsCollection = userCard.Hearts.Collection;
            for (var i = 0; i < 5; i++)
            {
                var card = userCard.Hearts.RealCard[i];
                result.Stack2.Add(card);
                newHeartsCollection[card.CardNumber] = null;
            }
            userCard.Hearts = new TypeCard(newHeartsCollection);
            numberOfHearts = userCard.Hearts.TotalCardNumber;
        }
        return result;
    }
}
