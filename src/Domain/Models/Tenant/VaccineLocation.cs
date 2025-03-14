﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Domain.Model.Extension;

namespace Domain.Models.Tenant;

public class VaccineLocation : AuditableEntity
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Display(Name = "Location")]
    public string Summary
    {
        get
        {
            return LocationName + (string.IsNullOrWhiteSpace(SubLocation) ? " " : " / " + SubLocation);
        }

    }

    [Required(ErrorMessage = "{0} is required. Example: location could be building name & sub-location can be floors in the building.")]
    [StringLength(100, ErrorMessage = "{0} cannot exceed {1} characters")]
    [Display(Name = "Location Name (example: Building)")]
    public string LocationName { get; set; } = "";


    [StringLength(100, ErrorMessage = "{0} cannot exceed {1} characters")]
    [Display(Name = "Sub Location (example: Floor)")]
    public string? SubLocation { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public string ComputedSubLocationForUniqueness { get; set; } = "";

}
