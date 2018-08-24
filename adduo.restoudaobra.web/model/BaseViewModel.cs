namespace adduo.restoudaobra.web.model
{
    public class BaseViewModel<T>
    {
        public T Value { get; private set; }

        public BaseHelperViewModel Helper { get; private set; }

        public BaseViewModel(T value, string url)
        {
            Value = value;

            Helper = new BaseHelperViewModel
            {
                URL = url
            };
        }
    }


    public class BaseHelperViewModel
    {
        public string URL { get; set; }
    }

}
