﻿namespace LeaveManagement.Domain.Common
{
    // абстрактный класс указывает на базовые поля, которые содержат все классы, которые наследуются от него
    public abstract class BaseDomainEntity
    {
        public int Id { get; set; }
        public DateTime? DateCreated { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public string? LastModifiedBy { get; set; }
    }
}
