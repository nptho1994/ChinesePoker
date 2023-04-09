namespace pk_Application.Common;

public static class Constant
{
    public static class Setting
    {
        public const int MaxNumberOfCardsOfDeck = 52;
        public const int MaxNumberOfCardsOfUser = 13;
        public const int MaxNumberOfUser = 4;
        public const int MaxNumberOfStack1 = 5;
        public const int MaxNumberOfStack2 = 5;
        public const int MaxNumberOfStack3 = 3;
    }

    public static class StackSetting
    {
        public static class StackOneSetting
        {
            public const int MaxNumberOfMaxCard = 784; // 5C13
            public const int MaxNumberOfOneDoubleCard = 13 * 286; // 13 * 3C13
            public const int MaxNumberOfTwoDoubleCard = 2197; // 13 * 13 * 13
            public const int MaxNumberOfTripleCard = 2197; // 13 * 13 * 13
            public const int MaxNumberOfBoat = 169; // 13 * 13
            public const int MaxNumberOfStraight = 9; // 13 * 13
            public const int MaxNumberOfFlush = 1287; // 13 * 13
        }
    }

    public static class Config
    {
        public static class Desk
        {
            public const string Card_1_S = "1♠";
            public const string Card_2_S = "2♠";
            public const string Card_3_S = "3♠";
            public const string Card_4_S = "4♠";
            public const string Card_5_S = "5♠";
            public const string Card_6_S = "6♠";
            public const string Card_7_S = "7♠";
            public const string Card_8_S = "8♠";
            public const string Card_9_S = "9♠";
            public const string Card_10_S = "10♠";
            public const string Card_J_S = "J♠";
            public const string Card_Q_S = "Q♠";
            public const string Card_K_S = "K♠";
            public const string Card_1_C = "1♣";
            public const string Card_2_C = "2♣";
            public const string Card_3_C = "3♣";
            public const string Card_4_C = "4♣";
            public const string Card_5_C = "5♣";
            public const string Card_6_C = "6♣";
            public const string Card_7_C = "7♣";
            public const string Card_8_C = "8♣";
            public const string Card_9_C = "9♣";
            public const string Card_10_C = "10♣";
            public const string Card_J_C = "J♣";
            public const string Card_Q_C = "Q♣";
            public const string Card_K_C = "K♣";
            public const string Card_1_D = "1♢";
            public const string Card_2_D = "2♢";
            public const string Card_3_D = "3♢";
            public const string Card_4_D = "4♢";
            public const string Card_5_D = "5♢";
            public const string Card_6_D = "6♢";
            public const string Card_7_D = "7♢";
            public const string Card_8_D = "8♢";
            public const string Card_9_D = "9♢";
            public const string Card_10_D = "10♢";
            public const string Card_J_D = "J♢";
            public const string Card_Q_D = "Q♢";
            public const string Card_K_D = "K♢";
            public const string Card_1_H = "1♡";
            public const string Card_2_H = "2♡";
            public const string Card_3_H = "3♡";
            public const string Card_4_H = "4♡";
            public const string Card_5_H = "5♡";
            public const string Card_6_H = "6♡";
            public const string Card_7_H = "7♡";
            public const string Card_8_H = "8♡";
            public const string Card_9_H = "9♡";
            public const string Card_10_H = "10♡";
            public const string Card_J_H = "J♡";
            public const string Card_Q_H = "Q♡";
            public const string Card_K_H = "K♡";

