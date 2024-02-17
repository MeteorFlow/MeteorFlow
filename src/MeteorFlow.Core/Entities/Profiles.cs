using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MeteorFlow.Domain;

namespace MeteorFlow.Core.Entities;

public class Profiles
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    [MaxLength(255)]
    public string FullName { get; set; } = string.Empty;
    
    public Gender Gender { get; set; }
    public DateTimeOffset DateOfBirth { get; set; }
    
    [MaxLength(Int32.MaxValue)]
    public string AvatarUrl { get; set; } = string.Empty;
    
    [MaxLength(Int32.MaxValue)]
    public string AddressJson { get; set; } = string.Empty;

    public virtual Account? Account { get; set; }
    
}