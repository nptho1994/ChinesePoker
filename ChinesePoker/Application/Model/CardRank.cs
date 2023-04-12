using pk_Application.Common;
using System;
using static pk_Application.Common.Constant.Config;

namespace pk_Application.Model;

public class CardRank
{
    public string Name { get; set; }
    public int Point { get; set; }
    public int Index { get; set; }
    public CardRank(int index)
    {
        switch (index)
        {
            case Rank.IndexOfAce:
            case Rank.IndexOfLastAce:
                Name = Rank.NameAce;
                Point = Rank.PointAce;
                Index = Rank.IndexOfAce;
                break;
            case Rank.IndexOfTwo:
                Name = Rank.NameTwo;
                Point = Rank.PointTwo;
                Index = Rank.IndexOfTwo;
                break;
            case Rank.IndexOfThree:
                Name = Rank.NameThree;
                Point = Rank.PointThree;
                Index = Rank.IndexOfThree;
                break;
            case Rank.IndexOfFour:
                Name = Rank.NameFour;
                Point = Rank.PointFour;
                Index = Rank.IndexOfFour;
                break;
            case Rank.IndexOfFive:
                Name = Rank.NameFive;
                Point = Rank.PointFive;
                Index = Rank.IndexOfFive;
                break;
            case Rank.IndexOfSix:
                Name = Rank.NameSix;
                Point = Rank.PointSix;
                Index = Rank.IndexOfSix;
                break;
            case Rank.IndexOfSeven:
                Name = Rank.NameSeven;
                Point = Rank.PointSeven;
                Index = Rank.IndexOfSeven;
                break; ;
            case Rank.IndexOfEight:
                Name = Rank.NameEight;
                Point = Rank.PointEight;
                Index = Rank.IndexOfEight;
                break;
            case Rank.IndexOfNine:
                Name = Rank.NameNine;
                Point = Rank.PointNine;
                Index = Rank.IndexOfNine;
                break;
            case Rank.IndexOfTen:
                Name = Rank.NameTen;
                Point = Rank.PointTen;
                Index = Rank.IndexOfTen;
                break;
            case Rank.IndexOfJack:
                Name = Rank.NameJack;
                Point = Rank.PointJack;
                Index = Rank.IndexOfJack;
                break;
            case Rank.IndexOfQueen:
                Name = Rank.NameQueen;
                Point = Rank.PointQueen;
                Index = Rank.IndexOfQueen;
                break;
            case Rank.IndexOfKing:
                Name = Rank.NameKing;
                Point = Rank.PointKing;
                Index = Rank.IndexOfKing;
                break;

            default:
                throw new Exception($"Can not get rank by index {index}");
        }
    }

    public CardRank(string rankName)
    {
        switch (rankName)
        {
            case Rank.NameAce:
                Name = Rank.NameAce;
                Point = Rank.PointAce;
                Index = Rank.IndexOfAce;
                break;
            case Rank.NameTwo:
                Name = Rank.NameTwo;
                Point = Rank.PointTwo;
                Index = Rank.IndexOfTwo;
                break;
            case Rank.NameThree:
                Name = Rank.NameThree;
                Point = Rank.PointThree;
                Index = Rank.IndexOfThree;
                break;
            case Rank.NameFour:
                Name = Rank.NameFour;
                Point = Rank.PointFour;
                Index = Rank.IndexOfFour;
                break;
            case Rank.NameFive:
                Name = Rank.NameFive;
                Point = Rank.PointFive;
                Index = Rank.IndexOfFive;
                break;
            case Rank.NameSix:
                Name = Rank.NameSix;
                Point = Rank.PointSix;
                Index = Rank.IndexOfSix;
                break;
            case Rank.NameSeven:
                Name = Rank.NameSeven;
                Point = Rank.PointSeven;
                Index = Rank.IndexOfSeven;
                break; ;
            case Rank.NameEight:
                Name = Rank.NameEight;
                Point = Rank.PointEight;
                Index = Rank.IndexOfEight;
                break;
            case Rank.NameNine:
                Name = Rank.NameNine;
                Point = Rank.PointNine;
                Index = Rank.IndexOfNine;
                break;
            case Rank.NameTen:
                Name = Rank.NameTen;
                Point = Rank.PointTen;
                Index = Rank.IndexOfTen;
                break;
            case Rank.NameJack:
                Name = Rank.NameJack;
                Point = Rank.PointJack;
                Index = Rank.IndexOfJack;
                break;
            case Rank.NameQueen:
                Name = Rank.NameQueen;
                Point = Rank.PointQueen;
                Index = Rank.IndexOfQueen;
                break;
            case Rank.NameKing:
                Name = Rank.NameKing;
                Point = Rank.PointKing;
                Index = Rank.IndexOfKing;
                break;

            default:
                throw new Exception($"Can not get rank by name {rankName}");
        }
    }
}