using adduo.restoudaobra.dto;

namespace adduo.restoudaobra.web.model
{
    public class CardViewModel
    {
        public int Index { get; private set; }
        public CardSearchDTO Card { get; private set; }

        public CardViewModel(CardSearchDTO card, int index)
        {
            Card = card;
            Index = index;
        }
    }
}
