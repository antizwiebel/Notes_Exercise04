using Windows.Storage;
using Newtonsoft.Json;

namespace NotesExercise03_Peneder.Services
{
    public class LocalStorageService : IStorageService
    {
        private readonly ApplicationDataContainer _appData = ApplicationData.Current.LocalSettings;

        public void Write<T>(string key, T value)
        {
            var json = JsonConvert.SerializeObject(value);
            _appData.Values[key] = json;

        }

        public T Read<T>(string key)
        {
            return Read<T>(key, default(T));
        }

        public T Read<T>(string key, T defaultValue)
        {
            if (!_appData.Values.ContainsKey(key))
            {
                return defaultValue;
            }
            var json = (string)_appData.Values[key];
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}