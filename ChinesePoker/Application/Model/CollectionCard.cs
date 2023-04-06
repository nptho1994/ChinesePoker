using pk_Application.Common;
using System.Net.Http.Headers;

namespace pk_Application.Model;

public class CollectionCard
{
    public StackFive StackThree { get; set; }
    public StackFive StackTwo { get; set; }
    public StackThree StackFirst { get; set; }
    public List<CardUnit> CardsSorted { get; set; } = new List<CardUnit>();

    public CollectionCard(TreeCard treeCard)
    {
        StackThree = new StackFive(treeCard.StackThree);
        StackTwo = new StackFive(treeCard.StackTwo);
        StackFirst = new StackThree(treeCard.StackFirst);

        CardsSorted.AddRange(StackThree.TotalCard);
        CardsSorted.AddRange(StackTwo.TotalCard);
        CardsSorted.AddRange(StackFirst.TotalCard);
    }

    public void SortCard()
    {
        CardsSorted = new List<CardUnit>();
        CardsSorted.AddRange(StackThree.TotalCard);
        CardsSorted.AddRange(StackTwo.TotalCard);
        CardsSorted.AddRange(StackFirst.TotalCard);
    }
}
