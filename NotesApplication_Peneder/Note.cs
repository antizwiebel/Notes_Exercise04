using System;
using Windows.Devices.Geolocation;
using GalaSoft.MvvmLight;
using Newtonsoft.Json;

namespace NotesExercise03_Peneder
{
    public class Note : ObservableObject
    {
        public Note()
        {
        }

        [JsonProperty("CreatedAt")]
        public DateTime Date { get; set; }

        [JsonProperty("Content")]
        public string Text { get; set; }

        public int Id { get; set; }

        public string TenantId { get; set; } = "1510237026";

        public string Title { get; set; }

        [JsonIgnore]
        public Geopoint Location {
            get
            {
                return new Geopoint(new BasicGeoposition
                {
                    Latitude = Latitude,
                    Longitude = Longitude
                });
            }
            set
            {
                Latitude = value.Position.Latitude;
                Longitude = value.Position.Longitude;
            }
        }

        
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        [JsonConstructor]
        public Note(string text, string title, double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
            Location = new Geopoint(new BasicGeoposition
            {
                Latitude = Latitude,
                Longitude = Longitude
            });
            Date = DateTime.Now;
            Title = title;
            Text = text;    
        }

        public override string ToString()
        {
            return "[ " + Date + "]: " + Text;
        }
    }
}