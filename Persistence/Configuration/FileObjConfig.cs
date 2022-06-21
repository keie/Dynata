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
    public class FileObjConfig
    {
        public void Configure(EntityTypeBuilder<FileObj> entity)
        {
            entity.ToTable("FileObj");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.IdFolder);
            entity.Property(x => x.FileName)
                .HasMaxLength(30);
            entity.Property(x => x.Size);
        }
    }
}
