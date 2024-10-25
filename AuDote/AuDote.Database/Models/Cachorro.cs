using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using MongoDB.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.IdGenerators;

namespace AuDote.Database.Models
{
    [Collection("Cachorros")]
    public class Cachorro
    {
        [BsonId(IdGenerator = typeof(ObjectIdGenerator))]
        public ObjectId Id { get; set; }

        [BsonElement("nome")]
        [Required]
        public string Nome { get; set; }

        [BsonElement("raca")]
        [Required]
        public string Raca { get; set; }

        [BsonElement("idade")]
        [Required]
        public string Idade { get; set; }

        [BsonElement("tamanho")]
        [Required]
        public string Tamanho { get; set; }

        [BsonElement("peso")]
        [BsonRepresentation(BsonType.Decimal128)]
        [Required]
        public decimal Peso { get; set; }

        [BsonElement("sexo")]
        [Required]
        public string Sexo { get; set; }

        [BsonElement("castrado")]
        public bool Castrado { get; set; }

        [BsonElement("vacinado")]
        public bool Vacinado { get; set; }

        [BsonElement("descricao")]
        public string Descricao { get; set; }

        [BsonElement("dataChegada")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime DataChegada { get; set; } = DateTime.UtcNow;

        [BsonElement("statusAdocao")]
        [Required]
        public string StatusAdocao { get; set; }

        [BsonElement("foto")]
        public string Foto { get; set; }

        [BsonElement("historicoMedico")]
        public string HistoricoMedico { get; set; }
    }
}
