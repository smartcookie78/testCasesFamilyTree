using atFrameWork2.TestEntities;

namespace ATframework3demo.PageObjects
{
    /// <summary>
    /// �������� ����� �� ������ (����������/��������)
    /// ������������ ��� ����������� � ������ �����
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

