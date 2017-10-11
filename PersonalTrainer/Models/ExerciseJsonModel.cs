using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonalTrainer.Models
{

        public partial class ExerciseJsonModel
        {
            [JsonProperty("equipment")]
            public long[] Equipment { get; set; }

            [JsonProperty("license_author")]
            public string LicenseAuthor { get; set; }

            [JsonProperty("creation_date")]
            public object CreationDate { get; set; }

            [JsonProperty("category")]
            public long Category { get; set; }

            [JsonProperty("description")]
            public string Description { get; set; }

            [JsonProperty("language")]
            public long Language { get; set; }

            [JsonProperty("id")]
            public long Id { get; set; }

            [JsonProperty("license")]
            public long License { get; set; }

            [JsonProperty("muscles_secondary")]
            public long[] MusclesSecondary { get; set; }

            [JsonProperty("name_original")]
            public string NameOriginal { get; set; }

            [JsonProperty("muscles")]
            public long[] Muscles { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("status")]
            public string Status { get; set; }

            [JsonProperty("uuid")]
            public string Uuid { get; set; }
        }

        public partial class ExerciseJsonModel
    {
            public static ExerciseJsonModel FromJson(string json) => JsonConvert.DeserializeObject<ExerciseJsonModel>(json, Converter.Settings);
        }

        public static class Serialized
        {
            public static string ToJson(this ExerciseJsonModel self) => JsonConvert.SerializeObject(self, Converter.Settings);
        }

        public class Convertered
        {
            public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
            {
                MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
                DateParseHandling = DateParseHandling.None,
            };
        }
    }
