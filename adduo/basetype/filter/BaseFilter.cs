using System;
using System.Collections.Generic;
using System.Linq;

namespace adduo.basetype.filter
{
    public class BaseFilter
    {
        public int id { get; set; }
        public Guid Guid { get; set; }
        public DateTime Date { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int idOwner { get; set; }
        public int idStatus { get; set; }
        public List<int> StatusList { get; set; }
        public string StringStatusList
        {
            get
            {
                return string.Join(",", StatusList);
            }
        }

        public BaseFilter()
        {
            StatusList = new List<int>();
        }


        public virtual bool IsEmpty()
        {
            return id.Equals(0) &&
                    idOwner.Equals(0) &&
                    !StatusList.Any() &&
                    Date.Equals(DateTime.MinValue) &&
                    Start.Equals(DateTime.MinValue) &&
                    End.Equals(DateTime.MinValue) &&
                    idStatus.Equals(0);

        }
    }
}
