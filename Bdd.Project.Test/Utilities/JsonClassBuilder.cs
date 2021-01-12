using Newtonsoft.Json;

namespace Bdd.Project.Test.Utilities
{
    public class JsonClassBuilder<T>
    {
        public static T ConvertJson(string jsonstring)
        {
            var convertedObject = JsonConvert.DeserializeObject<T>(jsonstring);
            return convertedObject;
        }
    }
}
