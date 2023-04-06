using pk_Application.Common;
using pk_Application.Function;
using pk_Application.Model;
using System.Windows.Forms;

namespace DemoChinesePoker
{
    public partial class Form1 : Form
    {
        private List<CardUnit> _initCardUser1;
        private TreeCard _cardOfUser1;
        private CollectionCard _collectionCardForUser1;
        private List<CardUnit> _initCardUser2;
        private TreeCard _cardOfUser2;
        private CollectionCard _collectionCardForUser2;
        private List<CardUnit> _initCardUser3;
        private TreeCard _cardOfUser3;
        private CollectionCard _collectionCardForUser3;
        private List<CardUnit> _initCardUser4;
        private TreeCard _cardOfUser4;
        private CollectionCard _collectionCardForUser4;
        private decimal Amount = 0;
        private string ButtonNameSelected = string.Empty;
        private string ValueSelected = string.Empty;
        public Form1()
        {
            InitializeComponent();
            lbl_Description.Text = string.Empty;
            lbl_Stack1.Text = string.Empty;
            lbl_Stack2.Text = string.Empty;
            lbl_Stack3.Text = string.Empty;
            ReadFile();
            lbl_CurrentAmount.Text = Amount + " VND";
            nud_Bet.Value = 5000;
        }

        private void ReadFile()
        {
            string content = File.ReadAllText(@"..\..\..\Amount.txt");
            var isParseAmount = decimal.TryParse(content, out var getAmountFromFile);
            if (isParseAmount == true)
            {
                Amount = getAmountFromFile;
            }
            else
            {
                Amount = 50000;
            }
        }

        private void CreateNewPoker()
        {
            var initPoker = new InitPoker();
            var initCard = initPoker.PokerInitiation();
            var swapCard = initPoker.RandomSwap(initCard);

            // Clear cards
            rtb_User1.Text = string.Empty;
            rtb_User2.Text = string.Empty;
            rtb_User3.Text = string.Empty;
            rtb_User4.Text = string.Empty;
            for (int i = 0; i < swapCard.Count; i++)
            {
                if (i % 4 == 0)
                {
                    rtb_User1.Text += swapCard[i].ToString() + "  ";
                }
                else if (i % 4 == 1)
                {
                    rtb_User2.Text += swapCard[i].ToString() + "  ";
                }
                else if (i % 4 == 2)
                {
                    rtb_User3.Text += swapCard[i].ToString() + "  ";
                }
                else if (i % 4 == 3)
                {
                    rtb_User4.Text += swapCard[i].ToString() + "  ";
                }
            }

            _initCardUser1 = initPoker.GetCardForUser(0, swapCard);
            _initCardUser2 = initPoker.GetCardForUser(1, swapCard);
            _initCardUser3 = initPoker.GetCardForUser(2, swapCard);
            _initCardUser4 = initPoker.GetCardForUser(3, swapCard);
        }

        private CollectionCard CollectionAndSort()
        {
            var tempCard = _initCardUser1.ToList();
            var cardOfUser = new UserCard(tempCard);
            _cardOfUser1 = FindFullPoker.FindBestFullPoker(cardOfUser);
            var collectionCard = new CollectionCard(_cardOfUser1);

            if (collectionCard.StackTwo.Type > collectionCard.StackThree.Type
                || (collectionCard.StackTwo.Type == collectionCard.StackThree.Type
                && collectionCard.StackTwo.Score > collectionCard.StackThree.Score))
            {
                var swapStack = new StackFive(collectionCard.StackTwo.TotalCard);
                collectionCard.StackTwo = collectionCard.StackThree;
                collectionCard.StackThree = swapStack;
                collectionCard.SortCard();
            }

            if (collectionCard.StackFirst.Type > collectionCard.StackTwo.Type
                || (collectionCard.StackFirst.Type == collectionCard.StackTwo.Type
                    && collectionCard.StackFirst.Score > collectionCard.StackTwo.Score)
                || collectionCard.StackTwo.Type > collectionCard.StackThree.Type
                || (collectionCard.StackTwo.Type == collectionCard.StackThree.Type
                    && collectionCard.StackTwo.Score > collectionCard.StackThree.Score))
            {
                lbl_Description.Text = "Invalid";
                lbl_Stack1.Text = string.Empty;
                lbl_Stack2.Text = string.Empty;
                lbl_Stack3.Text = string.Empty;
            }
            else
            {
                lbl_Description.Text = string.Empty;
                lbl_Stack1.Text = collectionCard.StackThree.Type.ToString();
                lbl_Stack2.Text = collectionCard.StackTwo.Type.ToString();
                lbl_Stack3.Text = collectionCard.StackFirst.Type.ToString();
            }

            return collectionCard;
        }

