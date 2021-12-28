namespace User.Application.Common.Interfaces
{
    public interface IConfigConstants
    {
        string UserConnection { get; }
        string TestFullStackConnection { get; }
        int LongRunningProcessMilliseconds { get; }
        string MSG_USER_NULLUSERID { get; }
        string MSG_USER_NULLFIRSTNAME { get; }
        string MSG_USER_NULLLASTNAME { get; }
        string MSG_USER_NULLDOB { get; }
        string MSG_USER_NULLGENDER { get; }
        string MSG_USER_GENDER_LEN { get; }
        string MSG_USER_NULLEMAILADDR { get; }
        string MSG_USER_NULLPHNUM { get; }
        string MSG_USER_NULLCITY { get; }
        string MSG_USER_NULLSTATE { get; }
        string MSG_USER_NULLCOUNTRY { get; }
    }
}
