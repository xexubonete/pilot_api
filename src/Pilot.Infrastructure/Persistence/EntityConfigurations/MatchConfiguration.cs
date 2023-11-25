using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;
using Pilot.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Pilot.Infrastructure.Persistence.EntityConfigurations
{
    // Class responsible for configuring the "Match" entity using Entity Framework
    public class MatchConfiguration : IEntityTypeConfiguration<Match>
    {
        // Method to configure the entity properties and relationships
        public void Configure(EntityTypeBuilder<Match> builder)
        {
            // Set the table name for the "Match" entity
            builder.ToTable("MATCH");

            // Specify the primary key for the entity
            builder.HasKey(x => x.Id);
            // Set the value generation for the "Id" property (assuming it's not generated by the database)
            builder.Property(x => x.Id).ValueGeneratedNever();

            // Configure the "Competition" property as required (not nullable)
            builder.Property(x => x.Competition).IsRequired();

            // Specify the primary key for the "RefereeId" property            
            builder.HasKey(x => x.RefereeId);
            // Set the value generation for the "RefereeId" property (assuming it's not generated by the database)
            builder.Property(x => x.RefereeId).ValueGeneratedNever();

            // Configure a many-to-many (N:N) relationship between "Match" and "Team" entities
            builder.HasMany(x => x.Teams)
            .WithMany(tm => tm.Matchs);        
        }
    }
}