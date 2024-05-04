using atFrameWork2.SeleniumFramework;
using System.Reflection.Metadata;

namespace ATframework3demo.PageObjects
{
    public class Header
    {
        public WebItem ProfileButton = new WebItem("//div[@class=\"navbar-item\"]", "Кнопка открытия профиля в хедере");
        public ProfileEditPage ProfileEdit()
        {
            ProfileButton.Click();
            return new ProfileEditPage();
        }
    }
}
