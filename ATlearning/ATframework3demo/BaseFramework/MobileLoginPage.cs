using atFrameWork2.TestEntities;

namespace atFrameWork2.BaseFramework
{
    internal class MobileLoginPage
    {
        private PortalInfo testPortal;

        public MobileLoginPage(PortalInfo testPortal)
        {
            this.testPortal = testPortal;
        }

        internal MobileHomePage Login(User portalAdmin)
        {
            throw new NotImplementedException();
        }
    }
}