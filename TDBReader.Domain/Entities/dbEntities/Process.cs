using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TDBReader.Domain.Entities.dbEntities;

[Table("process")]
public partial class Process
{
    [Key]
    [Column("id")]
    public Guid Id { get; set; }

    [Column("name")]
    public string Name { get; set; } = null!;

    [Column("workflow_id")]
    public Guid WorkflowId { get; set; }

    [Column("metadata_id")]
    public Guid? MetadataId { get; set; }

    [Column("current_stage_id")]
    public Guid CurrentStageId { get; set; }

    [Column("created", TypeName = "timestamp without time zone")]
    public DateTime Created { get; set; }

    [Column("updated", TypeName = "timestamp without time zone")]
    public DateTime Updated { get; set; }

    [Column("entity_id")]
    public string? EntityId { get; set; }

    [Column("lock_transition")]
    public Guid? LockTransition { get; set; }

    [Column("human_friendly_id")]
    public string? HumanFriendlyId { get; set; }

    [Column("entity", TypeName = "jsonb")]
    public string Entity { get; set; } = null!;

    [ForeignKey("MetadataId")]
    [InverseProperty("Processes")]
    public virtual ProcessMetadatum? Metadata { get; set; }

    [InverseProperty("Process")]
    public virtual ICollection<ProcessMetadatum> ProcessMetadata { get; set; } = new List<ProcessMetadatum>();
}
