using pk_Application.Model;

namespace pk_Application.Function;

public class MakeScore
{
    public int ScoreOfUser1 { get; set; }
    public int ScoreOfUser2 { get; set; }
    public int ScoreOfUser3 { get; set; }
    public int ScoreOfUser4 { get; set; }

    public MakeScore(CollectionCard collection1, CollectionCard collection2, CollectionCard collection3, CollectionCard collection4)
    {
        ScoreOfUser1 += CalculateScoreBetweenTwoUser(collection1, collection2);
        ScoreOfUser1 += CalculateScoreBetweenTwoUser(collection1, collection3);
        ScoreOfUser1 += CalculateScoreBetweenTwoUser(collection1, collection4);

        ScoreOfUser2 += CalculateScoreBetweenTwoUser(collection2, collection1);
        ScoreOfUser2 += CalculateScoreBetweenTwoUser(collection2, collection3);
        ScoreOfUser2 += CalculateScoreBetweenTwoUser(collection2, collection4);

        ScoreOfUser3 += CalculateScoreBetweenTwoUser(collection3, collection1);
        ScoreOfUser3 += CalculateScoreBetweenTwoUser(collection3, collection2);
        ScoreOfUser3 += CalculateScoreBetweenTwoUser(collection3, collection4);

        ScoreOfUser4 += CalculateScoreBetweenTwoUser(collection4, collection1);
        ScoreOfUser4 += CalculateScoreBetweenTwoUser(collection4, collection2);
        ScoreOfUser4 += CalculateScoreBetweenTwoUser(collection4, collection3);
    }

    private int CalculateScoreBetweenTwoUser(CollectionCard collection1, CollectionCard collection2)
    {
        if (collection1.StackThree.Type == collection2.StackThree.Type
            && collection1.StackThree.Score == collection2.StackThree.Score)
        {
            return 0;
        }
        else if (collection1.StackThree.Type > collection2.StackThree.Type 
            || (collection1.StackThree.Type == collection2.StackThree.Type
            && collection1.StackThree.Score > collection2.StackThree.Score))
        {
            return collection1.StackThree.GetNumberWinBetStactThree();
        } 
        else
        {
            return -collection2.StackThree.GetNumberWinBetStactThree();
        }
    }
}
