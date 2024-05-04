using atFrameWork2.SeleniumFramework;
using ATframework3demo.PageObjects.TreePage;
using OpenQA.Selenium.DevTools.V120.Emulation;
using System.Runtime.CompilerServices;

namespace ATframework3demo.TestEntities
{
    public class NodeItem
    {
        public string Name;
        public string Surname;
        public string[] BirthDate;
        public string[] DeathDate;
        public string Gender;
        public bool ImportantField;
        public string Weight;
        public string Height;
        public string EducationLvl;
        public string XPath;
        public WebItem ObjectNode;
        public string ID;

        public NodeItem(string name, string surname, string dateborn, string datedeath, string gender, string weight, string height
            , string edlvl, bool important)
        {
            this.Name = name;
            this.Surname = surname;
            this.BirthDate = dateborn.Split(".");
            this.DeathDate = datedeath.Split(".");
            this.Gender = gender;
            this.ImportantField = important;
            this.Weight = weight;
            this.Height = height;
            this.EducationLvl = edlvl;
            this.XPath = $"//*[local-name()=\"text\" and text()=\"{name}\"]//ancestor::*[local-name()='g']";
            this.ObjectNode = new WebItem(XPath, "объект карточки норды");
        }



        /// <summary>
        /// Открывает окно редактирования ноды
        /// </summary>
        public NodeEditPage Edit()
        {
            ObjectNode.Click();
            return new NodeEditPage();
        }
        public void SetId()
        {
            if (ObjectNode.WaitElementDisplayed())
            {
                this.ID = ObjectNode.GetAttribute("id");
            }
        }

    }




}
