using pk_Application.Common;
using pk_Application.Function;
using pk_Application.Model;

namespace DemoChinesePoker
{
    public partial class Form1 : Form
    {
        private List<CardUnit> _initCardUser;
        private TreeCard _cardOfUser1;
        private CollectionCard _collectionCardForUser1;
        public Form1()
        {
            InitializeComponent();
            lbl_Description.Text = string.Empty;
            lbl_Stack1.Text = string.Empty;
            lbl_Stack2.Text = string.Empty;
            lbl_Stack3.Text = string.Empty;
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

            _initCardUser = initPoker.GetCardForUser(0, swapCard);
        }

        private CollectionCard CollectionAndSort()
        {
            var tempCard = _initCardUser.ToList();
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
                lbl_Stack1.Text = collectionCard.StackThree.ToString();
                lbl_Stack2.Text = collectionCard.StackTwo.ToString();
                lbl_Stack3.Text = collectionCard.StackFirst.ToString();
            }

            return collectionCard;
        }

        private void MappingCard(List<CardUnit> init)
        {
            btn_User1_One1.Text =   init[0].ToString();
            btn_User1_One2.Text =   init[1].ToString();
            btn_User1_One3.Text =   init[2].ToString();
            btn_User1_One4.Text =   init[3].ToString();
            btn_User1_One5.Text =   init[4].ToString();
            btn_User1_Two1.Text =   init[5].ToString();
            btn_User1_Two2.Text =   init[6].ToString();
            btn_User1_Two3.Text =   init[7].ToString();
            btn_User1_Two4.Text =   init[8].ToString();
            btn_User1_Two5.Text =   init[9].ToString();
            btn_User1_Three1.Text = init[10].ToString();
            btn_User1_Three2.Text = init[11].ToString();
            btn_User1_Three3.Text = init[12].ToString();
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
            MappingCard(_initCardUser);
        }

        private void btn_ArrangeTheCards_Click_1(object sender, EventArgs e)
        {
            CollectionCard collectionCard = CollectionAndSort();

            _collectionCardForUser1 = collectionCard;

            MappingCard(_collectionCardForUser1.CardsSorted);
        }

        private void btn_Test_Click(object sender, EventArgs e)
        {
            for (var i = 0; i < 100; i++)
            {
                lbl_Description.Text = "i";
                CollectionCard collectionCard = CollectionAndSort();

                _collectionCardForUser1 = collectionCard;

                MappingCard(_collectionCardForUser1.CardsSorted);
            }
        }
    }
}