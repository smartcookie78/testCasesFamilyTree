using atFrameWork2.BaseFramework;
using atFrameWork2.PageObjects;
using ATframework3demo.TestEntities;

namespace ATframework3demo.TestCases.MainPage
{
    public class Case_ID_7_RemovalTree : CaseCollectionBuilder
    {
        protected override List<TestCase> GetCases()
        {
            var caseCollection = new List<TestCase>();
            caseCollection.Add(new TestCase("ID_7_Удаление дерева", (ServiceHomePage HomePage) => RemovalTree(HomePage)));
            return caseCollection;
        }

        private void RemovalTree(ServiceHomePage HomePage)
        {
            TreeItem NewTree = new TreeItem("New Tree");

           HomePage
                .mainPage
                // Кнопка действий с деревом (три точки справа сверху)
                .TreeActionBtn()

                // Кнопка удаления дерева
                .TreeRemovalBtn()

                // Обработка алерта
                .AlertAction()

                // Проверка наличия дерева
                .TreeIsExist(NewTree);
        }
    }

}
