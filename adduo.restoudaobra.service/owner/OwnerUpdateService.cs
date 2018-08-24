using adduo.basetype.envelope;
using adduo.helper.property;
using adduo.restoudaobra.dto;
using adduo.restoudaobra.ie.dal;
using adduo.restoudaobra.ie.service;
using adduo.restoudaobra.service.owner.validation;

namespace adduo.restoudaobra.service.owner
{
    public class OwnerUpdateService : BaseService, IOwnerUpdateService
    {
        private IOwnerDAL ownerDAL { get; set; }
        private EmailAlreadyValidation emailAlreadyValidation { get; set; }
        private IOwnerValidationService validation { get; set; }

        public OwnerUpdateService(
            IOwnerDAL ownerDAL, 
            IOwnerValidationService validation,
            EmailAlreadyValidation emailAlreadyValidation)
        {
            this.ownerDAL = ownerDAL;
            this.emailAlreadyValidation = emailAlreadyValidation;
            this.validation = validation;
        }

        public BaseResponse<OwnerUpdateDTO> Update(BaseRequest<OwnerUpdateDTO> request)
        {
            Validation(request);

            if (request.Success)
            {
                ownerDAL.Update(request.Dto);
            }

            return request.CreateResponse();
        }

        private void Validation(BaseRequest<OwnerUpdateDTO> request)
        {
            PropertyHelper.ResetProperty(request.Dto);

            emailAlreadyValidation.Set(request.Dto.id);

            request.Dto.Email.AddValidation(emailAlreadyValidation);

            this.validation.Validation(request.Dto);

            request.Success = PropertyHelper.ReturnFalseIfAnyInvalid(request.Dto);
        }
    }
}
