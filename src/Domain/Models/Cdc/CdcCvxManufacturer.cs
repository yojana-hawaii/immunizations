﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Domain.Model.Extension;

namespace Domain.Models.Cdc;

public class CdcCvxManufacturer : AuditableEntity, IEquatable<CdcCvxManufacturer>
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [StringLength(100)]
    public required string CdcProductName { get; set; }
    [StringLength(100)]
    public required string ShortDescription { get; set; }
    [StringLength(5)]
    public required string CdcCvxCode { get; set; }
    [StringLength(100)]
    public string? Manufacturer { get; set; }
    [StringLength(5)]
    public string? MvxCode { get; set; }
    [StringLength(15)]
    public required string MvxStatus { get; set; }
    [StringLength(15)]
    public required string ProductNameStatus { get; set; }
    public required DateOnly LastUpdatedDate { get; set; }

    public static bool CdcFetchComparer(CdcCvxManufacturer item, CdcCvxManufacturer other)
    {
        return item.LastUpdatedDate == other.LastUpdatedDate;
    }

    public bool Equals(CdcCvxManufacturer? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;

        return this.CdcCvxCode == other.CdcCvxCode && this.CdcProductName == other.CdcProductName && this.MvxCode == other.MvxCode;
    }

    public override bool Equals(object? obj) => Equals(obj as CdcCvxVaccineGroup);

    public override int GetHashCode() => (CdcCvxCode, CdcProductName, MvxCode).GetHashCode();
}
