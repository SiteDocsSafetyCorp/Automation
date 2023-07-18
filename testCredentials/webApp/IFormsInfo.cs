
/**
 *  This INTERFACE contains information that is needed to complete a test case
 */
namespace SiteDocsAutomationProject.testCredentials.webApp
{
    public interface IFormsInfo
    {
        const string LOCATION_NAME = "Demo Project";
        const string FORMS_TAB = "Forms";
        const string FORM_NAME = "Standard Form";
        const string FORM_FOLLOWUP_NAME = "Follow Up Form";
        const string STATUS_NEW = "New";
        const string STATUS_IN_PROGRESS = "In Progress";
        const string STATUS_DUPLICATE = "Dubplicate";
        const string STATUS_REVISION = "Revision";
        const string STATUS_PREVIOUSLY_SIGNED = "Previously Signed";
        public static readonly string SIGN_FOLLOWUP_LABEL_1 = "SignFollowUpLabel" + new Random().Next();
        public static readonly string SIGN_FOLLOWUP_LABEL_2 = "SignedFollowUpLabel2" + new Random().Next();
        public static readonly string SAVE_FOLLOWUP_LABEL_2 = "SaveFollowUpLabel2" + new Random().Next();
        public static readonly string SAVE_FOLLOWUP_LABEL = "SaveFollowUpLabel" + new Random().Next();
        public static readonly string SIGN_FORM_LABEL = "SignFormLabel" + new Random().Next();
        public static readonly string DRAFT_FORM_LABEL = "DraftFormLabel" + new Random().Next();
        public static readonly string DRAFT_FORM_LABEL_2 = "DraftFormLabel2" + new Random().Next();
        public static readonly string DRAFT_FORM_LABEL_3 = "DraftFormLabel3" + new Random().Next();
        const string COMMENT = "This is automated comment!";
        const string PHOTO_COMMENT = "This is automated photo comment!";
        const string SHORT_ANSWER = "This is automated short answer!";
        const string LONG_ANSWER = "This is automated long answer! here are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form.";
        const string NUMBER = "123456789";


    }
}
