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
                else if(i % 4 == 2)
                {
                    rtb_User3.Text += swapCard[i].ToString() + "  ";
                }
                else if(i % 4 == 3)
                {
                    rtb_User4.Text += swapCard[i].ToString() + "  ";
                }
            }

            _initCardUser = initPoker.GetCardForUser(0, swapCard);
           
            btn_User1_One1.Text =   _initCardUser[0].ToString();
            btn_User1_One2.Text =   _initCardUser[1].ToString();
            btn_User1_One3.Text =   _initCardUser[2].ToString();
            btn_User1_One4.Text =   _initCardUser[3].ToString();
            btn_User1_One5.Text =   _initCardUser[4].ToString();
            btn_User1_Two1.Text =   _initCardUser[5].ToString();
            btn_User1_Two2.Text =   _initCardUser[6].ToString();
            btn_User1_Two3.Text =   _initCardUser[7].ToString();
            btn_User1_Two4.Text =   _initCardUser[8].ToString();
            btn_User1_Two5.Text =   _initCardUser[9].ToString();
            btn_User1_Three1.Text = _initCardUser[10].ToString();
            btn_User1_Three2.Text = _initCardUser[11].ToString();
            btn_User1_Three3.Text = _initCardUser[12].ToString();
        }

        private void btn_ArrangeTheCards_Click(object sender, EventArgs e)
        {
            var cardOfUser = new UserCard(_initCardUser);
            _cardOfUser1 = FindFullPoker.FindBestFullPoker(cardOfUser);
            btn_User1_One1.Text =   _cardOfUser1.Stack1[0].ToString();
            btn_User1_One2.Text =   _cardOfUser1.Stack1[1].ToString();
            btn_User1_One3.Text =   _cardOfUser1.Stack1[2].ToString();
            btn_User1_One4.Text =   _cardOfUser1.Stack1[3].ToString();
            btn_User1_One5.Text =   _cardOfUser1.Stack1[4].ToString();

            btn_User1_Two1.Text =   _cardOfUser1.Stack2[0].ToString();
            btn_User1_Two2.Text =   _cardOfUser1.Stack2[1].ToString();
            btn_User1_Two3.Text =   _cardOfUser1.Stack2[2].ToString();
            btn_User1_Two4.Text =   _cardOfUser1.Stack2[3].ToString();
            btn_User1_Two5.Text =   _cardOfUser1.Stack2[4].ToString();

            btn_User1_Three1.Text = _cardOfUser1.Stack3[0].ToString();
            btn_User1_Three2.Text = _cardOfUser1.Stack3[1].ToString();
            btn_User1_Three3.Text = _cardOfUser1.Stack3[2].ToString();
        }
    }
}