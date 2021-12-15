using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralKnowledge.Test.App.Tests
{
    public class AssetDataContext : DbContext
    {
        public AssetDataContext() : base("TechAssesDB")
        {

        }

        public DbSet<AssetImportData> AssetImportDatas { get; set; }
    }
}
