using pk_Application.Common;
using pk_Application.Function;
using pk_Application.Model;

namespace DemoChinesePoker
{
    public partial class Form1 : Form
    {
        private List<CardUnit> _initCardUser;
        private TreeCard _cardOfUser1;
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_DistributeTheCards_Click(object sender, EventArgs e)
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

            _initCardUser = initPoker.GetCardForUser(0, swapCard);

            btn_User1_One1.Text = _initCardUser[0].ToString();
            btn_User1_One2.Text = _initCardUser[1].ToString();
            btn_User1_One3.Text = _initCardUser[2].ToString();
            btn_User1_One4.Text = _initCardUser[3].ToString();
            btn_User1_One5.Text = _initCardUser[4].ToString();
            btn_User1_Two1.Text = _initCardUser[5].ToString();
            btn_User1_Two2.Text = _initCardUser[6].ToString();
            btn_User1_Two3.Text = _initCardUser[7].ToString();
            btn_User1_Two4.Text = _initCardUser[8].ToString();
            btn_User1_Two5.Text = _initCardUser[9].ToString();
            btn_User1_Three1.Text = _initCardUser[10].ToString();
            btn_User1_Three2.Text = _initCardUser[11].ToString();
            btn_User1_Three3.Text = _initCardUser[12].ToString();
        }

        private void btn_ArrangeTheCards_Click(object sender, EventArgs e)
        {
            var tempCard = _initCardUser.ToList();
            var cardOfUser = new UserCard(tempCard);
            _cardOfUser1 = FindFullPoker.FindBestFullPoker(cardOfUser);
            var collectionCard = new CollectionCard(_cardOfUser1);

            if (collectionCard.Stack3.Type > collectionCard.Stack2.Type
                || (collectionCard.Stack3.Type == collectionCard.Stack2.Type
                    && collectionCard.Stack3.Score > collectionCard.Stack2.Score)
                || collectionCard.Stack2.Type > collectionCard.Stack1.Type
                || (collectionCard.Stack2.Type == collectionCard.Stack1.Type
                    && collectionCard.Stack2.Score > collectionCard.Stack1.Score))
            {
                lbl_Description.Text = "Invalid";
                lbl_Stack1.Text = string.Empty;
                lbl_Stack2.Text = string.Empty;
                lbl_Stack3.Text = string.Empty;
            }
            else
            {
                lbl_Description.Text = string.Empty;
                lbl_Stack1.Text = collectionCard.Stack1.ToString();
                lbl_Stack2.Text = collectionCard.Stack2.ToString();
                lbl_Stack3.Text = collectionCard.Stack3.ToString();
            }

            btn_User1_One1.Text = collectionCard.Stack1.TotalCard[0].ToString();
            btn_User1_One2.Text = collectionCard.Stack1.TotalCard[1].ToString();
            btn_User1_One3.Text = collectionCard.Stack1.TotalCard[2].ToString();
            btn_User1_One4.Text = collectionCard.Stack1.TotalCard[3].ToString();
            btn_User1_One5.Text = collectionCard.Stack1.TotalCard[4].ToString();

            btn_User1_Two1.Text = collectionCard.Stack2.TotalCard[0].ToString();
            btn_User1_Two2.Text = collectionCard.Stack2.TotalCard[1].ToString();
            btn_User1_Two3.Text = collectionCard.Stack2.TotalCard[2].ToString();
            btn_User1_Two4.Text = collectionCard.Stack2.TotalCard[3].ToString();
            btn_User1_Two5.Text = collectionCard.Stack2.TotalCard[4].ToString();

            btn_User1_Three1.Text = collectionCard.Stack3.TotalCard[0].ToString();
            btn_User1_Three2.Text = collectionCard.Stack3.TotalCard[1].ToString();
            btn_User1_Three3.Text = collectionCard.Stack3.TotalCard[2].ToString();
        }
    }
}