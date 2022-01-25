using PX.Data;
using PX.Data.BQL.Fluent;

namespace TeamTheta.TT
{
    public class TTSetupMaint : PXGraph<TTSetupMaint>
    {
        public PXSave<TTSetup> Save;
        public PXCancel<TTSetup> Cancel;

        public SelectFrom<TTSetup>.View Preferences;

    }
}
