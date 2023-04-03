using pk_Application.Common;

namespace pk_Application.Model;

public class TreeCard
{
    public List<CardUnit> Stack1 { get; set; } = new List<CardUnit>();
    public List<CardUnit> Stack2 { get; set; } = new List<CardUnit>();
    public List<CardUnit> Stack3 { get; set; } = new List<CardUnit>();

    public TreeCard()
    {
        for (int i = 0; i < Constant.ChinesePoker.MaxNumberOfStact1; i++)
        {
            Stack1.Add(null);
        }
        for (int i = 0; i < Constant.ChinesePoker.MaxNumberOfStact2; i++)
        {
            Stack2.Add(null);
        }
        for (int i = 0; i < Constant.ChinesePoker.MaxNumberOfStact3; i++)
        {
            Stack3.Add(null);
        }
    }
}
