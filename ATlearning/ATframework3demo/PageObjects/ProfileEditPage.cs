using atFrameWork2.BaseFramework.LogTools;
using atFrameWork2.SeleniumFramework;

namespace ATframework3demo.PageObjects
{
    public class ProfileEditPage
    {
        public Header header => new Header();
        public LeftMenu leftmenu => new LeftMenu();

        WebItem NameEditField = new WebItem("//input[@name = \"NAME\"]", "Поле для ввода нового имени");
        WebItem SurnameEditField = new WebItem("//input[@name = \"LAST_NAME\"]", "Поле для ввода новой Фамилии");
        WebItem EMailEditField = new WebItem("//input[@name = \"EMAIL\"]", "Поле для ввода новой электронной почты");
        WebItem PasswordEditField = new WebItem("//input[@name = \"NEW_PASSWORD\"]", "Поле для ввода нового пароля");
        WebItem PasswordEditConfirmField = new WebItem("//input[@name = \"NEW_PASSWORD_CONFIRM\"]", "Поле для подтверждения нового пароля");
        WebItem SaveButton = new WebItem("//input[@name = \"save\"]", "Кнопка сохранения изменений");
        WebItem ResetButton = new WebItem("//input[@type= \"reset\"]", "Кнопка сброса изменений");
        WebItem ErrorText = new WebItem("//font[@class=\"errortext\"]", "Область с выводом ошибок");


        /// <summary>
        /// Ввод в поле имени
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public ProfileEditPage EnterNewName(string name)
        {
            NameEditField.Hover();
            NameEditField.Click();
            NameEditField.ClearValue();
            NameEditField.SendKeys(name);
            return this; 
        }

        /// <summary>
        /// Ввод в поле фамилии
        /// </summary>
        /// <param name="surname"></param>
        /// <returns></returns>
        public ProfileEditPage EnterNewSurname(string surname)
        {
            SurnameEditField.Hover();
            SurnameEditField.Click();
            SurnameEditField.ClearValue();
            SurnameEditField.SendKeys(surname);
            return this;
        }
        /// <summary>
        /// Ввод в поле электронной почты
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public ProfileEditPage EnterNewEmail(string email)
        {
            EMailEditField.Hover();
            EMailEditField.Click();
            EMailEditField.ClearValue();
            EMailEditField.SendKeys(email);
            return this;
        }
        /// <summary>
        /// Ввод нового пароля
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public ProfileEditPage EnterNewPassword (string password)
        {
            PasswordEditField.Hover();
            PasswordEditField.Click();
            PasswordEditField.ClearValue();
            PasswordEditField.SendKeys(password);
            return this;
        }
        /// <summary>
        /// Ввод Подтверждения нового пароля
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public ProfileEditPage EnterNewPasswordConfirm (string password)
        {
            PasswordEditConfirmField.Hover();
            PasswordEditConfirmField.Click();
            PasswordEditConfirmField.ClearValue();
            PasswordEditConfirmField.SendKeys(password);
            return this;
        }

        /// <summary>
        /// Клик в кнопку сохранить
        /// </summary>
        /// <returns></returns>
        public ProfileEditPage SaveChanges()
        {
            SaveButton.Hover();
            SaveButton.Click();
            return this;
        }
        /// <summary>
        /// Клик в кнопку Сбросить
        /// </summary>
        /// <returns></returns>
        public ProfileEditPage Reset()
        {
            ResetButton.Hover();
            ResetButton.Click();
            return this;
        }
        /// <summary>
        /// Возвращает текст ошибки выводящейся на экране
        /// </summary>
        /// <returns></returns>
        public String GetErrorText()
        {
            if (ErrorText.WaitElementDisplayed(2))
            {
                string errortext = ErrorText.InnerText();
                return errortext;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// Проверка изменения профиля
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool AssertChangeProfile(User user)
        {
            
            //Проверка изменения профиля состоит из нескольких шагов
            //проврека отсутствия ошибки
            if (GetErrorText() != null) { Log.Error(GetErrorText()); return false; };
            //обновить страницу, новый e-mail, имя и фамилия должны отобразиться в карточке
            WebDriverActions.Refresh();
            if (NameEditField.GetAttribute("value") != user.Name) { Log.Error("Имя не соответствует введенному"); return false; };
            if (SurnameEditField.GetAttribute("value") != user.Surname) { Log.Error("Фамилия не соответствует введенному"); return false; };
            if (EMailEditField.GetAttribute("value") != user.eMail) { Log.Error("Электронная почта не соответствует введенному"); return false; };
            if (header.ProfileButton.InnerText() != user.Name+' '+user.Surname) { Log.Error("Имя и Фамилия в хедере не соответствует введенному"); return false; };
            //Новая электронная почта и пароль должны обеспечивать успешную авторизацию на ресурсе
            if (
                leftmenu
                    .LogOut()
                    .Login(user)
                    .mainPage
                    .IsMainPage()
                )
            { return true; }
            else
            {
                Log.Error("Authorisation with new data is fail");
                return false;
            }    
        }
    }

    
}