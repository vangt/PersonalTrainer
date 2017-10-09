using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonalTrainer.Models
{
    
    public partial class FoodAPI
    {
        [JsonProperty("list")]
        public List List { get; set; }
    }

    public partial class List
    {
        [JsonProperty("item")]
        public Item[] Item { get; set; }

        [JsonProperty("end")]
        public long End { get; set; }

        [JsonProperty("ds")]
        public string Ds { get; set; }

        [JsonProperty("group")]
        public string Group { get; set; }

        [JsonProperty("sort")]
        public string Sort { get; set; }

        [JsonProperty("start")]
        public long Start { get; set; }

        [JsonProperty("q")]
        public string Q { get; set; }

        [JsonProperty("sr")]
        public string Sr { get; set; }

        [JsonProperty("total")]
        public long Total { get; set; }
    }

    public partial class Item
    {
        [JsonProperty("group")]
        public string Group { get; set; }

        [JsonProperty("ndbno")]
        public string Ndbno { get; set; }

        [JsonProperty("ds")]
        public string Ds { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("offset")]
        public long Offset { get; set; }
    }

    public partial class FoodAPI
    {
        public static FoodAPI FromJson(string json) => JsonConvert.DeserializeObject<FoodAPI>(json, Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this FoodAPI self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }

    public class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
        };
    }
}