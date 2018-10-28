using Microsoft.AspNetCore.Http;

namespace adduo.restoudaobra.web.model
{
    public class BaseViewModel<T>
    {
        public T Value { get; private set; }

        public BaseHelperViewModel Helper { get; private set; }

        public BaseViewModel(T value, IHttpContextAccessor httpContextAccessor)
        {
            Value = value;

            var request = httpContextAccessor.HttpContext.Request;
            var http = request.IsHttps ? "https://" : "http://";
            var host = string.Concat(http, request.Host.ToString());

            Helper = new BaseHelperViewModel
            {
                Host = host,
                URL = request.Path.HasValue ? string.Concat(host, request.Path.Value) : host 
            };
        }
    }


    public class BaseHelperViewModel
    {
        public string URL { get; set; }
        public string Host { get; set; }
    }

}
