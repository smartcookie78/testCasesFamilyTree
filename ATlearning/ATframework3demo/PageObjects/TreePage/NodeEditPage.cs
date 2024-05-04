



using atFrameWork2.BaseFramework.LogTools;
using atFrameWork2.SeleniumFramework;
using OpenQA.Selenium;

namespace ATframework3demo.PageObjects.TreePage
{
    public class NodeEditPage
    {
        public WebItem NameField = new WebItem("//input[@data-binding = \"name\"]", "Поле ввода имени");
        public WebItem SurnameField = new WebItem("//input[@data-binding= \"surname\"]", "Поле ввода фамилии");
        public WebItem BirthDateField = new WebItem("//input[@data-binding= \"birthDate\"]", "Поле ввода даты рождения");
        public WebItem DeathDateField = new WebItem("//input[@data-binding = \"deathDate\"]", "Поле ввода даты смерти");
        public WebItem GenderField = new WebItem("//select[@data-binding = \"gender\"]", "Список с выбором гендера");
        public WebItem ImportantFlag = new WebItem("//span[@class=\"bft-checkbox-checkmark\"]", "Флажок important");
        public WebItem SaveButton = new WebItem("//button[text()=\"Save\"]", "Кнопка 'Save'");
        public WebItem WeightField = new WebItem("//input[@data-binding = \"weight\"]","Поле Вес");
        public WebItem HeightField = new WebItem("//input[@data-binding = \"height\"]", "Поле Рост");
        public WebItem EducationLevelField = new WebItem("//select[@data-binding = \"education\"]", "Поле Education level");

        /// <summary>
        /// Возвращает значение Флага
        /// </summary>
        /// <returns></returns>
        public bool AssertFlagValue()
        {

            bool FlagValue = false;
            return FlagValue;
        }

        /// <summary>
        /// Ввод в поле имени
        /// </summary>
        /// <returns></returns>
        public NodeEditPage EnterName(string name)
        {
            
            NameField.ClearValue();
            NameField.SendKeys(name);
            return this;
        }


        /// <summary>
        /// Ввод в поле фамилии
        /// </summary>
        /// <param name="surname"></param>
        /// <returns></returns>
        public NodeEditPage EnterSurname(string surname)
        {
            
            SurnameField.ClearValue();
            SurnameField.SendKeys(surname);
            return this;
        }
        /// <summary>
        /// Ввод в поле даты рождения
        /// </summary>
        /// <param name="birthDate"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public NodeEditPage EnterBirthDate(string[] birthDate)
        {
            if (birthDate[0] == "") { return this; };
            BirthDateField.ClearValue();
            BirthDateField.SendKeys(birthDate[0] + birthDate[1] + birthDate[2]);
            return this;
        }
        /// <summary>
        /// Ввод в поле даты смерти
        /// </summary>
        /// <param name="deathDate"></param>
        /// <returns></returns>
        public NodeEditPage EnterDeathDate(string[] deathDate)
        {
            if (deathDate[0] == "") { return this; };
            DeathDateField.ClearValue();
            DeathDateField.SendKeys(deathDate[0] + deathDate[1] + deathDate[2]);
            return this;
        }

        /// <summary>
        /// Ввод в поле Вес
        /// </summary>
        /// <param name="Weight"></param>
        /// <returns></returns>
        public NodeEditPage EnterWeight(string Weight)
        {
            WeightField.Hover();
            WeightField.ClearValue();
            WeightField.SendKeys(Weight);
            return this;
        }

        /// <summary>
        /// Ввод в поле Рост
        /// </summary>
        /// <param name="Height"></param>
        /// <returns></returns>
        public NodeEditPage EnterHeight(string Height)
        {
            HeightField.Hover();
            HeightField.ClearValue();
            HeightField.SendKeys(Height);
            return this;
        }
        /// <summary>
        /// Установка в поле "пол"
        /// </summary>
        /// <param name="sexField"></param>
        /// <returns></returns>
        public NodeEditPage EnterGender(string sexField)
        {
            GenderField.Hover();
            GenderField.Click();
            GenderField.SelectListItemByText(sexField);
            GenderField.Click();
            return this;
        }


        public NodeEditPage EnterEducationLevel(string  EducationLevel)
        {
            EducationLevelField.Hover();
            EducationLevelField.Click();
            EducationLevelField.SelectListItemByText(EducationLevel);
            EducationLevelField.Click();
            return this;
        }
        /// <summary>
        /// Установка флага в поле important
        /// </summary>
        /// <param name="importantField"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public NodeEditPage EnterImportantFlag(bool importantField)
        {
            if (GetFlagValue() !=  importantField)
            {
                ImportantFlag.Hover();
                ImportantFlag.Click();
            }
            
            return this;
        }

        /// <summary>
        /// Функция сохраняет изменения внесенные в карточку
        /// </summary>
        /// <returns></returns>

        public TreeEditPage Save()
        {
            SaveButton.Hover();
            SaveButton.Click();
            return new TreeEditPage();
        }

        /// <summary>
        /// Функция возвращает гендер установленный в карточке
        /// </summary>
        /// <returns></returns>

        public string GetGender()
        {
            string gendervalue = null;
            try
            {
                gendervalue = new WebItem(GenderField.XPathLocator + "//*[@selected]", "selected value").GetAttribute("value");
                
            }
            catch
            {
                Log.Error("Пол установлен не был");
            }
            return gendervalue;

        }
        /// <summary>
        /// Возвращает установленный уровень образования
        /// </summary>
        /// <returns></returns>
        public string GetEducationLevel()
        {
            string EdLvl = null;
            try
            {
                EdLvl = new WebItem(EducationLevelField.XPathLocator + "//*[@selected]", "selected value").GetAttribute("value");
            }
            catch
            {
                Log.Error("Образование установленно не было");
            }
            return EdLvl;
        }
        /// <summary>
        /// Возвращает наличие установленной галочки 'important'
        /// </summary>
        /// <returns></returns>
        public bool GetFlagValue()
        {
            string Flag = new WebItem(ImportantFlag.XPathLocator + "//ancestor::label//input", "объект содержаший значение поля").GetAttribute("data-btn-checked");
            if (Flag == "true")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}