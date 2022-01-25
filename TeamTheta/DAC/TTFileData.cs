using System;
using PX.Data;

namespace TeamTheta
{
    [Serializable]
    [PXCacheName("TTFileData")]
    public class TTFileData : IBqlTable
    {
        #region FileID
        [PXDBIdentity(IsKey = true)]
        [PXUIField(DisplayName = "File ID")]
        public virtual int? FileID { get; set; }
        public abstract class fileID : PX.Data.BQL.BqlInt.Field<fileID> { }
        #endregion

        #region FileName
        [PXDBString(500, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "File Name")]
        public virtual string FileName { get; set; }
        public abstract class fileName : PX.Data.BQL.BqlString.Field<fileName> { }
        #endregion

        #region FileStatus
        [PXDBInt()]
        [PXIntList(
            new int[]
            {
               -2,-1,0,1,5
            },
            new string[]
            {
                "Ignore",
                "Failed",
                "Open",
                "Processed",
                "Closed"
            })]
        [PXUIField(DisplayName = "File Status")]
        public virtual int? FileStatus { get; set; }
        public abstract class fileStatus : PX.Data.BQL.BqlInt.Field<fileStatus> { }
        #endregion

        #region Folder
        [PXDBString(100, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Folder")]
        public virtual string Folder { get; set; }
        public abstract class folder : PX.Data.BQL.BqlString.Field<folder> { }
        #endregion

        #region FileResult
        [PXDBString(100, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Result")]
        public virtual string FileResult { get; set; }
        public abstract class fileResult : PX.Data.BQL.BqlString.Field<fileResult> { }
        #endregion

        #region FileLocation
        [PXDBString(500, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "File Location")]
        public virtual string FileLocation { get; set; }
        public abstract class fileLocation : PX.Data.BQL.BqlString.Field<fileLocation> { }
        #endregion

        #region FileSize
        [PXDBDecimal()]
        [PXUIField(DisplayName = "File Size (Kb)")]
        public virtual Decimal? FileSize { get; set; }
        public abstract class fileSize : PX.Data.BQL.BqlDecimal.Field<fileSize> { }
        #endregion

        #region UploadedBy
        [PXDBString(100, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Uploaded By")]
        public virtual string UploadedBy { get; set; }
        public abstract class uploadedBy : PX.Data.BQL.BqlString.Field<uploadedBy> { }
        #endregion
        
        #region Tstamp
        [PXDBTimestamp()]
        public virtual byte[] Tstamp { get; set; }
        public abstract class tstamp : PX.Data.BQL.BqlByteArray.Field<tstamp> { }
        #endregion

        #region CreatedByID
        [PXDBCreatedByID()]
        public virtual Guid? CreatedByID { get; set; }
        public abstract class createdByID : PX.Data.BQL.BqlGuid.Field<createdByID> { }
        #endregion

        #region CreatedByScreenID
        [PXDBCreatedByScreenID()]
        public virtual string CreatedByScreenID { get; set; }
        public abstract class createdByScreenID : PX.Data.BQL.BqlString.Field<createdByScreenID> { }
        #endregion

        #region CreatedDateTime
        [PXDBCreatedDateTime()]
        public virtual DateTime? CreatedDateTime { get; set; }
        public abstract class createdDateTime : PX.Data.BQL.BqlDateTime.Field<createdDateTime> { }
        #endregion

        #region LastModifiedByID
        [PXDBLastModifiedByID()]
        public virtual Guid? LastModifiedByID { get; set; }
        public abstract class lastModifiedByID : PX.Data.BQL.BqlGuid.Field<lastModifiedByID> { }
        #endregion

        #region LastModifiedByScreenID
        [PXDBLastModifiedByScreenID()]
        public virtual string LastModifiedByScreenID { get; set; }
        public abstract class lastModifiedByScreenID : PX.Data.BQL.BqlString.Field<lastModifiedByScreenID> { }
        #endregion

        #region LastModifiedDateTime
        [PXDBLastModifiedDateTime()]
        public virtual DateTime? LastModifiedDateTime { get; set; }
        public abstract class lastModifiedDateTime : PX.Data.BQL.BqlDateTime.Field<lastModifiedDateTime> { }
        #endregion

        #region NoteID
        [PXNote()]
        public virtual Guid? NoteID { get; set; }
        public abstract class noteID : PX.Data.BQL.BqlGuid.Field<noteID> { }
        #endregion
    }
}