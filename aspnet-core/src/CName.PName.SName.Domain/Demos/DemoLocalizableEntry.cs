using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abpluz.Abp.LocalizableContents;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.Localization;

namespace CName.PName.SName.Demos
{
    public class DemoLocalizableEntry : CreationAuditedEntity, IHasLocalizableContent
    {
        public Guid Id { get; set; }

        public string CultureName { get; set; }

        public string DisplayName { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public override object[] GetKeys()
        {
            return new object[] { Id, CultureName };
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (!CultureHelper.IsValidCultureCode(CultureName))
            {
                yield return new ValidationResult($"{nameof(CultureName)} not valid!", new string[] { nameof(CultureName) });
            }
        }
    }
}