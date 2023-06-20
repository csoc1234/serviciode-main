using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace APILogs.Domain.Entity
{
    public class Logs
    {
        [BsonId]//mongo lo relaciona con el id del documento
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("PartitionKey")]
        [BsonIgnoreIfNull]
        [JsonPropertyName("PartitionKey")]
        public string PartitionKey { get; set; }

        [BsonElement("TimeStamp")]
        [BsonIgnoreIfNull]
        [JsonPropertyName("TimeStamp")]
        public DateTime TimeStamp { get; set; }

        [BsonElement("NameMethod")]
        [BsonIgnoreIfNull]
        [JsonPropertyName("NameMethod")]
        public string NameMethod { get; set; }

        [BsonElement("Identification")]
        [BsonIgnoreIfNull]
        [JsonPropertyName("Identification")]
        public string? Identification { get; set; }

        [BsonElement("ElapsedTime")]
        [BsonIgnoreIfNull]
        [JsonPropertyName("ElapsedTime")]
        public int ElapsedTime { get; set; }

        [BsonElement("Session")]
        [BsonIgnoreIfNull]
        [JsonPropertyName("Session")]
        public string Session { get; set; }

        [BsonElement("Code")]
        [BsonIgnoreIfNull]
        [JsonPropertyName("Code")]
        public int Code { get; set; }

        [BsonElement("Comment")]
        [BsonIgnoreIfNull]
        [JsonPropertyName("Comment")]
        public string Comment { get; set; }

        [BsonElement("Version")]
        [BsonIgnoreIfNull]
        [JsonPropertyName("Version")]
        public string Version { get; set; }

        [BsonElement("IpAddress")]
        [BsonIgnoreIfNull]
        [JsonPropertyName("IpAddress")]
        public string IpAddress { get; set; }

        [BsonElement("Api")]
        [BsonIgnoreIfNull]
        [JsonPropertyName("Api")]
        public string Api { get; set; }

        [BsonElement("Proccess")]
        [BsonIgnoreIfNull]
        [JsonPropertyName("Proccess")]
        public string Proccess { get; set; }

        [BsonElement("Level")]
        [BsonIgnoreIfNull]
        [JsonPropertyName("Level")]
        public string Level { get; set; }

        [BsonElement("DocumentId ")]
        [BsonIgnoreIfNull]
        [JsonPropertyName("DocumentId")]
        public string DocumentId { get; set; }
    }
}
