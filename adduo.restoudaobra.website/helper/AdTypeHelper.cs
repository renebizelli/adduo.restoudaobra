using adduo.restoudaobra.constants;
using adduo.restoudaobra.dto;
using adduo.restoudaobra.website.model;

namespace adduo.restoudaobra.website.helper
{
    public class AdTypeHelper
    {
        public static AdTypeViewModel Get(CardDetailDTO card)
        {
            return new AdTypeViewModel(
                card.Ad.Type == AD_TYPE.DONATION ? "Doação" : "Venda",
                card.Ad.Type == AD_TYPE.DONATION ? "doacao" : "venda",
                card.Ad.Type == AD_TYPE.DONATION ? "product-type-donation" : "product-type-sale",
                card.Ad.Type.Equals(AD_TYPE.SALE),
                card.Ad.Type);
        }

        public static AdTypeViewModel Get(CardSearchDTO card)
        {
            return new AdTypeViewModel(
                card.Ad.Type == AD_TYPE.DONATION ? "Doação" : "Venda",
                card.Ad.Type == AD_TYPE.DONATION ? "doacao" : "venda",
                card.Ad.Type == AD_TYPE.DONATION ? "product-type-donation" : "product-type-sale",
                card.Ad.Type.Equals(AD_TYPE.SALE),
                card.Ad.Type);
        }
    }
}