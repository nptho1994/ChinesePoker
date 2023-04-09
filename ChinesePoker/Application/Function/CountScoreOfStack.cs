namespace pk_Application.Function;

public class CountScoreOfStack
{
    /// <summary>
    /// The cards input are sorted 
    /// </summary>
    /// <param name="card1"></param>
    /// <param name="card2"></param>
    /// <param name="card3"></param>
    /// <param name="card4"></param>
    /// <param name="card5"></param>
    /// <returns></returns>
    public decimal GetMaximunScoreStackOne()
    {
        var count = 0;
        for (var i1 = 1; i1 < 15; i1++)
        {
            for (var i2 = i1 + 1; i2 < 15; i2++)
            {
                for (var i3 = i2 + 1; i3 < 15; i3++)
                {
                    for (var i4 = i3 + 1; i4 < 15; i4++)
                    {
                        for (var i5 = i4 + 1; i5 < 15; i5++)
                        {
                            if (i2 - i1 > 1 || i3 - i2 > 1 || i4 - i3 > 1 || i5 - i4 > 1)
                            {
                                count++;
                            }
                        }
                    }

                }
            }
        }

        return count;
    }
}
