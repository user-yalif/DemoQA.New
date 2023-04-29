using DemoQA.Core.Managers;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace DemoQA.Pages
{
    public abstract class PageElement : WebDriverManager
    {
        protected PageElement() : this(WebDriver) { }

        protected PageElement(ISearchContext searchContext) => PageFactory.InitElements(searchContext, this);
    }
}
