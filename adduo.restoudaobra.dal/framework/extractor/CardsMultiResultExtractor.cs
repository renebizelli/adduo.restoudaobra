using adduo.restoudaobra.dto.result;
using adduo.restoudaobra.ie.dal;
using System.Collections.Generic;
using System.Linq;
using static Dapper.SqlMapper;

namespace adduo.restoudaobra.dal.framework.extractor

{
    public class CardsMultiResultExtractor : IMultiResultExtractor
    {
        private List<CardResult> cards { get; set; }

        public CardsMultiResultExtractor(List<CardResult> cards)
        {
            this.cards = cards;
        }

        public void Execute(object o)
        {
            var result = (GridReader)o;

            var adResult = result.Read<AdResult>();
            var addressResult = result.Read<AddressResult>();
            var ownerResult = result.Read<OwnerResult>();
            var imageResult = result.Read<AdImageResult>();

            foreach (var ad in adResult)
            {
                var card = new CardResult();
                card.Ad = ad;
                card.Address = addressResult.FirstOrDefault(f => f.id.Equals(ad.idAddress));
                card.Owner = ownerResult.FirstOrDefault(f => f.id.Equals(ad.idOwner));
                card.Owner = ownerResult.FirstOrDefault(f => f.id.Equals(ad.idOwner));
                card.Images = imageResult.Where(f => f.GuidProduct.Equals(ad.Guid)).ToList();

                this.cards.Add(card);
            }

        }
    }
}
