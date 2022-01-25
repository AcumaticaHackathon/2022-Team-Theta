using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PX.Data;

using Cloudmersive.APIClient.NET.ImageRecognition.Api;
using Cloudmersive.APIClient.NET.ImageRecognition.Model;
using Cloudmersive.APIClient.NET.VirusScan.Api;
using Cloudmersive.APIClient.NET.VirusScan.Model;

using IRConfiguration = Cloudmersive.APIClient.NET.ImageRecognition.Client.Configuration;
using VSConfiguration = Cloudmersive.APIClient.NET.VirusScan.Client.Configuration;


namespace TeamTheta
{
    public class API
    {
        //private const string APIKEY = "";

        #region Describe
        public static string Describe(string APIKEY, byte[] fileData)
        {
            // Configure API key authorization: Apikey
            IRConfiguration.Default.AddApiKey("Apikey", APIKEY);
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("Apikey", "Bearer");

            var apiInstance = new RecognizeApi();
            //var imageFile = new System.IO.Stream(); // System.IO.Stream | Image file to perform the operation on.  Common file formats such as PNG, JPEG are supported.
            var imageFile = new System.IO.MemoryStream(fileData); // System.IO.Stream | Image file to perform the operation on.  Common file formats such as PNG, JPEG are supported.

            try
            {
                // Describe an image in natural language
                ImageDescriptionResponse result = apiInstance.RecognizeDescribe(imageFile);
                //Debug.WriteLine(result);
                return (result.BestOutcome.Description.ToString());
            }
            catch (Exception e)
            {
                //Debug.Print("Exception when calling RecognizeApi.RecognizeDescribe: " + e.Message);
                PXTrace.WriteError("Exception when calling RecognizeApi.RecognizeDescribe: " + e.Message);
            }
            return null;
        }
        #endregion

        #region CheckNSFW
        public static string CheckNSFW(string APIKEY, byte[] fileData)
        {
            // Configure API key authorization: Apikey
            IRConfiguration.Default.AddApiKey("Apikey", APIKEY);
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("Apikey", "Bearer");

            var apiInstance = new NsfwApi();
            //var imageFile = new System.IO.Stream(); // System.IO.Stream | Image file to perform the operation on.  Common file formats such as PNG, JPEG are supported.
            var imageFile = new System.IO.MemoryStream(fileData); // System.IO.Stream | Image file to perform the operation on.  Common file formats such as PNG, JPEG are supported.


            try
            {
                // Not safe for work NSFW racy content classification
                NsfwResult result = apiInstance.NsfwClassify(imageFile);
                //Debug.WriteLine(result);
                return (result.ClassificationOutcome);
            }
            catch (Exception e)
            {
                //Debug.Print("Exception when calling NsfwApi.NsfwClassify: " + e.Message);
                PXTrace.WriteError("Exception when calling NsfwApi.NsfwClassify: " + e.Message);
            }
            return null;
        }
        #endregion

        #region Resize
        public static byte[] Resize(string APIKEY, byte[] fileData)
        {
            // Configure API key authorization: Apikey
            IRConfiguration.Default.AddApiKey("Apikey", APIKEY);
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("Apikey", "Bearer");

            var apiInstance = new ResizeApi();
            var width = 56;  // int? | Width of the output image - final image will be exactly this width
            var height = 56;  // int? | Height of the output image - final image will be exactly this height
            //var imageFile = new System.IO.Stream(); // System.IO.Stream | Image file to perform the operation on.  Common file formats such as PNG, JPEG are supported.
            var imageFile = new System.IO.MemoryStream(fileData); // System.IO.Stream | Image file to perform the operation on.  Common file formats such as PNG, JPEG are supported.

            try
            {
                // Resize an image
                byte[] result = apiInstance.ResizeResizeSimple(width, height, imageFile);
                //Debug.WriteLine(result);
                return result;
            }
            catch (Exception e)
            {
                //Debug.Print("Exception when calling ResizeApi.ResizeResizeSimple: " + e.Message);
                PXTrace.WriteError("Exception when calling ResizeApi.ResizeResizeSimple: " + e.Message);
            }
            return null;
        }
        #endregion

        #region VirusScan
        public static bool? VirusScan(string APIKEY, byte[] fileData)
        {
            // Configure API key authorization: Apikey
            VSConfiguration.Default.AddApiKey("Apikey", APIKEY);
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("Apikey", "Bearer");

            var apiInstance = new ScanApi();
            //var inputFile = new System.IO.Stream(); // System.IO.Stream | Input file to perform the operation on.
            var imageFile = new System.IO.MemoryStream(fileData); // System.IO.Stream | Image file to perform the operation on.  Common file formats such as PNG, JPEG are supported.

            try
            {
                // Scan a file for viruses
                VirusScanResult result = apiInstance.ScanFile(imageFile);
                //Debug.WriteLine(result);
                return result.CleanResult;
            }
            catch (Exception e)
            {
                //Debug.Print("Exception when calling ScanApi.ScanFile: " + e.Message);
                PXTrace.WriteError("Exception when calling ScanApi.ScanFile: " + e.Message);
            }
            
            return null;
        }
        #endregion

        #region NSFWPrefix
        public static string NSFWPrefix(string result)
        {
            bool NSFW = false;
            bool Racy = false;

            if (result.Substring(0, 6).ToUpper() == "UNSAFE") NSFW = true;
            if (result.Substring(0, 4).ToUpper() == "RACY") Racy = true;

            return (NSFW) ? "[NSFA]" : ((Racy) ? "[Racy]" : "");
        }
        #endregion

        #region Concat
        public static string Concat(string string1, string string2)
        {
            if (string1 == null && string2 == null) return "";
            else if(string1 == null) return string2;
            else if(string2 == null) return string1;

            return string1 + ((string1 != null) ? " " : "") + string2;
        }
        #endregion

    }
}
