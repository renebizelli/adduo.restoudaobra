using adduo.methodextension;
using adduo.restoudaobra.dto;
using adduo.restoudaobra.dto.filter;
using adduo.restoudaobra.ie.dal;
using adduo.restoudaobra.ie.parser;
using adduo.restoudaobra.ie.service;

namespace adduo.restoudaobra.service.card
{
    public class CardService : BaseService, ICardService
    {
        public ICardDAL cardDAL { get; set; }

        public CardService(ICardDAL cardDAL)
        {
            this.cardDAL = cardDAL;
        }

        public void List(AdFilter filter, IParser parse) {
            cardDAL.Get(filter, parse);
        }

        public void Get(AdFilter filter, IParser parser)
        {
            cardDAL.Get(filter, parser);
        }

        private void Formatter(CardDetailDTO ad)
        {
            ad.Owner.CellPhone = ad.Owner.CellPhone.PhoneFormat();
            ad.Owner.Phone = ad.Owner.Phone.PhoneFormat();
        }
    }
}