        private void MappingCard(List<CardUnit> init)
        {
            btn_User_Three1.Text = init[0].ToString();
            btn_User_Three2.Text = init[1].ToString();
            btn_User_Three3.Text = init[2].ToString();
            btn_User_Three4.Text = init[3].ToString();
            btn_User_Three5.Text = init[4].ToString();
            btn_User1_Two1.Text = init[5].ToString();
            btn_User1_Two2.Text = init[6].ToString();
            btn_User1_Two3.Text = init[7].ToString();
            btn_User1_Two4.Text = init[8].ToString();
            btn_User1_Two5.Text = init[9].ToString();
            btn_User_One1.Text = init[10].ToString();
            btn_User_One2.Text = init[11].ToString();
            btn_User_One3.Text = init[12].ToString();
        }

        private void btn_GenerateNewPokerAndSort_Click(object sender, EventArgs e)
        {
            CreateNewPoker();
            var getNewCollection = CollectionAndSort();
            MappingCard(getNewCollection.CardsSorted);
        }

        private void btn_DistributeTheCards_Click_1(object sender, EventArgs e)
        {
            CreateNewPoker();
            MappingCard(_initCardUser1);
        }

        private void btn_ArrangeTheCards_Click_1(object sender, EventArgs e)
        {
            CollectionCard collectionCard = CollectionAndSort();

            _collectionCardForUser1 = collectionCard;

            MappingCard(_collectionCardForUser1.CardsSorted);
        }

        private void btn_Test_Click(object sender, EventArgs e)
        {
            CreateNewPoker();
            MappingCard(_initCardUser1);
            var tempCard2 = _initCardUser2.ToList();
            var cardOfUser2 = new UserCard(tempCard2);
            _cardOfUser2 = FindFullPoker.FindBestFullPoker(cardOfUser2);
            var collectionCard2 = new CollectionCard(_cardOfUser2);

            var tempCard3 = _initCardUser3.ToList();
            var cardOfUser3 = new UserCard(tempCard3);
            _cardOfUser3 = FindFullPoker.FindBestFullPoker(cardOfUser3);
            var collectionCard3 = new CollectionCard(_cardOfUser3);

            var tempCard4 = _initCardUser4.ToList();
            var cardOfUser4 = new UserCard(tempCard4);
            _cardOfUser4 = FindFullPoker.FindBestFullPoker(cardOfUser4);
            var collectionCard4 = new CollectionCard(_cardOfUser4);

            rtb_User2.Text = string.Empty;
            rtb_User3.Text = string.Empty;
            rtb_User4.Text = string.Empty;

            rtb_User2.Text += collectionCard2.StackFirst.ToString();
            rtb_User3.Text += collectionCard3.StackFirst.ToString();
            rtb_User4.Text += collectionCard4.StackFirst.ToString();

            rtb_User2.Text += "\n" + collectionCard2.StackTwo.ToString();
            rtb_User3.Text += "\n" + collectionCard3.StackTwo.ToString();
            rtb_User4.Text += "\n" + collectionCard4.StackTwo.ToString();

            rtb_User2.Text += "\n" + collectionCard2.StackThree.ToString();
            rtb_User3.Text += "\n" + collectionCard3.StackThree.ToString();
            rtb_User4.Text += "\n" + collectionCard4.StackThree.ToString();
        }

        private void rtb_1k_CheckedChanged(object sender, EventArgs e)
        {
            nud_Bet.Value = 1000 * GetPowerPet();
        }

        private void rtb_2k_CheckedChanged(object sender, EventArgs e)
        {
            nud_Bet.Value = 2000 * GetPowerPet();
        }

        private void rtb_3k_CheckedChanged(object sender, EventArgs e)
        {
            nud_Bet.Value = 3000 * GetPowerPet();
        }

        private void rtb_5k_CheckedChanged(object sender, EventArgs e)
        {
            nud_Bet.Value = 5000 * GetPowerPet();
        }

        private void rtb_x1_CheckedChanged(object sender, EventArgs e)
        {
            nud_Bet.Value = 1000 * GetPetAmount();
        }

