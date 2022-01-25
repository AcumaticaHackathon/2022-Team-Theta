using System;
using PX.Data;

namespace TeamTheta
{
    public class TTFileProcessor : PXGraph<TTFileProcessor>
    {

        public PXSave<MasterTable> Save;
        public PXCancel<MasterTable> Cancel;


        public PXFilter<MasterTable> MasterView;
        public PXFilter<DetailsTable> DetailsView;

        [Serializable]
        public class MasterTable : IBqlTable
        {

        }

        [Serializable]
        public class DetailsTable : IBqlTable
        {

        }


    }
}