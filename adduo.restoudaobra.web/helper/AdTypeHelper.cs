using adduo.restoudaobra.constants;
using adduo.restoudaobra.dto;
using adduo.restoudaobra.web.model;

namespace adduo.restoudaobra.web.helper
{
    public class AdTypeHelper
    {
        public static AdTypeViewModel Get(CardDetailDTO card)
        {
            return Get(card.Ad.Type);
        }

        public static AdTypeViewModel Get(CardSearchDTO card)
        {
            return Get(card.Ad.Type);

        }

        public static AdTypeViewModel Get(AD_TYPE type)
        {
            return new AdTypeViewModel(
                type == AD_TYPE.DONATION ? "Doando" : "Vendendo",
                type == AD_TYPE.DONATION ? "doacao" : "venda",
                type == AD_TYPE.DONATION ? "donation" : "sale",
                type.Equals(AD_TYPE.SALE),
                type);
        }

    }
}