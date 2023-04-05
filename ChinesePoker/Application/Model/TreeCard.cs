using pk_Application.Common;

namespace pk_Application.Model;

public class TreeCard
{
    public List<CardUnit> StackThree { get; set; } = new List<CardUnit>();
    public List<CardUnit> StackTwo { get; set; } = new List<CardUnit>();
    public List<CardUnit> StackFirst { get; set; } = new List<CardUnit>();

    public TreeCard(List<CardUnit> init)
    {
        for (var i = 0; i < Constant.Setting.MaxNumberOfCardsOfUser; i++)
        {
            if (i < Constant.Setting.MaxNumberOfStack1)
            {
                StackThree.Add(init[i]);
            }
            else if (i < Constant.Setting.MaxNumberOfStack1 + Constant.Setting.MaxNumberOfStack1)
            {
                StackTwo.Add(init[i]);
            } 
            else
            {
                StackFirst.Add(init[i]);
            }
        }
    }

    public TreeCard() { }
}
