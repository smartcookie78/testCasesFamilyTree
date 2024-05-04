

using atFrameWork2.BaseFramework.LogTools;
using atFrameWork2.SeleniumFramework;
using ATframework3demo.TestEntities;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V120.Accessibility;

namespace ATframework3demo.PageObjects.TreePage
{
    public class TreeEditPage
    {
        public NodeEditPage nodeEditPage => new NodeEditPage();



        /// <summary>
        /// Проверка данных ноды
        /// </summary>
        /// <param name="testNode"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool AssertNodeItemInfo(TestEntities.NodeItem testNode)
        {
            WebDriverActions.Refresh();
            if (testNode.ObjectNode.WaitElementDisplayed())
            {
                testNode.ObjectNode.Click();
            }
            else
            {
                Log.Error("Нода не отображается");
            }

            // проверяем что поля соответствуют нашим значениям
            bool res = true;
            if ( nodeEditPage.NameField.GetAttribute("value") != testNode.Name) { Log.Error("Значение 'Имя' не соответствует заданному"); res = false; };
            if (nodeEditPage.SurnameField.GetAttribute("value") != testNode.Surname) { Log.Error("Значение 'Фамилия' не соответствует заданному"); res = false; };
            if (testNode.BirthDate[0] == "")
            {
                if (nodeEditPage.BirthDateField.GetAttribute("value") != "") res = false;
            }
            else
            {
                    if (nodeEditPage.BirthDateField.GetAttribute("value") != (testNode.BirthDate[2] + '-' + testNode.BirthDate[1] + '-' + testNode.BirthDate[0]))
                    { Log.Error("Значение поля 'ДатаРождения' не соответствует заданному"); res = false; };
            }
            if (testNode.DeathDate[0] == "")
            {
                if (nodeEditPage.DeathDateField.GetAttribute("value") != "") res = false;
            }
            else
            {
                if (nodeEditPage.DeathDateField.GetAttribute("value") != (testNode.DeathDate[2] + '-' + testNode.DeathDate[1] + '-' + testNode.DeathDate[0]))
                { Log.Error("Значение поля 'DeathDate' не соответствует заданному"); res = false; };
            }
            if(nodeEditPage.WeightField.GetAttribute("value") != testNode.Weight) { Log.Error("Значение 'Вес' не соответствует заданному"); res = false; };
            if(nodeEditPage.HeightField.GetAttribute("value") != testNode.Height) { Log.Error("Значение 'Рост' не соответствует заданному"); res = false; };
            if (nodeEditPage.GetGender() != testNode.Gender.ToLower()) { Log.Error("Значение поля 'gender' не соответствует заданному"); res = false; };
            if (nodeEditPage.GetEducationLevel() != testNode.EducationLvl.ToLower()) { Log.Error("Значение поля 'EducationLevel' не соответствует заданному"); res = false; };
            if (nodeEditPage.GetFlagValue() != testNode.ImportantField) { Log.Error("Значение Flag не соответствует заданному"); res = false; };
            return res;
        }
        /// <summary>
        /// Клик по выбранной ноде
        /// </summary>
        /// <param name="testNode"></param>
        /// <returns></returns>
        public NodeItem ChooseNode(NodeItem testNode)
        {
            return testNode;
        }
    }
}