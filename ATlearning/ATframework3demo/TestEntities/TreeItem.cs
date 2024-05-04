using atFrameWork2.SeleniumFramework;
using ATframework3demo.PageObjects.TreePage;
using OpenQA.Selenium.DevTools.V121.FedCm;
using System.Xml.XPath;

namespace ATframework3demo.TestEntities
{
    /// <summary>
    /// Объект дерева на главной странице
    /// </summary>
    public class TreeItem
    {
        public TreeItem(string title)
        {
            this.Title = title;
            string Xpath = ($"//a [@class =\"card-header-title\" and contains(text(),\"{title}\")]" +
                //карточка дерева
                $" //ancestor::div[@class=\"card\"] ");
            this.Card = new WebItem(Xpath, "Карточка дерева");
            this.header = new WebItem($"{Card.XPathLocator}//header", "Хедер для клика");
            this.ButtonMenu = new WebItem($"{Card.XPathLocator}//div[@class =\"dropdown\"]", "Меню");
            this.ContexMenu = new WebItem($"{Card.XPathLocator}//div[@class=\"dropdown-content show\"]","контекстное меню выпадающее");

        }

        public WebItem header { get; set; }
        public WebItem ButtonMenu { get; set; }
        public WebItem ContexMenu { get; set; }
        public WebItem Card { get; set; }
        
        public string Title { get; set; }

        /// <summary>
        /// Открывает страницу дерева
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public TreeEditPage Open()
        {
            header.Hover();
            header.Click();
            return new TreeEditPage();
        }


    }
}