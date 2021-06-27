namespace StudentCourse.Application.Common.Interfaces
{
    public interface IConfigConstants
    {
        string StudentCourseConnection { get; }
        string TestFullStackConnection { get; }
        int LongRunningProcessMilliseconds { get; }
        string MSG_COURSE_COURSENAME { get; }
        string MSG_COURSE_NULLCREDITHOUR { get; }
        string MSG_COURSE_COURSEID { get; }

        string MSG_SC_NULLStdCourseID { get; }
    }
}
