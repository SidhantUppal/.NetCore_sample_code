using System;
using System.Collections.Generic;
using System.Text;

namespace CFMData
{
    public class BaseGridSearch
    {
        public int PageStart { get; set; }
        public int PageSize { get; set; }
        public string SortColumn { get; set; }
        public string SortOrder { get; set; }

        public Dictionary<string, object> GetParams()
        {
            Dictionary<string, object> commandParams = new Dictionary<string, object>();
            commandParams.Add("@p_SortColumn", SortColumn);
            commandParams.Add("@p_SortOrder", SortOrder);
            commandParams.Add("@p_PageSize", PageSize);
            commandParams.Add("@p_PageStart", PageStart);

            return commandParams;
        }
    }

    public class ApplicationRoleSearch : BaseGridSearch
    {
        public string Name { get; set; }

        public int? ApplicationRoleID { get; set; }

        public bool IsActive { get; set; }

        public bool ShowInactive { get; set; }
    }

    public class SystemRoleSearch : BaseGridSearch
    {
        public int? ApplicationRoleID { get; set; }
    }
}
