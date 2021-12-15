using System.Linq;
using System.Collections.Generic;
using System.Data.SqlClient;
using System;
using System.Data;
using System.Reflection;

namespace GeneralKnowledge.Test.App.Tests
{
    /// <summary>
    /// CSV processing test
    /// </summary>
    public class CsvProcessingTest : ITest
    {
        public void Run()
        {
            // TODO
            // Create a domain model via POCO classes to store the data available in the CSV file below
            // Objects to be present in the domain model: Asset, Country and Mime type
            // Process the file in the most robust way possible
            // The use of 3rd party plugins is permitted

            var csvFile = Resources.AssetImport;
            var fileData = csvFile.Split('\n').Where(x => !string.IsNullOrWhiteSpace(x)).Distinct().ToArray();
            InsertRecords(fileData);
            Console.WriteLine("\nSuccessfully Imported Asset Data\n");
        }

        public void InsertRecords(string[] fileData)
        {
            var connString = @"Server=localhost\SQLEXPRESS;Database=TechAssesDB;Trusted_Connection=True;";
            DataTable assestImportData = new DataTable("AssetImportDatas");

            DataColumn AssetId = new DataColumn();
            AssetId.ColumnName = "AssetId";
            DataColumn File_Name = new DataColumn();
            File_Name.ColumnName = "File_Name";
            DataColumn Mime_Type = new DataColumn();
            Mime_Type.ColumnName = "Mime_Type";
            DataColumn Created_By = new DataColumn();
            Created_By.ColumnName = "Created_By";
            DataColumn Email = new DataColumn();
            Email.ColumnName = "Email";
            DataColumn Country = new DataColumn();
            Country.ColumnName = "Country";
            DataColumn Description = new DataColumn();
            Description.ColumnName = "Description";
            // Add the columns to the Assest Import DataTable
            assestImportData.Columns.Add(AssetId);
            assestImportData.Columns.Add(File_Name);
            assestImportData.Columns.Add(Mime_Type);
            assestImportData.Columns.Add(Created_By);
            assestImportData.Columns.Add(Email);
            assestImportData.Columns.Add(Country);
            assestImportData.Columns.Add(Description);

            for (int i = 1; i < fileData.Length; i++)
            {
                AssetImportData record = new AssetImportData();
                var assetData = fileData[i].Split(',').ToArray();
                DataRow assestImportRow = assestImportData.NewRow();
                assestImportRow["AssetId"] = assetData[0];
                assestImportRow["File_Name"] = assetData[1];
                assestImportRow["Mime_Type"] = assetData[2];
                assestImportRow["Created_By"] = assetData[3];
                assestImportRow["Email"] = assetData[4];
                assestImportRow["Country"] = assetData[5];
                assestImportRow["Description"] = assetData[6];
                assestImportData.Rows.Add(assestImportRow);
            }

            using (SqlConnection dbConnection = new SqlConnection(connString))
            {
                dbConnection.Open();
                using (SqlBulkCopy s = new SqlBulkCopy(dbConnection))
                {
                    s.DestinationTableName = assestImportData.TableName;

                    foreach (var column in assestImportData.Columns)
                        s.ColumnMappings.Add(column.ToString(), column.ToString());

                    s.WriteToServer(assestImportData);
                }
            }

        }

    }
}
