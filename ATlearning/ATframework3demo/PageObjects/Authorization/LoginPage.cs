using atFrameWork2.BaseFramework.LogTools;
using atFrameWork2.SeleniumFramework;
using atFrameWork2.TestEntities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using ATframework3demo.PageObjects;


namespace atFrameWork2.PageObjects
{

    public class LoginPage : BaseLoginPage
    {

        public LoginPage(PortalInfo portal = null):base(portal)
        {
        }
        /// <summary>
        /// Вход на ресурс
        /// </summary>
        /// <param name="admin"></param>
        /// <returns></returns>
        public ServiceHomePage OpenService(User admin)
        { 
            WebDriverActions.OpenUri(portalInfo.PortalUri);
            var ServiceHome = Login(admin);
            return ServiceHome;
        }
       
        public ServiceHomePage Login(User admin)
        {
            var emailField = new WebItem("//input[@name = 'USER_LOGIN']", "Поле для ввода логина");
            var pwdField = new WebItem("//input[@name = 'USER_PASSWORD']", "Поле для ввода пароля");
            emailField.ClearValue();
            emailField.SendKeys(admin.eMail);
            emailField.SendKeys(Keys.Tab);
            pwdField.ClearValue();
            pwdField.SendKeys(admin.Password, logInputtedText: false);
            pwdField.SendKeys(Keys.Enter);
            return new ServiceHomePage();
        }
        /// <summary>
        /// Открытие формы  
        /// </summary>
        /// <returns></returns>
        public RegistrationPage OpenRegistrationForm()
        {
            new WebItem("//a[text()=\"Зарегистрироваться\"]", "Открытие формы регистрации").Click();
            return new RegistrationPage();
        }


    }
}
