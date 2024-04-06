
using System.ComponentModel.DataAnnotations.Schema;

namespace MeteorFlow.Core.Fx.Models;

public abstract class Base<T> where T : IEquatable<T>
{
  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
  public virtual T Id { get; set; }
}