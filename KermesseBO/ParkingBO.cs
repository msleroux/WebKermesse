using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KermesseBO
{// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
 //
 //    using ParkingBO;
 //
 //    var parkings = Parkings.FromJson(jsonString);


    
        using System;
        using System.Collections.Generic;

        using System.Globalization;
        using Newtonsoft.Json;
        using Newtonsoft.Json.Converters;

        public partial class Parkings
        {
            [JsonProperty("parks")]
            public Park[] Parks { get; set; }

            [JsonProperty("features")]
            public Features Features { get; set; }
        }

        public partial class Features
        {
            [JsonProperty("type")]
            public string Type { get; set; }

            [JsonProperty("features")]
            public Feature[] FeaturesFeatures { get; set; }
        }

        public partial class Feature
        {
            [JsonProperty("type")]
            public FeatureType Type { get; set; }

            [JsonProperty("crs")]
            public Crs Crs { get; set; }

            [JsonProperty("geometry")]
            public Geometry Geometry { get; set; }

            [JsonProperty("id")]
            public string Id { get; set; }
        }

        public partial class Crs
        {
            [JsonProperty("type")]
            public CrsType Type { get; set; }

            [JsonProperty("properties")]
            public Properties Properties { get; set; }
        }

        public partial class Properties
        {
            [JsonProperty("name")]
            public Name Name { get; set; }
        }

        public partial class Geometry
        {
            [JsonProperty("type")]
            public GeometryType Type { get; set; }

            [JsonProperty("coordinates")]
            public double[] Coordinates { get; set; }
        }

        public partial class Park
        {
            [JsonProperty("parkInformation")]
            public ParkInformation ParkInformation { get; set; }

            [JsonProperty("id")]
            public string Id { get; set; }
        }

        public partial class ParkInformation
        {
            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("status")]
            public Status Status { get; set; }

            [JsonProperty("max")]
            public long Max { get; set; }

            [JsonProperty("free")]
            public long Free { get; set; }
        }

        public enum Name { Epsg3857 };

        public enum CrsType { Name };

        public enum GeometryType { Point };

        public enum FeatureType { Feature };

        public enum Status { Available };

        public partial class Parkings
        {
            public static Parkings FromJson(string json) => JsonConvert.DeserializeObject<Parkings>(json, ParkingBO.Converter.Settings);
        }

        public static class Serialize
        {
            public static string ToJson(this Parkings self) => JsonConvert.SerializeObject(self, ParkingBO.Converter.Settings);
        }

        internal static class Converter
        {
            public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
            {
                MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
                DateParseHandling = DateParseHandling.None,
                Converters = {
                new NameConverter(),
                new CrsTypeConverter(),
                new GeometryTypeConverter(),
                new FeatureTypeConverter(),
                new StatusConverter(),
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
            };
        }

        internal class NameConverter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(Name) || t == typeof(Name?);

            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
            {
                if (reader.TokenType == JsonToken.Null) return null;
                var value = serializer.Deserialize<string>(reader);
                if (value == "EPSG:3857")
                {
                    return Name.Epsg3857;
                }
                throw new Exception("Cannot unmarshal type Name");
            }

            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
            {
                var value = (Name)untypedValue;
                if (value == Name.Epsg3857)
                {
                    serializer.Serialize(writer, "EPSG:3857"); return;
                }
                throw new Exception("Cannot marshal type Name");
            }
        }

        internal class CrsTypeConverter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(CrsType) || t == typeof(CrsType?);

            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
            {
                if (reader.TokenType == JsonToken.Null) return null;
                var value = serializer.Deserialize<string>(reader);
                if (value == "name")
                {
                    return CrsType.Name;
                }
                throw new Exception("Cannot unmarshal type CrsType");
            }

            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
            {
                var value = (CrsType)untypedValue;
                if (value == CrsType.Name)
                {
                    serializer.Serialize(writer, "name"); return;
                }
                throw new Exception("Cannot marshal type CrsType");
            }
        }

        internal class GeometryTypeConverter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(GeometryType) || t == typeof(GeometryType?);

            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
            {
                if (reader.TokenType == JsonToken.Null) return null;
                var value = serializer.Deserialize<string>(reader);
                if (value == "Point")
                {
                    return GeometryType.Point;
                }
                throw new Exception("Cannot unmarshal type GeometryType");
            }

            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
            {
                var value = (GeometryType)untypedValue;
                if (value == GeometryType.Point)
                {
                    serializer.Serialize(writer, "Point"); return;
                }
                throw new Exception("Cannot marshal type GeometryType");
            }
        }

        internal class FeatureTypeConverter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(FeatureType) || t == typeof(FeatureType?);

            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
            {
                if (reader.TokenType == JsonToken.Null) return null;
                var value = serializer.Deserialize<string>(reader);
                if (value == "Feature")
                {
                    return FeatureType.Feature;
                }
                throw new Exception("Cannot unmarshal type FeatureType");
            }

            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
            {
                var value = (FeatureType)untypedValue;
                if (value == FeatureType.Feature)
                {
                    serializer.Serialize(writer, "Feature"); return;
                }
                throw new Exception("Cannot marshal type FeatureType");
            }
        }

        internal class StatusConverter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(Status) || t == typeof(Status?);

            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
            {
                if (reader.TokenType == JsonToken.Null) return null;
                var value = serializer.Deserialize<string>(reader);
                if (value == "AVAILABLE")
                {
                    return Status.Available;
                }
                throw new Exception("Cannot unmarshal type Status");
            }

            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
            {
                var value = (Status)untypedValue;
                if (value == Status.Available)
                {
                    serializer.Serialize(writer, "AVAILABLE"); return;
                }
                throw new Exception("Cannot marshal type Status");
            }
        }
    }

}
