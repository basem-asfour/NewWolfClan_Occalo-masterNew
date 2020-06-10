using System;
using System.Collections.Generic;
using System.Text;

namespace WolfClan.SoliHub.Messages.Base
{
    public abstract class QueryParameters 
    {
        public string filter { get; set; }
        public string OrderBy { get; set; }
        public string SortDirection { get; set; }


        private int _pageSize = 0;
        private int _Page = 0;
        public int Page {
            get { return _Page; }
            set { _Page = value; } 
        }
        public int PageSize {
            get
            {
                return (_pageSize < 1 ? 3 : _pageSize);
            }
            set
           {
                _pageSize = value;
           }
        }
        public int Offset
        {
            get
            {
                return (Page ==0 ? 0 : ((Page) * PageSize));
            }
        }

        public int Next
        {
            get
            {
                return PageSize + Offset;
            }
        }

        public bool EnablePaging { get; set; } = false;
        public QueryParameters()
        {

        }
    }
}
