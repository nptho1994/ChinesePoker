namespace pk_Application.Model;

public class CardUnit
{
    public int CardNumber { get; set; }
    public int Type { get; set; }
    public int IndexOfDeck { get; set; }

    public override string ToString()
    {
        var result = string.Empty;
        result += CardNumber + "";
        var convertType = string.Empty;
        switch (Type)
        {
            case 1:
                convertType = "♠";  // "Spade";      //♠	2660
                break;
            case 2:
                convertType = "♣";  // "Clover";     //♣	2663
                break;
            case 3:
                convertType = "♢";  // "Diamonds";   //♢	2662
                break;
            case 4:
                convertType = "♡";  // "Hearts";     //♡	2661
                break;
            default:
                break;
        }

        result += convertType;
        return result;
    }
}
