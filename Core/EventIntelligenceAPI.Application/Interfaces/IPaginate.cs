namespace EventIntelligenceAPI.Application.Interfaces;

public interface IPaginate<T>
{
    int Count { get; }
    int Pages { get; }
    IList<T> Items { get; }
}