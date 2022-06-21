using Domain.DynataSystem;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configuration
{
    public class FolderConfig:IEntityTypeConfiguration<Folder>
    {
        public void Configure(EntityTypeBuilder<Folder> entity)
        {
            entity.ToTable("Folder");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.IdFolder);
            entity.Property(x => x.FolderName)
                .HasMaxLength(30);

            entity.Property(x => x.Size);
            entity.Property(x => x.isSubFolder);
            entity.HasMany(x => x.SubFolders);
            entity.HasMany(x => x.Files);
        }
    }
}
