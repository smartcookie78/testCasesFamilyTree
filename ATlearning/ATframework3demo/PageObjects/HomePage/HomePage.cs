using ATframework3demo.PageObjects;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace atFrameWork2.PageObjects
{
    /// <summary>
    /// абстрактная страница исходной страницы.
    /// От сюда переключаемся сразу на заглавную страницу
    /// </summary>
    public class ServiceHomePage
    {
        public LeftMenu leftmenu => new LeftMenu();
        public Header header => new Header();
        public MainPage mainPage => new MainPage();
        /*
        public PortalLeftMenu LeftMenu => new PortalLeftMenu();
        public NewsPage NewsPage => new NewsPage();

        public MyDrive MyDrive => new MyDrive();
        */

    }



}
