using EventIntelligenceAPI.Application.Interfaces;
namespace EventIntelligenceAPI.Application.Wrappers;

public class Paginate<T> : IPaginate<T>
{

    public Paginate()
    {
        Items = new List<T>();
    }

    public int Count { get; set; }
    public int Pages { get; set; }
    public IList<T> Items { get; set; }
}
