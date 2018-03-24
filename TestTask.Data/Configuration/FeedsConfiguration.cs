﻿using System.Data.Entity.ModelConfiguration;

namespace TestTask.Data
{
    internal class FeedsConfiguration : EntityTypeConfiguration<FeedWrapped>
    {
        public FeedsConfiguration()
        {
            Map(it => it.ToTable("Feeds"));
            HasKey(it => it.Id);

            Property(it => it.Name).IsRequired().HasMaxLength(30);
            Property(it => it.LastUpdatedTime).IsRequired().HasColumnType("datetime2");
            Property(it => it.Language).IsOptional().HasMaxLength(16);
            Property(it => it.Title).IsOptional().HasMaxLength(50);
        }
    }
}