            public const string UuidCard_1_S = "1S";
            public const string UuidCard_2_S = "2S";
            public const string UuidCard_3_S = "3S";
            public const string UuidCard_4_S = "4S";
            public const string UuidCard_5_S = "5S";
            public const string UuidCard_6_S = "6S";
            public const string UuidCard_7_S = "7S";
            public const string UuidCard_8_S = "8S";
            public const string UuidCard_9_S = "9S";
            public const string UuidCard_10_S = "10S";
            public const string UuidCard_J_S = "JS";
            public const string UuidCard_Q_S = "QS";
            public const string UuidCard_K_S = "KS";
            public const string UuidCard_1_C = "1C";
            public const string UuidCard_2_C = "2C";
            public const string UuidCard_3_C = "3C";
            public const string UuidCard_4_C = "4C";
            public const string UuidCard_5_C = "5C";
            public const string UuidCard_6_C = "6C";
            public const string UuidCard_7_C = "7C";
            public const string UuidCard_8_C = "8C";
            public const string UuidCard_9_C = "9C";
            public const string UuidCard_10_C = "10C";
            public const string UuidCard_J_C = "JC";
            public const string UuidCard_Q_C = "QC";
            public const string UuidCard_K_C = "KC";
            public const string UuidCard_1_D = "1D";
            public const string UuidCard_2_D = "2D";
            public const string UuidCard_3_D = "3D";
            public const string UuidCard_4_D = "4D";
            public const string UuidCard_5_D = "5D";
            public const string UuidCard_6_D = "6D";
            public const string UuidCard_7_D = "7D";
            public const string UuidCard_8_D = "8D";
            public const string UuidCard_9_D = "9D";
            public const string UuidCard_10_D = "10D";
            public const string UuidCard_J_D = "JD";
            public const string UuidCard_Q_D = "QD";
            public const string UuidCard_K_D = "KD";
            public const string UuidCard_1_H = "1H";
            public const string UuidCard_2_H = "2H";
            public const string UuidCard_3_H = "3H";
            public const string UuidCard_4_H = "4H";
            public const string UuidCard_5_H = "5H";
            public const string UuidCard_6_H = "6H";
            public const string UuidCard_7_H = "7H";
            public const string UuidCard_8_H = "8H";
            public const string UuidCard_9_H = "9H";
            public const string UuidCard_10_H = "10H";
            public const string UuidCard_J_H = "JH";
            public const string UuidCard_Q_H = "QH";
            public const string UuidCard_K_H = "KH";

        }

        public static class CardOfHand
        {
            public const string ValidUuidCharacter = "0123456789ABCDEF";
            public const string ValidRankName = "1234567890JQK";
            public const string ValidSuitShorName = "SCDH";
        }

        /// <summary>
        /// Config suit (value, name,  unicode, index)
        /// </summary>
        public static class Suit
        {
            public const string ValueSpades = "♠";
            public const string ValueClubs = "♣";
            public const string ValueDiamonds = "♢";
            public const string ValueHearts = "♡";

            public const string NameSpades = "Spades";
            public const string NameClubs = "Clubs";
            public const string NameDiamonds = "Diamonds";
            public const string NameHearts = "Hearts";

            public const string UnicodeSpades = "2660";
            public const string UnicodeClubs = "2663";
            public const string UnicodeDiamonds = "2662";
            public const string UnicodeHearts = "2661";

            public const string ShortNameSpades = "S";
            public const string ShortNameClubs = "C";
            public const string ShortNameDiamonds = "D";
            public const string ShortNameHearts = "H";

            public const int IndexOfSpades =0;
            public const int IndexOfClubs = 1;
            public const int IndexOfDiamonds = 2;
            public const int IndexOfHearts = 3;
        }

        /// <summary>
        /// Config rank (name, point)
        /// </summary>
        public static class Rank
        {
            public const string NameAce = "1";
            public const string NameTwo = "2";
            public const string NameThree = "3";
            public const string NameFour = "4";
            public const string NameFive = "5";
            public const string NameSix = "6";
            public const string NameSeven = "7";
            public const string NameEight = "8";
            public const string NameNine = "9";
            public const string NameTen = "10";
            public const string NameJack = "J";
            public const string NameQueen = "Q";
            public const string NameKing = "K";

            public const int PointAce = 14;
            public const int PointTwo = 2;
            public const int PointThree =3;
            public const int PointFour = 4;
            public const int PointFive = 5;
            public const int PointSix = 6;
            public const int PointSeven = 7;
            public const int PointEight = 8;
            public const int PointNine = 9;
            public const int PointTen = 10;
            public const int PointJack = 11;
            public const int PointQueen = 12;
            public const int PointKing = 13;

            public const int IndexOfAce = 0;
            public const int IndexOfTwo = 1;
            public const int IndexOfThree = 2;
            public const int IndexOfFour = 3;
            public const int IndexOfFive = 4;
            public const int IndexOfSix = 5;
            public const int IndexOfSeven = 6;
            public const int IndexOfEight = 7;
            public const int IndexOfNine = 8;
            public const int IndexOfTen = 9;
            public const int IndexOfJack = 10;
            public const int IndexOfQueen = 11;
            public const int IndexOfKing = 12;
        }
    }
}
