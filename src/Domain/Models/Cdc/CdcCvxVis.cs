﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Domain.Model.Extension;

namespace Domain.Models.Cdc;

public class CdcCvxVis : AuditableEntity, IEquatable<CdcCvxVis>
{

    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [StringLength(5)]
    public required string CdcCvxCode { get; set; }
    [StringLength(100)]
    public required string CvxVaccineDescription { get; set; }
    [StringLength(30)]
    public required string VisFullyEncodedTextString { get; set; }
    [StringLength(100)]
    public required string VisDocumentName { get; set; }
    public DateOnly VisEditionDate { get; set; }
    [StringLength(15)]
    public string? VisEditionStatus { get; set; }



    public static bool CdcFetchComparer(CdcCvxVis item, CdcCvxVis other)
    {
        return item.VisEditionStatus == other.VisEditionStatus;
    }

    public bool Equals(CdcCvxVis? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;

        return this.CdcCvxCode == other.CdcCvxCode && this.VisDocumentName == other.VisDocumentName && this.VisEditionDate == other.VisEditionDate;
    }

    public override bool Equals(object? obj) => Equals(obj as CdcCvxVis);
    public override int GetHashCode() => (CdcCvxCode, VisDocumentName, VisEditionDate).GetHashCode();
}
