using Domain.Models.Cdc;

namespace Domain.Utility.CdcComparer;

public class CdcCvxManufacturerEquality : IEqualityComparer<CdcCvxManufacturer>
{
    public bool Equals(CdcCvxManufacturer? mfr1, CdcCvxManufacturer? mfr2)
    {
        if(ReferenceEquals(mfr1, mfr2)) return true;
        if(mfr1 is null || mfr2 is null) return false;

        return mfr1.CdcCvxCode == mfr2.CdcCvxCode
            && mfr1.CdcProductName == mfr2.CdcProductName
            && mfr1.MvxCode == mfr2.MvxCode;
    }

    public int GetHashCode(CdcCvxManufacturer mfr)
    {
        return (mfr.CdcCvxCode, mfr.CdcProductName, mfr.MvxCode).GetHashCode();
    }
}
