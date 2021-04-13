namespace CourseBasket.Application.Common.Interfaces
{
    public interface IConfigConstants
    {
        string RedisConnection { get; }
        int LongRunningProcessMilliseconds { get; }
    }
}
