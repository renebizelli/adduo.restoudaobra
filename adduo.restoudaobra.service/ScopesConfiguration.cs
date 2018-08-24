using adduo.helper.image;
using adduo.restoudaobra.dal;
using adduo.restoudaobra.dal.framework.database;
using adduo.restoudaobra.ie.dal;
using adduo.restoudaobra.ie.parser;
using adduo.restoudaobra.ie.service;
using adduo.restoudaobra.parser;
using adduo.restoudaobra.service.ad;
using adduo.restoudaobra.service.ad.register;
using adduo.restoudaobra.service.address;
using adduo.restoudaobra.service.card;
using adduo.restoudaobra.service.contact;
using adduo.restoudaobra.service.emailhtml;
using adduo.restoudaobra.service.login;
using adduo.restoudaobra.service.owner;
using adduo.restoudaobra.service.owner.validation;
using adduo.restoudaobra.service.search;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace adduo.restoudaobra.service
{
    public class ScopesConfiguration
    {
        public static void Configuration(IServiceCollection services)
        {
            services.AddTransient<OwnerManager>();
            services.AddTransient<AdManager>();
            services.AddTransient<AddressManager>();
            services.AddTransient<AdRegister>();
            services.AddTransient<SearchManager>();
            services.AddTransient<ContactManager>();

            services.AddTransient<IOwnerService, OwnerService>();
            services.AddTransient<IOwnerRegisterService, OwnerRegisterService>();
            services.AddTransient<IOwnerUpdateService, OwnerUpdateService>();
            services.AddTransient<IOwnerConfirmationService, OwnerConfirmationService>();
            services.AddTransient<IOwnerResetPasswordService, RedefinePasswordService>();
            services.AddTransient<ILoginService, LoginService>();
            services.AddTransient<IOwnerValidationService, OwnerValidationService>();

            

            services.AddTransient<IAdService, AdService>();
            services.AddTransient<ICardService, CardService>();
            services.AddTransient<IAdImageService, AdImageService>();
            services.AddTransient<IAddressService, AddressService>();
            services.AddTransient<IAdStatusService, AdStatusService>();
            services.AddTransient<ISearchService, SearchService>();
            services.AddTransient<IContactService, ContactService>();

            services.AddTransient<IAdDAL, AdDAL>();
            services.AddTransient<ICardDAL, CardDAL>();
            services.AddTransient<IAdImageDAL, AdImageDAL>();
            services.AddTransient<IAddressDAL, AddressDAL>();
            services.AddTransient<IOwnerDAL, OwnerDAL>();
            services.AddTransient<IRefefinePasswordDAL, RedefinePasswordDAL>();
            services.AddTransient<ISearchAdDAL, SearchAdDAL>();
            services.AddTransient<IAdStatusDAL, AdStatusDAL>();

            services.AddTransient<IAdStatusDAL, AdStatusDAL>();
            services.AddTransient<IAdImagePath, AdImagePathHelper>();
            services.AddTransient<IImageHelper, ImageHelper>();

            services.AddTransient<CardSearchDTOParser>();
            services.AddTransient<CardDetailDTOParser>();
            services.AddTransient<AdImageDTOParser>();
            services.AddTransient<CardRegisterDTOParser>();
            services.AddTransient<AddressRegisterDTOParser>();

            services.AddTransient<DapperFriendly>();

            services.AddTransient<CPFAlreadyValidation>();
            services.AddTransient<EmailAlreadyValidation>();
            services.AddTransient<EmailNotFoundValidation>();
            services.AddTransient<CPFNotFoundValidation>();

            services.AddTransient<ConfirmationEmailHtml>();
            services.AddTransient<ContactEmailHtml>();
            services.AddTransient<ResetPasswordSolicitationEmailHtml>();
            services.AddTransient<InviteROEmailHtml>();
        }
    }
}
