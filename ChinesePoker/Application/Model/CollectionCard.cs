using pk_Application.Common;
using System.Net.Http.Headers;

namespace pk_Application.Model;

public class CollectionCard
{
    public StackThree StackThree { get; set; }
    public StackTwo StackTwo { get; set; }
    public StackOne StackFirst { get; set; }
    public List<CardUnit> CardsSorted { get; set; } = new List<CardUnit>();

    public CollectionCard(TreeCard treeCard)
    {
        StackThree = new StackThree(treeCard.StackThree);
        StackTwo = new StackTwo(treeCard.StackTwo);
        StackFirst = new StackOne(treeCard.StackFirst);

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
