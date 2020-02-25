using System;

namespace nunit_selenious_example
{
    public abstract class WebPage
    {
        public String Url;
        public String Title;
        
        public T Open<T>() where T : WebPage, new()
        {
            var page = new T();
            Selenious.Selenious.Open(page.Url);
            return page;
        }
    }
}