using adduo.basetype.envelope;
using adduo.helper.image;
using adduo.helper.property;
using adduo.restoudaobra.dto;
using adduo.restoudaobra.ie.parser;
using adduo.restoudaobra.ie.service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace adduo.restoudaobra.api.Controllers
{
    [Route("adimage/{id:int?}")]
    public class AdImageController : AuthenticatedController
    {
        private IAdImageService adImageService { get; set; }
        private IAdImagePath adImagePath { get; set; }
        public IImageHelper imageHelper { get; set; }

        public AdImageController(
            IAdImageService AdImageService,
            IAdImagePath adImagePath,
            IImageHelper imageHelper,
            IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            this.adImageService = AdImageService;
            this.adImagePath = adImagePath;
            this.imageHelper = imageHelper;
        }

        [HttpPost]
        public ObjectResult Post()
        {
            var results = new BaseResponse<AdImageDTO>();

            if (httpContextAccessor.HttpContext != null &&
                httpContextAccessor.HttpContext.Request != null &&
                httpContextAccessor.HttpContext.Request.Form != null &&
                httpContextAccessor.HttpContext.Request.Form.Files != null &&
                httpContextAccessor.HttpContext.Request.Form.Files.Any() &&
                httpContextAccessor.HttpContext.Request.Form.ContainsKey("guid"))

            {
                var guid = Guid.Empty;

                if (Guid.TryParse(httpContextAccessor.HttpContext.Request.Form["guid"], out guid))
                {
                    adImagePath.SetGuidProduct(guid);
                    var relative = adImagePath.RelativePath();
                    var path = adImagePath.PhysicalPath();
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }

                    try
                    {
                        foreach (var file in httpContextAccessor.HttpContext.Request.Form.Files)
                        {
                            var fileInfo = new FileInfo(file.FileName);

                            var guidSplit = Guid.NewGuid().ToString().Split('-');

                            var newFileName = string.Concat(guidSplit[0], fileInfo.Extension);

                            var pathOriginalFile = adImagePath.FullPhysicalPath(fileInfo.Name);

                            var relativePathFile = adImagePath.FullRelativePath(newFileName);

                            using (var fileStream = new FileStream(pathOriginalFile, FileMode.Create))
                            {
                                file.CopyTo(fileStream);
                            }

                            var imageResizeDTO = new ImageResizeDTO(pathOriginalFile, path, newFileName, 600, 600, true);

                            var resizeReturn = imageHelper.Resize(imageResizeDTO);

                            if (resizeReturn.IsOk())
                            {
                                var index = 0;
                                int.TryParse(httpContextAccessor.HttpContext.Request.Form[fileInfo.Name], out index);

                                var dto = new AdImageDTO
                                {
                                    Index = index,
                                    GuidProduct = guid,
                                    File = newFileName,
                                    Full = relativePathFile,
                                    idOwner = GetOwner()
                                };

                                var request = new BaseRequest<AdImageDTO>(dto);

                                var response = adImageService.Save(request);

                                results.Add(response.Dto);
                            }
                        }

                        base.PrepareResult<BaseResponse<AdImageDTO>>(results);
                    }
                    catch (Exception ex)
                    {
                        base.PrepareBadRequestResult<BaseResponse<AdImageDTO>>(results);
                    }
                }
                else
                {
                    base.PrepareBadRequestResult();
                }
            }
            else
            {
                base.PrepareBadRequestResult();
            }

            return result;

        }

        [HttpDelete]
        public ObjectResult Delete(int id)
        {
            var dto = new AdImageDTO
            {
                id = id,
                idOwner = GetOwner()
            };

            var response = new BaseResponse<AdImageDTO>();

            try
            {
                if (!id.Equals(0))
                {
                    var request = new BaseRequest<AdImageDTO>(dto);

                    response.Success = adImageService.Delete(request);

                    base.PrepareResult<BaseResponse<AdImageDTO>>(response);
                }
                else
                {
                    throw new Exception("id zerado");
                }
            }
            catch (Exception ex)
            {
                base.PrepareBadRequestResult<BaseResponse<AdImageDTO>>(response);
            }

            return base.result;
        }
    }
}
