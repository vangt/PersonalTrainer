using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonalTrainer.Models
{
    public partial class FoodItemApi
    {
        [JsonProperty("report")]
        public Report Report { get; set; }
    }

    public partial class Report
    {
        [JsonProperty("sr")]
        public string Sr { get; set; }

        [JsonProperty("foods")]
        public Food[] Foods { get; set; }

        [JsonProperty("end")]
        public long End { get; set; }

        [JsonProperty("groups")]
        public string Groups { get; set; }

        [JsonProperty("subset")]
        public string Subset { get; set; }

        [JsonProperty("start")]
        public long Start { get; set; }

        [JsonProperty("total")]
        public long Total { get; set; }
    }

    public partial class Food
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("nutrients")]
        public Nutrient[] Nutrients { get; set; }

        [JsonProperty("measure")]
        public string Measure { get; set; }

        [JsonProperty("ndbno")]
        public string Ndbno { get; set; }

        [JsonProperty("weight")]
        public long Weight { get; set; }
    }

    public partial class Nutrient
    {
        [JsonProperty("nutrient")]
        public string OtherNutrient { get; set; }

        [JsonProperty("unit")]
        public string Unit { get; set; }

        [JsonProperty("gm")]
        public string Gm { get; set; }

        [JsonProperty("nutrient_id")]
        public string NutrientId { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }

    public partial class FoodItemApi
    {
        public static FoodItemApi FromJson(string json) => JsonConvert.DeserializeObject<FoodItemApi>(json, Converters.Settings);
    }

    public static class Serializer
    {
        public static string ToJson(this FoodItemApi self) => JsonConvert.SerializeObject(self, Converters.Settings);
    }

    public class Converters
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
        };
    }
}