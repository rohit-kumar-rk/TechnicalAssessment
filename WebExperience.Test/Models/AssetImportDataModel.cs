using System.ComponentModel.DataAnnotations;

namespace GeneralKnowledge.Test.App.Tests
{
    public class AssetImportDataModel
    {
        [Key]
        public string AssetId { get; set; }
        public string File_Name { get; set; }
        public string Mime_Type { get; set; }
        public string Created_By { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public string Description { get; set; }
    }

}
