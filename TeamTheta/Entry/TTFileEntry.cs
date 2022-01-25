using System;
using PX.Data;

namespace TeamTheta
{
    public class TTFileEntry : PXGraph<TTFileEntry>
    {
        public PXSavePerRow<TTFileData> Save;
        public PXCancel<TTFileData> Cancel;

        [PXImport(typeof(TTFileData))]
        [PXFilterable]
        public PXSelectOrderBy<TTFileData, OrderBy<Asc<TTFileData.fileName>>> FileRecords;


    }
}