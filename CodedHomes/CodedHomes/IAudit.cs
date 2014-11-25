using System;
namespace CodedHomes
{
    public interface IAudit
    {
        DateTime CreatedOn { get; set; }
        DateTime ModifiedOn { get; set; }
    }
}
