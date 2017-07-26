using Windows.Data.Json;

namespace NeuOldDriver.Extensions {

    public static class JsonExtensions {

        public static IJsonValue GetValue(this JsonObject obj, string name) {
            IJsonValue val;
            if (obj.TryGetValue(name, out val))
                return val;
            return null;
        }

        public static string GetString(this JsonObject obj, string name) {
            return obj.GetValue(name)?.GetString();
        }

        public static JsonObject GetObject(this JsonObject obj, string name) {
            return obj.GetValue(name)?.GetObject();
        }

        public static JsonObject SetObject(this JsonObject obj, string name, JsonObject value) {
            obj.SetNamedValue(name, value);
            return obj;
        }

        public static JsonObject SetString(this JsonObject obj, string propname, string value) {
            obj.SetNamedValue(propname, JsonValue.CreateStringValue(value));
            return obj;
        }
    };
}
