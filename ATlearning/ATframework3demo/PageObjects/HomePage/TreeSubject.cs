using ATframework3demo.PageObjects;
using ATframework3demo.PageObjects.TreePage;

namespace ATframework3demo.PageObjects.HomePage
{
    public class TreeSubject
    {
        public TreeEditPage Open()
        { 
            return new TreeEditPage(); 
        }

    }
}