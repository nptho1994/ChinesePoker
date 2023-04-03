using pk_Application.Common;
using pk_Application.Model;
using System.Net.Http.Headers;

namespace pk_Application.Function;

public class FindFullPoker
{
    public TreeCard FindBestFullPoker(TreeTypeCard typeCard)
    {
        var result = new TreeCard();

        // 1 FindDragonHall
        var dragonHall = FindDragonHall(typeCard);
        if (dragonHall != null)
        {
            return dragonHall;
        }

        // 2 royal flush

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

        return Mapping.MappingStackPoker(typeCard);
    }

    private TreeCard? FindRoyalFlush(TreeTypeCard typeCard)
    {
        var numberOfSpade = typeCard.CountSpade();
        var numberOfClover = typeCard.CountClover();
        var numberOfDiamonds = typeCard.CountDiamonds();
        var numberOfHearts = typeCard.CountHearts();

        var validSpade = numberOfSpade == 0 || numberOfSpade == 3 || numberOfSpade == 5 || numberOfSpade == 8 || numberOfSpade == 10 || numberOfSpade == 13; 
        var validClover = numberOfClover == 0 || numberOfClover == 3 || numberOfClover == 5 || numberOfClover == 8 || numberOfClover == 10 || numberOfClover == 13;
        var validDiamonds = numberOfDiamonds == 0 || numberOfDiamonds == 3 || numberOfDiamonds == 5 || numberOfDiamonds == 8 || numberOfDiamonds == 10 || numberOfDiamonds == 13;
        var validHearts = numberOfHearts == 0 || numberOfHearts == 3 || numberOfHearts == 5 || numberOfHearts == 8 || numberOfHearts == 10 || numberOfHearts == 13;

        if (validSpade == false || validClover == false || validDiamonds == false || validHearts == false)
        {
            return null;
        }

        // 1 Find stack 1
        var type1 = new List<CardUnit?>();
        var type2 = new List<CardUnit?>();
        if (numberOfSpade >= 5)
        {
            type1 = typeCard.Spade;
            if (numberOfClover >= 5)
            {
                type2 = typeCard.Clover;
            }
            else if (numberOfDiamonds >= 5)
            {
                type2 = typeCard.Diamonds;
            }
            else if (numberOfHearts >= 5)
            {
                type2 = typeCard.Hearts;
            }
        }
        else if (numberOfClover >= 5)
        {
            type1 = typeCard.Clover;
            if (numberOfDiamonds >= 5)
            {
                type2 = typeCard.Diamonds;
            }
            else if (numberOfHearts >= 5)
            {
                type2 = typeCard.Hearts;
            }
        }
        else if (numberOfDiamonds >= 5)
        {
            type1 = typeCard.Diamonds;
            if (numberOfHearts >= 5)
            {
                type2 = typeCard.Hearts;
            }
        }
        else if (numberOfHearts >= 5)
        {
            type1 = typeCard.Hearts;
        }

        var stack1 = GetStack1(type1, type2);
        var stack2 = GetStack1(type1, type2);
    }

    private List<CardUnit> GetStack1(List<CardUnit?> type1, List<CardUnit?> type2)
    {
        var result = new List<CardUnit>();
        var choose = 0;
        if (type1[0] != null && type2[0] == null)
        {
            choose = 1;
        }

        if (type1[0] == null && type2[0] != null)
        {
            choose = 2;
        }
        if (choose == 0)
        {
            for (int i = Constant.ChinesePoker.MaxNumberOfCardsOfUser; i > 1; i--)
            {
                if (type1[i] != null && type2[i] != null)
                {
                    continue;
                }

                if (type1[i] != null)
                {
                    choose = 1;
                    break;
                }

                if (type2[i] != null)
                {
                    choose = 2;
                    break;
                }
            }
        }

        if (choose == 1)
        {
            var card = type1[0];
            if (card != null)
            {
                result.Add(card);
            }

            for (int i = 1; i < Constant.ChinesePoker.MaxNumberOfCardsOfUser; i++)
            {
                var nextCard = type1[i];
                if (result.Count < 5 && nextCard != null)
                {
                    result.Add(nextCard); 
                }
            }
        } 
        else
        {
            var card = type2[0];
            if (card != null)
            {
                result.Add(card);
            }

            for (int i = 1; i < Constant.ChinesePoker.MaxNumberOfCardsOfUser; i++)
            {
                var nextCard = type2[i];
                if (result.Count < 5 && nextCard != null)
                {
                    result.Add(nextCard);
                }
            }

        }
        return result;
    }

}
