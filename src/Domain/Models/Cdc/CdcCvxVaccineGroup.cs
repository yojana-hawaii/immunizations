﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Domain.Model.Extension;

namespace Domain.Models.Cdc;

public class CdcCvxVaccineGroup : AuditableEntity, IEquatable<CdcCvxVaccineGroup>
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [StringLength(100)]
    public required string ShortDescription { get; set; }
    [StringLength(5)]
    public required string CdcCvxCode { get; set; }
    [StringLength(15)]
    public required string VaccineStatus { get; set; }
    [StringLength(100)]
    public required string VaccineGroupName { get; set; }
    [MaxLength(5)]
    public required string VaccineGroupCvxCode { get; set; }



    public static bool CdcFetchComparer(CdcCvxVaccineGroup item, CdcCvxVaccineGroup other)
    {
        return item.VaccineStatus == other.VaccineStatus && item.VaccineGroupName == other.VaccineGroupName;
    }

    public bool Equals(CdcCvxVaccineGroup? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;

        return this.CdcCvxCode == other.CdcCvxCode && this.VaccineGroupCvxCode == other.VaccineGroupCvxCode;
    }

    public override bool Equals(object? obj) => Equals(obj as CdcCvxVaccineGroup);

    public override int GetHashCode() => (CdcCvxCode, VaccineGroupCvxCode).GetHashCode();
}
