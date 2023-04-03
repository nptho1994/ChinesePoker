using pk_Application.Common;

namespace pk_Application.Model;

public class TreeTypeCard
{
    public List<CardUnit?> Spade { get; set; } = new List<CardUnit?>();
    public List<CardUnit?> Clover { get; set; } = new List<CardUnit?>();
    public List<CardUnit?> Diamonds { get; set; } = new List<CardUnit?>();
    public List<CardUnit?> Hearts { get; set; } = new List<CardUnit?>();

    public TreeTypeCard()
    {
        for (int i = 0; i < Constant.ChinesePoker.MaxNumberOfUser; i++)
        {
            Spade.Add(null);
            Clover.Add(null);
            Diamonds.Add(null);
            Hearts.Add(null);
        }
    }

    public int CountSpade()
    {
        var count = 0;
        for (int i = 0; i < Constant.ChinesePoker.MaxNumberOfUser; i++)
        {
            if (Spade[i] != null)
            {
                count++;
            }
        }
        return count;
    }

    public int CountClover()
    {
        var count = 0;
        for (int i = 0; i < Constant.ChinesePoker.MaxNumberOfUser; i++)
        {
            if (Clover[i] != null)
            {
                count++;
            }
        }
        return count;
    }

    public int CountDiamonds()
    {
        var count = 0;
        for (int i = 0; i < Constant.ChinesePoker.MaxNumberOfUser; i++)
        {
            if (Diamonds[i] != null)
            {
                count++;
            }
        }
        return count;
    }

    public int CountHearts()
    {
        var count = 0;
        for (int i = 0; i < Constant.ChinesePoker.MaxNumberOfUser; i++)
        {
            if (Hearts[i] != null)
            {
                count++;
            }
        }
        return count;
    }
}
