using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

public static class SessionExtensions
{
    public static void SetObject(this ISession session, string key, object value)
    {
        var json = JsonConvert.SerializeObject(value);
        session.SetString(key, json);
    }

    public static T GetObject<T>(this ISession session, string key)
    {
        var json = session.GetString(key);
        return json == null ? default(T) : JsonConvert.DeserializeObject<T>(json);
    }
}
