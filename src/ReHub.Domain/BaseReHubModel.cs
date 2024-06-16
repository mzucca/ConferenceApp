namespace ReHub.Domain;

/// <summary>
/// Base Class for all db models
/// </summary>
public class BaseReHubModel
{
    //[Key]
    //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    //[Column("created_at")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    //[Column("updated_at")]
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

}
