using adduo.restoudaobra.constants;

namespace adduo.restoudaobra.web.model
{
    public class AdTypeViewModel
    {
        public AdTypeViewModel(string name, string URL, string productTypeClass, bool isSale, AD_TYPE type)
        {
            this.Name = name;
            this.URL = URL;
            this.ProductTypeClass = productTypeClass;
            this.isSale = isSale;
            this.Type = type;
        }

        public string Name { get; private set; }
        public string URL { get; private set; }
        public string ProductTypeClass { get; private set; }
        public bool isSale { get; private set; }
        public AD_TYPE Type { get; private set; }
    }
}
