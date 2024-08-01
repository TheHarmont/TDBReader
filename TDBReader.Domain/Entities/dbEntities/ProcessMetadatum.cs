using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TDBReader.Domain.Entities.dbEntities;

[Table("process_metadata")]
public partial class ProcessMetadatum
{
    [Key]
    [Column("id")]
    public Guid Id { get; set; }

    [Column("process_id")]
    public Guid ProcessId { get; set; }

    [Column("metadata", TypeName = "jsonb")]
    public string? Metadata { get; set; }

    [Column("scoped_metadata", TypeName = "jsonb")]
    public string? ScopedMetadata { get; set; }

    [ForeignKey("ProcessId")]
    [InverseProperty("ProcessMetadata")]
    public virtual Process Process { get; set; } = null!;

    [InverseProperty("Metadata")]
    public virtual ICollection<Process> Processes { get; set; } = new List<Process>();
}
