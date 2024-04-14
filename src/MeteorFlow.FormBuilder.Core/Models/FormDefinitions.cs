using MeteorFlow.Domain.App;

namespace MeteorFlow.FormBuilder.Core.Models;

public class FormDefinitions: AppDefinitions
{
    public ICollection<FormBlocks> FormBlocks { get; set; }
}