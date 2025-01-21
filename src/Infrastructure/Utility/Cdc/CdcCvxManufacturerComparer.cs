using System.Diagnostics.CodeAnalysis;

namespace Infrastructure.Utility.Cdc;

public class CdcCvxManufacturerComparer : IEqualityComparer<CdcCvxManufacturer>
{
    public bool Equals(CdcCvxManufacturer? mfr1, CdcCvxManufacturer? mfr2)
    {
        if(ReferenceEquals(mfr1, mfr2)) return true;
        if(mfr1 is null || mfr2 is null) return false;

        return mfr1.CdcCvxCode == mfr2.CdcCvxCode
            && mfr1.CdcProductName == mfr2.CdcProductName
            && mfr1.MvxCode + 'x' == mfr2.MvxCode + 'x';
    }

    public int GetHashCode([DisallowNull] CdcCvxManufacturer mfr)
    {
        return (mfr.CdcCvxCode, mfr.CdcProductName, mfr.MvxCode).GetHashCode();
    }
}
