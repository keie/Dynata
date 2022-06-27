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

            entity.Property(x => x.Id);
            entity.HasKey(x => x.Id).HasName("id");
           
     
            
            entity.Property(x => x.FolderName).HasColumnName("folderName")
                .HasMaxLength(30);

            entity.Property(x => x.Url).HasColumnName("url");

            entity.Property(x => x.Size).HasColumnName("size");
            entity.Property(x => x.isSubFolder).HasColumnName("isSubFolder");
            entity.HasMany(x => x.SubFolders)
                .WithOne();
                

            entity.HasMany(x => x.Files).WithOne();
        }
    }
}
