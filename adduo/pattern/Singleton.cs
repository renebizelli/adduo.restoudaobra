namespace adduo.pattern
{
    public sealed class Singleton<T> where T : new()
    {
        static T instance;
        static readonly object padlock = new object();

        Singleton()
        {
        }

        public static T Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new T();
                    }
                    return instance;
                }
            }
        }
    }
}
