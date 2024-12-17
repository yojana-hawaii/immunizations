using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.CDC
{
    public class CdcCvxCpt
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CdcCvxCptId { get; set; }
        
        [MaxLength(10)] 
        public required string CptCode { get; set; }
        [MaxLength(100)] 
        public required string CptDescription { get; set; }
        [MaxLength(5)] 
        public required string CdcCvxCode { get; set; }
        [MaxLength(100)] 
        public required string VaccineName { get; set; }
        [MaxLength(500)] 
        public string? Comments { get; set; }
        public DateOnly LateUpdatedDate { get; set; }
    }
}
