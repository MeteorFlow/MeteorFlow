using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeteorFlow.Core.Entities;

public class AppSettings
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    /// <summary>
    /// Gets or sets the ReferenceKey
    /// </summary>
    [MaxLength(255)]
    public string ReferenceKey { get; set; } = String.Empty;
    /// <summary>
    /// Gets or sets the Value
    /// </summary>
    [MaxLength(Int32.MaxValue)]
    public string Value { get; set; } = String.Empty;
    /// <summary>
    /// Gets or sets the Description
    /// </summary>
    [MaxLength(Int32.MaxValue)]
    public string Description { get; set; } = String.Empty;
    /// <summary>
    /// Gets or sets the Type
    /// </summary>
    [MaxLength(255)]
    public string Type { get; set; } = String.Empty;
}