        private void rtb_x10_CheckedChanged(object sender, EventArgs e)
        {
            nud_Bet.Value = 10000 * GetPetAmount();
        }

        private void rtb_x100_CheckedChanged(object sender, EventArgs e)
        {
            nud_Bet.Value = 100000 * GetPetAmount();
        }

        private void rtb_x1000_CheckedChanged(object sender, EventArgs e)
        {
            nud_Bet.Value = 1000000 * GetPetAmount();
        }

        private int GetPetAmount()
        {
            return Convert.ToInt32(rtb_1k.Checked)
                        + Convert.ToInt32(rtb_2k.Checked) * 2
                        + Convert.ToInt32(rtb_3k.Checked) * 3
                        + Convert.ToInt32(rtb_5k.Checked) * 5;
        }

        private int GetPowerPet()
        {
            return Convert.ToInt32(rtb_x1.Checked)
                            + Convert.ToInt32(rtb_x10.Checked) * 10
                            + Convert.ToInt32(rtb_x100.Checked) * 100
                            + Convert.ToInt32(rtb_x1000.Checked) * 1000;
        }

        private string SwapCardInScreen(string swapText)
        {
            var result = ValueSelected;
            switch (ButtonNameSelected)
            {
                case "btn_User_One1":
                    result = btn_User_One1.Text;
                    btn_User_One1.Text = swapText;
                    break;

                case "btn_User_One2":
                    result = btn_User_One2.Text;
                    btn_User_One2.Text = swapText;
                    break;

                case "btn_User_One3":
                    result = btn_User_One3.Text;
                    btn_User_One3.Text = swapText;
                    break;

                case "btn_User1_Two1":
                    result = btn_User1_Two1.Text;
                    btn_User1_Two1.Text = swapText;
                    break;

                case "btn_User1_Two2":
                    result = btn_User1_Two2.Text;
                    btn_User1_Two2.Text = swapText;
                    break;

                case "btn_User1_Two3":
                    result = btn_User1_Two3.Text;
                    btn_User1_Two3.Text = swapText;
                    break;

                case "btn_User1_Two4":
                    result = btn_User1_Two4.Text;
                    btn_User1_Two4.Text = swapText;
                    break;

                case "btn_User1_Two5":
                    result = btn_User1_Two5.Text;
                    btn_User1_Two5.Text = swapText;
                    break;

                case "btn_User_Three1":
                    result = btn_User_Three1.Text;
                    btn_User_Three1.Text = swapText;
                    break;

                case "btn_User_Three2":
                    result = btn_User_Three2.Text;
                    btn_User_Three2.Text = swapText;
                    break;

                case "btn_User_Three3":
                    result = btn_User_Three3.Text;
                    btn_User_Three3.Text = swapText;
                    break;

                case "btn_User_Three4":
                    result = btn_User_Three4.Text;
                    btn_User_Three4.Text = swapText;
                    break;

                case "btn_User_Three5":
                    result = btn_User_Three5.Text;
                    btn_User_Three5.Text = swapText;
                    break;

                default:
                    break;
            }

            return result;
        }

