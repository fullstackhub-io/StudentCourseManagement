namespace Course.Application.Common.Interfaces
{
    public interface IConfigConstants
    {
        string CourseConnection { get; }
        string TestFullStackConnection { get; }
        int LongRunningProcessMilliseconds { get; }
        string MSG_COURSE_COURSENAME { get; }
        string MSG_COURSE_NULLCREDITHOUR { get; }
        string MSG_COURSE_COURSEID { get; }
    }
}
