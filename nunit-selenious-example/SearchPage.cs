using System;
using OpenQA.Selenium;
using Selenious;
using static Selenious.Condition;
using static Selenious.Selenious;

namespace nunit_selenious_example
{
    public class SearchPage: WebPage
    {

        public ISeleniousElement SearchField = Element(By.Name("q"));
        public ISeleniousElement TestField = Element(By.Name("something"));

        public SearchPage()
        {
            Url = "/";
            Title = "test";
        }


        public SearchPage Open() => Open<SearchPage>();

        public SearchPage Search(string text)
        {
            SearchField.ShouldBe(Visible).SetValue(text).PressEnter();
            return this;
        }


    }
}