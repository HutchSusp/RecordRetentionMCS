using System;
using System.Data.Linq.Mapping;
using System.Data.Linq;

namespace RetentionDraft2
{
    [Table(Name = "dbo.Department")]
    public class Department
    {
        [Column(IsPrimaryKey = true)]
        public string Name { get; set; }
        [Column(CanBeNull = false)]
        public int Number { get; set; }
    }

    [Table(Name = "dbo.Classification")]
    public class Classification
    {
        [Column(IsPrimaryKey = true)]
        public string DepartmentName { get; set; }
        [Column(IsPrimaryKey = true)]
        public string ClassificationName { get; set; }
        [Column(CanBeNull = false)]
        public int Number { get; set; }
        [Column(CanBeNull = true)]
        public double? YearsRetained { get; set; }
    }

    [Table(Name = "dbo.Title")]
    public class Title
    {
        [Column(IsPrimaryKey = true)]
        public string DepartmentName { get; set; }
        [Column(IsPrimaryKey = true)]
        public string ClassificationName { get; set; }
        [Column(IsPrimaryKey = true, Name = "Title")]
        public string MyTitle { get; set; }
    }

    [Table(Name = "dbo.Box")]
    public class Box
    {
        [Column(IsPrimaryKey = true)]
        public int BoxNumber { get; set; }
        [Column(CanBeNull = false)]
        public string DepartmentName { get; set; }
        [Column(CanBeNull = false)]
        public string ClassificationName { get; set; }
        [Column(CanBeNull = false)]
        public string StorageMedium { get; set; }
        [Column(CanBeNull = true)]
        public string RackNumber { get; set; }
        [Column(CanBeNull = true)]
        public string DepreciatedNumber { get; set; }
        [Column(CanBeNull = false)]
        public string Description { get; set; }
    }

    [Table(Name = "dbo.Record")]
    public class Record
    {
        [Column(IsPrimaryKey = true)]
        public int BoxNumber { get; set; }
        [Column(IsPrimaryKey = true)]
        public string RecordID { get; set; }
        [Column(CanBeNull = false)]
        public string Title { get; set; }
        [Column(CanBeNull = false)]
        public DateTime StartDate { get; set; }
        [Column(CanBeNull = false)]
        public DateTime EndDate { get; set; }
        [Column(CanBeNull = false)]
        public bool IsExecutive { get; set; }
        [Column(CanBeNull = true)]
        public DateTime? RetainUntil { get; set; }
        [Column(CanBeNull = false)]
        public string Notes { get; set; }
        [Column(CanBeNull = false)]
        public bool IsDestoryed { get; set; }
        [Column(CanBeNull = true)]
        public DateTime? DestoryDate { get; set; }
        [Column(CanBeNull = true)]
        public string DestoryAuthorization { get; set; }
        [Column(CanBeNull = false)]
        public bool IsHeld { get; set; }
        [Column(CanBeNull = true)]
        public DateTime? HoldDate { get; set; }
        [Column(CanBeNull = true)]
        public string HoldNotes { get; set; }
    }
}