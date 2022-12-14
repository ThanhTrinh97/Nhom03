using Newtonsoft.Json;

namespace Nhom03.Extension
{
    public static class SessionExtensions
    {
        public static void Set<T>(this ISession session, String key, T value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T Get<T> (this ISession session, String key)
        {
            var value = session.GetString(key);
            return value == null ? default(T) :
                JsonConvert.DeserializeObject<T>(value);
        }
    }
}
