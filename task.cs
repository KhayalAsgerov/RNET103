using System;
using System.Reflection;
using System.Text.Json;

public static class JsonExtensions
{
    public static T DeserializeJson<T>(this string json) where T : new()
    {
        T obj = new T();

        if (!string.IsNullOrWhiteSpace(json))
        {
            try
            {
                var jsonObject = JsonSerializer.Deserialize<JsonElement>(json);
                MapJsonToObj(jsonObject, obj);
            }
            catch (JsonException ex)
            {
                Console.WriteLine("JSON deserialization error: " + ex.Message);
            }
        }

        return obj;
    }

    public static string SerializeToJson(this object obj)
    {
        Type objectType = obj.GetType();
        var properties = objectType.GetProperties();

        var jsonProps = new JsonObject();
        foreach (var property in properties)
        {
            var value = property.GetValue(obj);
            jsonProps.Add(property.Name.ToLower(), value);
        }

        return JsonSerializer.Serialize(jsonProps);
    }

    private static void MapJsonToObj(JsonElement json, object obj)
    {
        Type objectType = obj.GetType();
        var properties = objectType.GetProperties();

        foreach (var property in properties)
        {
            var jsonPropertyName = property.Name.ToLower();
            if (json.TryGetProperty(jsonPropertyName, out JsonElement value))
            {
                object convertedValue = value.ValueKind switch
                {
                    JsonValueKind.Number => value.GetDouble(),
                    JsonValueKind.String => value.GetString(),
                    JsonValueKind.True => true,
                    JsonValueKind.False => false,
                    _ => null
                };

                property.SetValue(obj, Convert.ChangeType(convertedValue, property.PropertyType));
            }
        }
    }
}