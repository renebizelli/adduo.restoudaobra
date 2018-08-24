using adduo.basetype.dto;
using adduo.basetype.envelope;
using adduo.basetype.filter;
using adduo.restoudaobra.dto;
using adduo.restoudaobra.dto.filter;
using adduo.restoudaobra.constants;
using adduo.restoudaobra.ie.service;
using adduo.restoudaobra.parser;
using adduo.restoudaobra.service.ad.register;
using adduo.restoudaobra.service.address;
using System;
using System.Collections.Generic;
using System.Linq;

namespace adduo.restoudaobra.service.ad
{
    public class AdManager : BaseManager
    {
        private IAdService adService { get; set; }
        private ICardService cardService { get; set; }
        private IAdImageService adImageService { get; set; }
        private IAddressService addressService { get; set; }
        private IOwnerService ownerService { get; set; }
        private IAdStatusService adStatusService { get; set; }

        private AddressManager addressManager { get; set; }
        private AdRegister adRegister { get; set; }

        private CardDetailDTOParser cardDetailDTOParser { get; set; }
        private AdImageDTOParser adImageDTOParser { get; set; }
        private CardRegisterDTOParser cardRegisterDTOParser { get; set; }

        private int idOwner { get; set; }

        public AdManager(
            IAdService adService,
            ICardService cardService,
            IAdImageService adImageService,
            IAddressService addressService,
            IOwnerService ownerService,
            IAdStatusService adStatusService,
            AddressManager addressManager,
            AdRegister adRegister,
            CardDetailDTOParser cardDetailDTOParser,
            AdImageDTOParser adImageDTOParser,
            CardRegisterDTOParser cardRegisterDTOParser
            )
        {
            this.adService = adService;
            this.cardService = cardService;
            this.adImageService = adImageService;
            this.addressService = addressService;
            this.ownerService = ownerService;
            this.adStatusService = adStatusService;

            this.adRegister = adRegister;

            this.cardDetailDTOParser = cardDetailDTOParser;
            this.adImageDTOParser = adImageDTOParser;
            this.cardRegisterDTOParser = cardRegisterDTOParser;

            this.addressManager = addressManager;
        }

        public void SetOwner(int idOwner)
        {
            this.idOwner = idOwner;
        }

        public BaseResponse<CardRegisterDTO> Save(BaseRequest<CardRegisterDTO> request)
        {
            request.Dto.Address.idOwner = this.idOwner;
            request.Dto.Ad.idOwner = this.idOwner;

            adRegister.SetRequest(request);

            return adRegister
                .Address()
                .Images()
                .Ad()
                .Finally();
        }

        public CardDetailDTO Detail(Guid guid)
        {
            cardService.Get(new AdFilter
            {
                Guid = guid,
                StatusList = new List<int> {
                    (int)AD_STATUS.PUBLISHED,
                    (int)AD_STATUS.PAUSED,
                    (int)AD_STATUS.FINISHED,
                },
                idOwnerStatus = (int)OWNER_STATUS.ACTIVE
            }, cardDetailDTOParser);

            return (CardDetailDTO)cardDetailDTOParser.Get();
        }

        public List<AdImageDTO> Images(AdImageFilter filter)
        {
            adImageService.List(filter, adImageDTOParser);

            return adImageDTOParser.List().Cast<AdImageDTO>().ToList();
        }

        public CardRegisterDTO Get(Guid guid)
        {
            if (!guid.Equals(Guid.Empty))
            {
                var filter = new AdFilter()
                {
                    Guid = guid,
                    idOwner = idOwner,
                    StatusList = new List<int> {
                        (int)AD_STATUS.PUBLISHED,
                        (int)AD_STATUS.PAUSED,
                        (int)AD_STATUS.FINISHED
                    }
                };

                cardService.Get(filter, cardRegisterDTOParser);
            }

            var dto = (CardRegisterDTO)cardRegisterDTOParser.Get();

            return dto;
        }

        public MyAdDTO MyAdListView()
        {
            var filter = new AdFilter
            {
                idOwner = idOwner,
                StatusList = new List<int> {
                    (int)AD_STATUS.PUBLISHED,
                    (int)AD_STATUS.PAUSED,
                    (int)AD_STATUS.FINISHED
                }
            };

            var response = new MyAdDTO();

            cardService.Get(filter, cardDetailDTOParser);

            response.Cards = cardDetailDTOParser.List()
                                .Cast<CardDetailDTO>()
                                .ToList();

            response.Status = Status();

            return response;
        }

        public void ChangeStatus(BaseRequest<AdChangeStatusDTO> request)
        {
            adService.ChangeStatus(request);
        }

        public List<ItemDTO> Status()
        {
            var parser = new ItemDTOParser();

            adStatusService.List(new BaseFilter(), parser);

            return parser.List().Cast<ItemDTO>().ToList();
        }
    }
}
