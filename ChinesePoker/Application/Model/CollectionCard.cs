using pk_Application.Common;
using System.Net.Http.Headers;

namespace pk_Application.Model;

public class CollectionCard
{
    public StackFive StackThree { get; set; }
    public StackFive StackTwo { get; set; }
    public StackThree StackFirst { get; set; }

    public CollectionCard(TreeCard treeCard)
    {
        StackThree = new StackFive(treeCard.StackThree);
        StackTwo = new StackFive(treeCard.StackTwo);
        StackFirst = new StackThree(treeCard.StackFirst);
    }
}
