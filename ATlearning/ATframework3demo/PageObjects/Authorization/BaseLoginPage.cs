using atFrameWork2.TestEntities;

namespace ATframework3demo.PageObjects
{
    /// <summary>
    /// —траница входа на сервис (встроенна€/исходна€)
    /// используетс€ дл€ авторизации в начале кейса
    /// </summary>
    public abstract class BaseLoginPage
    {
        protected PortalInfo portalInfo;

        protected BaseLoginPage(PortalInfo portal)
        {
            portalInfo = portal;
        }
    }
}

