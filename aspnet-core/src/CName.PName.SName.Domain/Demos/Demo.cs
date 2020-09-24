using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities.Auditing;

namespace CName.PName.SName.Demos
{
    public class Demo : FullAuditedEntity<Guid>
    {
        public string Name { get; set; }

        public List<DemoLocalizableEntry> Entries { get; set; }
    }
}
