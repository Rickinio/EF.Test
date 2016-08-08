using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.Test
{
    class Program
    {
        static void Main(string[] args) {
            var context = new GeoDbContext();

            //var geoAssetFirst = new GeoAsset() {
            //    GeoAssetName = "Geo1",
            //    GeoAssetType = GeoAssetType.Port
            //};

            //var geoAssetSecond = new GeoAsset() {
            //    GeoAssetName = "PortGroupTest",
            //    GeoAssetType = GeoAssetType.PortGroup
            //};

            //var geoAssetThird = new GeoAsset() {
            //    GeoAssetName = "Geo2",
            //    GeoAssetType = GeoAssetType.Port
            //};

            //var geoAssetFirst = context.GeoAssets.Where(x => x.GeoAssetName == "Geo1").FirstOrDefault();
            //var geoPortGroup = context.GeoAssets.Where(x => x.GeoAssetType == GeoAssetType.PortGroup).FirstOrDefault();

            //context.GeoAssets.Add(geoAssetThird);

            //var geoRelationship = new GeoAssetRelationship() {
            //    GeoAssetFrom = geoAssetThird,
            //    GeoAssetTo = geoPortGroup,
            //    GeoAssetRelationshipType = GeoAssetRelationshipType.PortGroup
            //};

            //context.GeoAssetRelationships.Add(geoRelationship);

            //context.SaveChanges();

            //select all ports of the Parent Port
            var geoGroup = context.GeoAssetRelationships.Where(x => x.GeoAssetIdTo == 2).Select(x => x.GeoAssetFrom).ToList();

            var geoFromGroup = context.GeoAssets.Where(x => x.GeoAssetId == 2)
                                                .Include(x=>x.GeoAssetRelationshipsFrom)
                                                .Include(x=>x.GeoAssetRelationshipTo)
                                                .FirstOrDefault();
        }
    }
}
