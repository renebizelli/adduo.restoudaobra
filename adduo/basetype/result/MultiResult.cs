using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace adduo.basetype.result
{
    public class MultipleResult : BaseResult
    {
        private List<List<dynamic>> Results { get; set; }

        private int index = 1;

        public MultipleResult()
        {
            index = 1;
            Results = new List<List<dynamic>>();
        }

        public void Add(List<dynamic> result)
        {
            Results.Add(result);
        }

        public List<T> Parent<T>()
        {
            return Get<T>(0);
        }

        public List<T> Next<T>()
        {
            return Get<T>(index++);
        }

        private List<T> Get<T>(int i)
        {
            var next = new List<T>();

            if (Results.Count >= i)
            {
                var x = Results[i].Cast<T>().ToList();

                next = ((IEnumerable<T>)Results[i]).ToList();
            }

            return next;
        }
    }
}