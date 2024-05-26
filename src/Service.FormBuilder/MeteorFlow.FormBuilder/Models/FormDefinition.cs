using MeteorFlow.Domain.App;

namespace MeteorFlow.FormBuilder.Models;

public class FormDefinition: AppDefinitions
{
    public ICollection<FormBlock> FormBlocks { get; set; }
}