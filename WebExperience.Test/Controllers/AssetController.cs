
using GeneralKnowledge.Test.App.Tests;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WebExperience.Test.Models;

namespace WebExperience.Test.Controllers
{
    public class AssetController : ApiController
    {
        // TODO
        // Create an API controller via REST to perform all CRUD operations on the asset objects created as part of the CSV processing test
        // Visualize the assets in a paged overview showing the title and created on field
        // Clicking an asset should navigate the user to a detail page showing all properties
        // Any data repository is permitted
        // Use a client MVVM framework

        public AssetController()
        {

        }

        [HttpGet]
        [Route("api/Asset/Assets")]
        public IHttpActionResult GetAllAssets()
        {
            IList<AssetImportDataModel> assets = null;

            using (var ctx = new ApplicationDbContext())
            {
                assets = ctx.AssetImportDataModels
                            .Select(s => new AssetImportDataModel()
                            {
                                AssetId = s.AssetId,
                                File_Name = s.File_Name,
                                Mime_Type = s.Mime_Type,
                                Created_By = s.Created_By,
                                Email = s.Email,
                                Country = s.Country,
                                Description = s.Description
                            }).ToList<AssetImportDataModel>();
            }

            if (assets.Count == 0)
            {
                return NotFound();
            }

            return Ok(assets);
        }

        //[HttpGet]
        //public IHttpActionResult GetAssetById(string assetId)
        //{
        //    AssetImportDataModel asset = new AssetImportDataModel();

        //    using (var ctx = new ApplicationDbContext())
        //    {
        //        asset = ctx.AssetImportDataModels
        //            .Where(s => s.AssetId.Equals(assetId))
        //            .Select(s => new AssetImportDataModel()
        //            {
        //                AssetId = s.AssetId,
        //                File_Name = s.File_Name,
        //                Mime_Type = s.Mime_Type,
        //                Created_By = s.Created_By,
        //                Email = s.Email,
        //                Country = s.Country,
        //                Description = s.Description
        //            }).FirstOrDefault<AssetImportDataModel>();
        //    }

        //    if (asset == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(asset);
        //}

        //[HttpPost]
        public IHttpActionResult PostNewAsset([FromBody] AssetImportDataModel asset)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            using (var ctx = new ApplicationDbContext())
            {
                ctx.AssetImportDataModels.Add(new AssetImportDataModel()
                {
                    AssetId = asset.AssetId,
                    File_Name = asset.File_Name,
                    Mime_Type = asset.Mime_Type,
                    Created_By = asset.Created_By,
                    Email = asset.Email,
                    Country = asset.Country,
                    Description = asset.Description
                });

                ctx.SaveChanges();
            }

            return Ok();
        }

        //[HttpPut]
        public IHttpActionResult PutAsset(string assetId, [FromBody] AssetImportDataModel asset)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            using (var ctx = new ApplicationDbContext())
            {
                var existingAsset = ctx.AssetImportDataModels.Where(s => s.AssetId == assetId)
                                                        .FirstOrDefault<AssetImportDataModel>();

                if (existingAsset != null)
                {
                    //existingAsset.File_Name = asset.File_Name;
                    //existingAsset.Created_By = asset.Created_By;
                    //existingAsset.Country = asset.Country;
                    //existingAsset.Mime_Type = asset.Mime_Type;
                    existingAsset.Description = asset.Description;
                    existingAsset.Email = asset.Email;

                    ctx.SaveChanges();
                }
                else
                {
                    return NotFound();
                }
            }

            return Ok();
        }

        //[HttpDelete]
        public IHttpActionResult DeleteAsset(string assetId)
        {
            if (string.IsNullOrWhiteSpace(assetId))
                return BadRequest("Not a valid Asset id");

            using (var ctx = new ApplicationDbContext())
            {
                var asset = ctx.AssetImportDataModels
                    .Where(s => s.AssetId == assetId)
                    .FirstOrDefault();

                ctx.Entry(asset).State = System.Data.Entity.EntityState.Deleted;
                ctx.SaveChanges();
            }

            return Ok();
        }
    }
}

