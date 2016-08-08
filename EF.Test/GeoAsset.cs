using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.Test
{
    public class GeoDbContext : DbContext
    {
        public GeoDbContext()
            : base() {

        }

        public DbSet<GeoAsset> GeoAssets { get; set; }
        public DbSet<GeoAssetRelationship> GeoAssetRelationships { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
        }
    }

    public enum GeoAssetType
    {
        Port = 1,
        PortGroup = 2
    }

    public enum GeoAssetRelationshipType
    {
        PortGroup = 1
    }

    [Table("GeoAsset",Schema ="Geo")]
    public class GeoAsset
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GeoAssetId { get; set; }
        public string GeoAssetName { get; set; }
        public GeoAssetType GeoAssetType { get; set; }

        [ForeignKey("GeoAssetIdFrom")]
        public ICollection<GeoAssetRelationship> GeoAssetRelationshipsFrom { get; set; }

        [ForeignKey("GeoAssetIdTo")]
        public ICollection<GeoAssetRelationship> GeoAssetRelationshipTo { get; set; }

    }

    [Table("GeoAssetRelationship", Schema = "Geo")]
    public class GeoAssetRelationship
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GeoAssetRelationshipId { get; set; }
        public int? GeoAssetIdFrom { get; set; }
        public int? GeoAssetIdTo { get; set; }

        public GeoAssetRelationshipType GeoAssetRelationshipType { get; set; }

        [ForeignKey("GeoAssetIdFrom")]
        public GeoAsset GeoAssetFrom { get; set; }

        [ForeignKey("GeoAssetIdTo")]
        public GeoAsset GeoAssetTo { get; set; }
    }
}
