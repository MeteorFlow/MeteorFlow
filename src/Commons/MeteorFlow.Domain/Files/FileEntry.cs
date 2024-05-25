using MeteorFlow.Fx.Entities;
using MeteorFlow.Fx.Infrastructure.Storages;

namespace MeteorFlow.Domain.Files;

public class FileEntry : Base<Guid>, IFileEntry
{
    public string Name { get; set; }

    public string Description { get; set; }

    public long Size { get; set; }

    public DateTimeOffset UploadedTime { get; set; }

    public string FileName { get; set; }

    public string FileLocation { get; set; }

    public bool Encrypted { get; set; }

    public string EncryptionKey { get; set; }

    public string EncryptionIv { get; set; }
}