        private void btn_User_One1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ButtonNameSelected))
            {
                ValueSelected = btn_User_One1.Text;
                ButtonNameSelected = "btn_User_One1";
            }
            else
            {
                var swapText = btn_User_One1.Text;
                btn_User_One1.Text = ValueSelected;
                SwapCardInScreen(swapText);
                ButtonNameSelected = string.Empty;
                ValueSelected = string.Empty;
            }
        }

        private void btn_User_One2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ButtonNameSelected))
            {
                ValueSelected = btn_User_One2.Text;
                ButtonNameSelected = "btn_User_One2";
            }
            else
            {
                var swapText = btn_User_One2.Text;
                btn_User_One2.Text = ValueSelected; 
                SwapCardInScreen(swapText);
                ButtonNameSelected = string.Empty;
                ValueSelected = string.Empty;
            }
        }

        private void btn_User_One3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ButtonNameSelected))
            {
                ValueSelected = btn_User_One3.Text;
                ButtonNameSelected = "btn_User_One3";
            }
            else
            {
                var swapText = btn_User_One3.Text;
                btn_User_One3.Text = ValueSelected;
                SwapCardInScreen(swapText);
                ButtonNameSelected = string.Empty;
                ValueSelected = string.Empty;
            }
        }

        private void btn_User1_Two1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ButtonNameSelected))
            {
                ValueSelected = btn_User1_Two1.Text;
                ButtonNameSelected = "btn_User1_Two1";
            }
            else
            {
                var swapText = btn_User1_Two1.Text;
                btn_User1_Two1.Text = ValueSelected;
                SwapCardInScreen(swapText);
                ButtonNameSelected = string.Empty;
                ValueSelected = string.Empty;
            }
        }

        private void btn_User1_Two2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ButtonNameSelected))
            {
                ValueSelected = btn_User1_Two2.Text;
                ButtonNameSelected = "btn_User1_Two2";
            }
            else
            {
                var swapText = btn_User1_Two2.Text;
                btn_User1_Two2.Text = ValueSelected;
                SwapCardInScreen(swapText);
                ButtonNameSelected = string.Empty;
                ValueSelected = string.Empty;
            }
        }

        private void btn_User1_Two3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ButtonNameSelected))
            {
                ValueSelected = btn_User1_Two3.Text;
                ButtonNameSelected = "btn_User1_Two3";
            }
            else
            {
                var swapText = btn_User1_Two3.Text;
                btn_User1_Two3.Text = ValueSelected;
                SwapCardInScreen(swapText);
                ButtonNameSelected = string.Empty;
                ValueSelected = string.Empty;
            }
        }

        private void btn_User1_Two4_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ButtonNameSelected))
            {
                ValueSelected = btn_User1_Two4.Text;
                ButtonNameSelected = "btn_User1_Two4";
            }
            else
            {
                var swapText = btn_User1_Two4.Text;
                btn_User1_Two4.Text = ValueSelected;
                SwapCardInScreen(swapText);
                ButtonNameSelected = string.Empty;
                ValueSelected = string.Empty;
            }
        }

        private void btn_User1_Two5_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ButtonNameSelected))
            {
                ValueSelected = btn_User1_Two5.Text;
                ButtonNameSelected = "btn_User1_Two5";
            }
            else
            {
                var swapText = btn_User1_Two5.Text;
                btn_User1_Two5.Text = ValueSelected;
                SwapCardInScreen(swapText);
                ButtonNameSelected = string.Empty;
                ValueSelected = string.Empty;
            }
        }

        private void btn_User_Three1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ButtonNameSelected))
            {
                ValueSelected = btn_User_Three1.Text;
                ButtonNameSelected = "btn_User_Three1";
            }
            else
            {
                var swapText = btn_User_Three1.Text;
                btn_User_Three1.Text = ValueSelected;
                SwapCardInScreen(swapText);
                ButtonNameSelected = string.Empty;
                ValueSelected = string.Empty;
            }
        }

        private void btn_User_Three2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ButtonNameSelected))
            {
                ValueSelected = btn_User_Three2.Text;
                ButtonNameSelected = "btn_User_Three2";
            }
            else
            {
                var swapText = btn_User_Three2.Text;
                btn_User_Three2.Text = ValueSelected;
                SwapCardInScreen(swapText);
                ButtonNameSelected = string.Empty;
                ValueSelected = string.Empty;
            }
        }

        private void btn_User_Three3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ButtonNameSelected))
            {
                ValueSelected = btn_User_Three3.Text;
                ButtonNameSelected = "btn_User_Three3";
            }
            else
            {
                var swapText = btn_User_Three3.Text;
                btn_User_Three3.Text = ValueSelected;
                SwapCardInScreen(swapText);
                ButtonNameSelected = string.Empty;
                ValueSelected = string.Empty;
            }
        }

        private void btn_User_Three4_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ButtonNameSelected))
            {
                ValueSelected = btn_User_Three4.Text;
                ButtonNameSelected = "btn_User_Three4";
            }
            else
            {
                var swapText = btn_User_Three4.Text;
                btn_User_Three4.Text = ValueSelected;
                SwapCardInScreen(swapText);
                ButtonNameSelected = string.Empty;
                ValueSelected = string.Empty;
            }
        }

        private void btn_User_Three5_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ButtonNameSelected))
            {
                ValueSelected = btn_User_Three5.Text;
                ButtonNameSelected = "btn_User_Three5";
            }
            else
            {
                var swapText = btn_User_Three5.Text;
                btn_User_Three5.Text = ValueSelected;
                SwapCardInScreen(swapText);
                ButtonNameSelected = string.Empty;
                ValueSelected = string.Empty;
            }
        }
    }
}