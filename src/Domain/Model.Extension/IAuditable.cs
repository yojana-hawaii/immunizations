﻿namespace Domain.Model.Extension;

public interface IAuditable
{
    string? CreatedBy { get; set; }
    string? ModifiedBy { get; set; }
    DateTime? CreatedDate { get; set; }
    DateTime? ModifiedDate { get; set; }
}
