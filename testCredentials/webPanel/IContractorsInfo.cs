
namespace SiteDocsAutomationProject.testCredentials.webPanel
{
    public interface IContractorsInfo
    {
        const string INBOX_TAB = "Inbox";
        const string SAFETY_MONITOR_SUBMENU = "Safety Monitor";
        const string REPORTS_TAB = "Reports";
        const string ANALYTICS_TAB = "Analytics";
        const string LOCATIONS_TAB = "Locations";
        const string WORKERS_TAB = "Workers";
        const string COMPANIES_TAB = "Companies";
        const string ALL_COMPANIES_SUBMENU = "All Companies";
        const string CHAT_TAB = "Chat";
        const string WEB_APP_TAB = "Web App";
        const string SETUP_TAB = "Setup";
        const string COMPANY_TYPE_SUBMENU = "Company Types";
        public static readonly string COMPANY_TYPE_NAME = "CompanyTypeName" + new Random().Next();
        public static readonly string COMPANY_NAME = "CompanyName" + new Random().Next();

    }
}
