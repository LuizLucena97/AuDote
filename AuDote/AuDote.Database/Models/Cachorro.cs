using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.EntityFrameworkCore;
using System.ComponentModel;

namespace AuDote.Database.Models
{
    [Collection("Cachorros")]
    public class Cachorro
    {
        [BsonId(IdGenerator = typeof(ObjectIdGenerator))]
        public ObjectId Id { get; set; }

        [BsonElement("nome")]
        [DefaultValue("Bob")]
        [Required(ErrorMessage = "O nome é obrigatório.")]
        [StringLength(50, ErrorMessage = "O nome não pode ter mais de 50 caracteres.")]
        public string Nome { get; set; }

        [BsonElement("raca")]
        [DefaultValue("BullDog")]
        [Required(ErrorMessage = "A raça é obrigatória.")]
        [StringLength(50, ErrorMessage = "A raça não pode ter mais de 50 caracteres.")]
        public string Raca { get; set; }

        [BsonElement("idade")]
        [DefaultValue("5")]
        [Required(ErrorMessage = "A idade é obrigatória.")]
        [Range(0, 50, ErrorMessage = "A idade deve estar entre 0 e 50 anos.")]
        public string Idade { get; set; }

        [BsonElement("tamanho")]
        [DefaultValue("50cm")]
        [Required(ErrorMessage = "O tamanho é obrigatório.")]
        [StringLength(20, ErrorMessage = "O tamanho não pode ter mais de 20 caracteres.")]
        public string Tamanho { get; set; }

        [BsonElement("peso")]
        [DefaultValue(20)]
        [BsonRepresentation(BsonType.Decimal128)]
        [Required(ErrorMessage = "O peso é obrigatório.")]
        [Range(0.1, 200, ErrorMessage = "O peso deve estar entre 0.1 e 200 kg.")]
        public decimal Peso { get; set; }

        [BsonElement("sexo")]
        [DefaultValue("M")]
        [Required(ErrorMessage = "O sexo é obrigatório.")]
        [StringLength(1, ErrorMessage = "O sexo deve ser representado por uma única letra (M/F).")]
        public string Sexo { get; set; } 

        [BsonElement("castrado")]
        public bool Castrado { get; set; }

        [BsonElement("vacinado")]
        public bool Vacinado { get; set; }

        [BsonElement("descricao")]
        [DefaultValue("Legal")]
        [StringLength(200, ErrorMessage = "A descrição não pode ter mais de 200 caracteres.")]
        public string Descricao { get; set; }

        [BsonElement("dataChegada")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime DataChegada { get; set; } = DateTime.UtcNow;

        [BsonElement("statusAdocao")]
        [DefaultValue("Disponivel")]
        [Required(ErrorMessage = "O status de adoção é obrigatório.")]
        public string StatusAdocao { get; set; }

        [BsonElement("foto")]
        public string Foto { get; set; }

        [BsonElement("historicoMedico")]
        public string HistoricoMedico { get; set; }
    }
}
