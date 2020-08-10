using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;

namespace CName.PName.SName.EntityFrameworkCore
{
    public static class PropertyBuidlerExtensions
    {
        public static void HasColumnTypeJsonb<TDeserializeType>(this PropertyBuilder<TDeserializeType> builder)
        {
            builder.HasColumnType("jsonb")
                .HasConversion(b => JsonConvert.SerializeObject(b), b => JsonConvert.DeserializeObject<TDeserializeType>(b));
        }
    }
}
