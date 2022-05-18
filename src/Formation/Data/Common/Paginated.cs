using System.Reflection;

namespace Formation.Data.Common
{
    public interface Paginated
    {
        public int Id { get; set; }
        public Dictionary<string, object> ToDataDictionary()
        {
            var dict = new Dictionary<string, object>();

            var properties = GetType()
                .GetProperties()
                .Where(p => p.GetCustomAttribute<DataAttribute>() != null)
                .OrderBy(o => o.GetCustomAttribute<DataAttribute>()?.Position)
                .ToList();

            foreach (var item in properties)
            {
                var attribute = item.GetCustomAttribute<DataAttribute>();
                var value = item.GetValue(this);
                dict.Add(attribute.Name, value);
            }
            return dict;
        }
    }
}
