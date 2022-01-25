using PX.Data;
using PX.SM;
using TeamTheta;

namespace TeamTheta.TT
{
    public class UploadFileMaintenanceExtension :PXGraphExtension<UploadFileMaintenance>
    {
        #region IsActive
        public static bool IsActive()
        {
            return true;
        }
        #endregion

        // Setup View
        public PXSetup<TTSetup> Setup;

        #region Initialize
        public override void Initialize()
        {
            base.Initialize();
            TTSetup setup = Setup.Current;
        }
        #endregion

        public delegate void PersistDelegate();
        [PXOverride]
        public void Persist(PersistDelegate del)
        {
            // Get API Key
            TTSetup setup = Setup.Current;
            string APIKEY = setup.Apikey.ToString();
            
            // Make the Override Logic for Files
            foreach (object obj in Base.Files.Cache.Cached)
            {
                UploadFile file = (UploadFile)obj;
                PX.SM.FileInfo attachment = new FileInfo(file.Name, null, file.Data);
                byte[] BinaryData = attachment.BinData;

                string FileExt = file.Extansion.ToUpper();
                if (FileExt == "PNG" || FileExt == "JPG" || FileExt == "JPEG")
                {
                    // Check NSFW
                    var result = API.CheckNSFW(APIKEY, BinaryData);
                    if (result != null) { file.Comment = API.Concat(API.NSFWPrefix(result), file.Comment); }

                    // Add Desription to Comment
                    var description = API.Describe(APIKEY, BinaryData);
                    if (description != null) { file.Comment = API.Concat(file.Comment, description); }

                    // Resize PNG Files
                    if(FileExt == "PNG")
                    {
                        file.Data = API.Resize(APIKEY, BinaryData);
                    }

                }

                // Scan Virus
                var scan = API.VirusScan(APIKEY, BinaryData);
                if (scan ?? false == true)
                {
                    file.Comment = API.Concat(file.Comment, "[Virus Scanned]");
                }
                else
                {
                    file.Comment = API.Concat(file.Comment, "[Virus Detected]");

                }

            }


            // Call the base method
            if (del != null) del.Invoke();
        }

    }
}
