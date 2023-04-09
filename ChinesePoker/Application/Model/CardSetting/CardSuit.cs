using static pk_Application.Common.Constant.Config;

namespace pk_Application.Model.CardSetting;

public class CardSuit
{
    public string Value { get; set; }
    public string Name { get; set; }
    public string ShortName { get; set; }
    public string Unicode { get; set; }
    public int Index { get; set; }

    public CardSuit(string suitName)
    {
        switch (suitName)
        {
            case Suit.NameSpades:
                Value = Suit.ValueSpades;
                ShortName = Suit.ShortNameSpades;
                Name = Suit.NameSpades;
                Unicode = Suit.UnicodeSpades;
                Index = Suit.IndexOfSpades;
                break;
            case Suit.NameClubs:
                Value = Suit.ValueClubs;
                ShortName = Suit.ShortNameClubs;
                Name = Suit.NameClubs;
                Unicode = Suit.UnicodeClubs;
                Index = Suit.IndexOfClubs;
                break;
            case Suit.NameDiamonds:
                Value = Suit.ValueDiamonds;
                ShortName = Suit.ShortNameDiamonds;
                Name = Suit.NameDiamonds;
                Unicode = Suit.UnicodeDiamonds;
                Index = Suit.IndexOfDiamonds;
                break;
            case Suit.NameHearts:
                Value = Suit.ValueHearts;
                ShortName = Suit.ShortNameHearts;
                Name = Suit.NameHearts;
                Unicode = Suit.UnicodeHearts;
                Index = Suit.IndexOfHearts;
                break;

            default:
                throw new Exception($"Can not get suit by name {suitName}");
        }
    }

    public CardSuit(int suitIndex)
    {
        switch (suitIndex)
        {
            case Suit.IndexOfSpades:
                Value = Suit.ValueSpades;
                ShortName = Suit.ShortNameSpades;
                Name = Suit.NameSpades;
                Unicode = Suit.UnicodeSpades;
                Index = Suit.IndexOfSpades;
                break;
            case Suit.IndexOfClubs:
                Value = Suit.ValueClubs;
                ShortName = Suit.ShortNameClubs;
                Name = Suit.NameClubs;
                Unicode = Suit.UnicodeClubs;
                Index = Suit.IndexOfClubs;
                break;
            case Suit.IndexOfDiamonds:
                Value = Suit.ValueDiamonds;
                ShortName = Suit.ShortNameDiamonds;
                Name = Suit.NameDiamonds;
                Unicode = Suit.UnicodeDiamonds;
                Index = Suit.IndexOfDiamonds;
                break;
            case Suit.IndexOfHearts:
                Value = Suit.ValueHearts;
                ShortName = Suit.ShortNameHearts;
                Name = Suit.NameHearts;
                Unicode = Suit.UnicodeHearts;
                Index = Suit.IndexOfHearts;
                break;

            default:
                throw new Exception($"Can not get suit by index of suit {suitIndex}");
        }
    }
}