using FileMigrator.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileMigrator.Integration
{
    class FileProcessor
    {
        public static string ProcessDocument(RestService rs, string fileLocation, string fileName, decimal fileSizeMb, string fileStatus, string folder, string uploadedBy)
        {
            string result = "";

            string entityAsString = JsonConvert.SerializeObject(new
            {
                FileLocation = new { value = fileLocation.Replace(@"\\", @"\") },
                FileName = new { value = fileName },
                FileSizeMb = new { value = fileSizeMb },
                FileStatus = new { value = fileStatus },
                Folder = new { value = folder.Replace(@"\\", @"\") },
                UploadedBy = new { value = uploadedBy }              
            });

            //Create a sales order with the specified values
            string serviceResponse = rs.Put("DataFile", entityAsString, null);

            if (serviceResponse != null)
            {
                try
                {
                    JObject purchaseOrderCreated = JObject.Parse(serviceResponse);
                    result = purchaseOrderCreated.GetValue("FileID").Value<string>("value");
                    string poNumber = result;
                }
                catch (Exception e)
                {
                    result = e.Message;
                }
            }
            return result;
        }

        //ADDING DOCUMENTS TO AR INVOICE
        public static string AddFilesToTransaction(RestService rs, string docNbr, string filePath, string fileName, string entity)
        {
            string result = "#UPLOADING DOCS";

            try
            {
                byte[] filedata;
                using (FileStream file = File.Open(filePath, FileMode.Open))
                {
                    filedata = new byte[file.Length];
                    file.Read(filedata, 0, filedata.Length);

                    //Add the file
                    Stream fileToAttach = new MemoryStream(filedata);
                    result = rs.PutFile(entity, docNbr, fileName, fileToAttach);
                }

            }
            catch (Exception msg)
            {
                result = msg.Message;
            }
            return result;
        }

    }
}
