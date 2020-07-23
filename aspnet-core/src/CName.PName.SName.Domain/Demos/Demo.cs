using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace CName.PName.SName.Demos
{
    public class Demo : FullAuditedEntity<Guid>
    {
        public string Name { get; set; }
    }
}
