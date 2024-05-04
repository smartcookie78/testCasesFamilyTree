




using atFrameWork2.SeleniumFramework;
using OpenQA.Selenium;
using System.Xml.Linq;

namespace atFrameWork2.PageObjects
{
    public class RegistrationPage
    {
        public static string NameOfObject = "RegistrationPage";
        /// <summary>
        /// Вводит заданное значение в поле "имя"
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public RegistrationPage EnterName(string name)
        {
            WebItem field = new WebItem("//input[@name = \"USER_NAME\"]", "Поле для ввода имени");
            field.ClearValue();
            field.SendKeys(name);
            return this;
        }
        /// <summary>
        /// Вводит заданное значение в поле "Фамилия"
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public RegistrationPage EnterSurname(string surname)
        {
            WebItem field = new WebItem("//input[@name = \"USER_LAST_NAME\"]", "Поле для ввода фамилии");
            field.ClearValue();
            field.SendKeys(surname);

            return this;
        }
        /// <summary>
        /// Вводит заданное значение в поле "Логин"
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public RegistrationPage EnterLogin(string login)
        {
            WebItem field = new WebItem("//input[@name = \"USER_EMAIL\"]", "Поле для ввода логина");
            field.ClearValue();
            field.SendKeys(login);
            return this;
        }
        /// <summary>
        /// Вводит заданное значение в поле "Пароль"
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public RegistrationPage EnterPassword(string password)
        {
            WebItem field = new WebItem("//input[@name = \"USER_PASSWORD\"]", "Поле для ввода пароля");
            field.ClearValue();
            field.SendKeys(password);
            return this;
        }

        /// <summary>
        /// Нажатие на кнопку "зарегистрироваться"
        /// Если удачно, открывается главная страница
        /// Если неудачно то выкидывает в лог исключение
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public MainPage RegistrationButton()
        {
            new WebItem("//input[@name = \"Register\"]", "кнопка 'Зарегистрироваться'").Click();
            return new MainPage();
        }
    }
}