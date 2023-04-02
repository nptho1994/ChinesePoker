using pk_Application.Common;

namespace DemoChinesePoker
{
    public partial class Form1 : Form
    {
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

            var initForUser1 = initPoker.GetCardForUser(0, swapCard);
            btn_User1_One1.Text =   initForUser1[0].ToString();
            btn_User1_One2.Text =   initForUser1[1].ToString();
            btn_User1_One3.Text =   initForUser1[2].ToString();
            btn_User1_One4.Text =   initForUser1[3].ToString();
            btn_User1_One5.Text =   initForUser1[4].ToString();
            btn_User1_Two1.Text =   initForUser1[5].ToString();
            btn_User1_Two2.Text =   initForUser1[6].ToString();
            btn_User1_Two3.Text =   initForUser1[7].ToString();
            btn_User1_Two4.Text =   initForUser1[8].ToString();
            btn_User1_Two5.Text =   initForUser1[9].ToString();
            btn_User1_Three1.Text = initForUser1[10].ToString();
            btn_User1_Three2.Text = initForUser1[11].ToString();
            btn_User1_Three3.Text = initForUser1[12].ToString();
        }

        private void btn_ArrangeTheCards_Click(object sender, EventArgs e)
        {

        }
    }
}