using pk_Application.Common;
using pk_Application.Model;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;

namespace pk_Application.Function;

public static class FindFullPoker
{
    private static List<CardUnit> CardIsSorted = new List<CardUnit>();
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
        CardIsSorted = new List<CardUnit>();
        var result = new TreeCard();

        // Find stack 1
        var newUserCardAfterFindStact1 = FindBestStack(userCard);
        for (var i = 0; i < Constant.Setting.MaxNumberOfStack1; i++)
        {
            result.Stack1.Add(CardIsSorted[i]);
        }

        // Find stack 2
        var newUserCardAfterFindStact2 = FindBestStack(newUserCardAfterFindStact1);
        for (var i = Constant.Setting.MaxNumberOfStack1; i < Constant.Setting.MaxNumberOfStack1 + Constant.Setting.MaxNumberOfStack2; i++)
        {
            result.Stack2.Add(CardIsSorted[i]);
        }

        // Find stack 3
        foreach (var item in newUserCardAfterFindStact2.TotalUserCard)
        {
            result.Stack3.Add(item);
        }

        return result;
    }

    private static UserCard FindBestStack(UserCard userCard)
    {
        var totalUserCard = userCard.TotalUserCard;
        if (userCard.FourCard.Count() > 0)
        {
            for (var i = 0; i < 4; i++)
            {
                var card = userCard.FourCard[userCard.FourCard.Count() - i - 1];
                CardIsSorted.Add(card);
                var findCard = totalUserCard.FindLastIndex(x => x.CardNumber == card.CardNumber && x.Type == card.Type);
                totalUserCard.RemoveAt(findCard);
            }

            if (userCard.OneCard.Count() == 0 && userCard.CoupleCard.Count() == 0)
            {
                var card = userCard.ThreeCard[0];
                CardIsSorted.Add(card);
                var findCard = totalUserCard.FindLastIndex(x => x.CardNumber == card.CardNumber && x.Type == card.Type);
                totalUserCard.RemoveAt(findCard);
            }
            else if (userCard.OneCard.Count() == 0)
            {
                var card = userCard.CoupleCard[0];
                CardIsSorted.Add(card);
                var findCard = totalUserCard.FindLastIndex(x => x.CardNumber == card.CardNumber && x.Type == card.Type);
                totalUserCard.RemoveAt(findCard);
            }
            else
            {
                var card = userCard.OneCard[0];
                CardIsSorted.Add(card);
                var findCard = totalUserCard.FindLastIndex(x => x.CardNumber == card.CardNumber && x.Type == card.Type);
                totalUserCard.RemoveAt(findCard);
            }

            return new UserCard(totalUserCard);
        }

        if (userCard.ThreeCard.Count() > 0 && userCard.CoupleCard.Count() > 0)
        {
            for (var i = 0; i < 3; i++)
            {
                var card = userCard.ThreeCard[userCard.ThreeCard.Count() - i - 1];
                CardIsSorted.Add(card);
                var findCard = totalUserCard.FindLastIndex(x => x.CardNumber == card.CardNumber && x.Type == card.Type);
                totalUserCard.RemoveAt(findCard);
            }

            var card1 = userCard.CoupleCard[0];
            CardIsSorted.Add(card1);
            var findCard1 = totalUserCard.FindLastIndex(x => x.CardNumber == card1.CardNumber && x.Type == card1.Type);
            totalUserCard.RemoveAt(findCard1);
            var card2 = userCard.CoupleCard[userCard.CoupleCard.Count() - 1];
            CardIsSorted.Add(card2);
            var findCard2 = totalUserCard.FindLastIndex(x => x.CardNumber == card2.CardNumber && x.Type == card2.Type);
            totalUserCard.RemoveAt(findCard2);

            return new UserCard(totalUserCard);
        }

        if (userCard.Spade.TotalCardNumber > 4)
        {
            return FindFlush(userCard.Spade, totalUserCard);
        }
        if (userCard.Clover.TotalCardNumber > 4)
        {
            return FindFlush(userCard.Clover, totalUserCard);
        }
        if (userCard.Diamonds.TotalCardNumber > 4)
        {
            return FindFlush(userCard.Diamonds, totalUserCard);
        }
        if (userCard.Hearts.TotalCardNumber > 4)
        {
            return FindFlush(userCard.Hearts, totalUserCard);
        }

        if (userCard.ThreeCard.Count() > 0 && userCard.CoupleCard.Count() == 0)
        {
            for (var i = 0; i < 3; i++)
            {
                var card = userCard.ThreeCard[userCard.ThreeCard.Count() - i - 1];
                CardIsSorted.Add(card);
                var findCard = totalUserCard.FindLastIndex(x => x.CardNumber == card.CardNumber && x.Type == card.Type);
                totalUserCard.RemoveAt(findCard);
            }

            var card1 = userCard.OneCard[0];
            CardIsSorted.Add(card1);
            var findCard1 = totalUserCard.FindLastIndex(x => x.CardNumber == card1.CardNumber && x.Type == card1.Type);
            totalUserCard.RemoveAt(findCard1);
            var card2 = userCard.OneCard[1];
            CardIsSorted.Add(card2);
            var findCard2 = totalUserCard.FindLastIndex(x => x.CardNumber == card2.CardNumber && x.Type == card2.Type);
            totalUserCard.RemoveAt(findCard2);

            return new UserCard(totalUserCard);
        }

        if (userCard.CoupleCard.Count() > 2)
        {
            for (var i = 0; i < 4; i++)
            {
                var card = userCard.CoupleCard[userCard.CoupleCard.Count() - i - 1];
                CardIsSorted.Add(card);
                var findCard = totalUserCard.FindLastIndex(x => x.CardNumber == card.CardNumber && x.Type == card.Type);
                totalUserCard.RemoveAt(findCard);
            }

            var card1 = userCard.OneCard[0];
            CardIsSorted.Add(card1);
            var findCard1 = totalUserCard.FindLastIndex(x => x.CardNumber == card1.CardNumber && x.Type == card1.Type);
            totalUserCard.RemoveAt(findCard1);

            return new UserCard(totalUserCard);
        }

        if (userCard.CoupleCard.Count() > 0)
        {
            for (var i = 0; i < 2; i++)
            {
                var card = userCard.CoupleCard[userCard.CoupleCard.Count() - i - 1];
                CardIsSorted.Add(card);
                var findCard = totalUserCard.FindLastIndex(x => x.CardNumber == card.CardNumber && x.Type == card.Type);
                totalUserCard.RemoveAt(findCard);
            }

            var card1 = userCard.OneCard[0];
            CardIsSorted.Add(card1);
            var findCard1 = totalUserCard.FindLastIndex(x => x.CardNumber == card1.CardNumber && x.Type == card1.Type);
            totalUserCard.RemoveAt(findCard1);
            var card2 = userCard.OneCard[1];
            CardIsSorted.Add(card2);
            var findCard2 = totalUserCard.FindLastIndex(x => x.CardNumber == card2.CardNumber && x.Type == card2.Type);
            totalUserCard.RemoveAt(findCard2);
            var card3 = userCard.OneCard[2];
            CardIsSorted.Add(card3);
            var findCard3 = totalUserCard.FindLastIndex(x => x.CardNumber == card3.CardNumber && x.Type == card3.Type);
            totalUserCard.RemoveAt(findCard3);

            return new UserCard(totalUserCard);
        }

        if (userCard.OneCard.Count > 4)
        { 
            for (var i = 0; i < 5; i++)
            {
                var card = userCard.OneCard[userCard.OneCard.Count() - i - 1];
                CardIsSorted.Add(card);
                var findCard = totalUserCard.FindLastIndex(x => x.CardNumber == card.CardNumber && x.Type == card.Type);
                totalUserCard.RemoveAt(findCard);
            }

            return new UserCard(totalUserCard);
        }
        

        return new UserCard(totalUserCard);
    }

    private static UserCard FindFlush(TypeCard typeCard, List<CardUnit> totalUserCard)
    {
        for (var i = 0; i < 5; i++)
        {
            var card = typeCard.RealCard[typeCard.TotalCardNumber - i - 1];
            CardIsSorted.Add(card);
            var findCard = totalUserCard.FindLastIndex(x => x.CardNumber == card.CardNumber && x.Type == card.Type);
            totalUserCard.RemoveAt(findCard);
        }
        return new UserCard(totalUserCard);
    }

    private static TreeCard? FindDragonHall(UserCard userCard)
    {
        for (int i = 0; i < Constant.Setting.MaxNumberOfCardsOfUser; i++)
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
