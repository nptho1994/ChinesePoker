using pk_Application.Common;
using System.Net.Http.Headers;

namespace pk_Application.Model;

public class CollectionCard
{
    public StackFive Stack1 { get; set; }
    public StackFive Stack2 { get; set; }
    public StackThree Stack3 { get; set; }

    public CollectionCard(TreeCard treeCard)
    {
        Stack1 = new StackFive(treeCard.Stack1);
        Stack2 = new StackFive(treeCard.Stack2);
        Stack3 = new StackThree(treeCard.Stack3);
    }
}
