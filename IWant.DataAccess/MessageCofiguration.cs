using IWant.BusinessObject.Enitities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IWant.DataAccess
{
    public class MessageCofiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.ToTable("Messages");
            builder.Property(s => s.Content).IsRequired().HasMaxLength(750);

            builder.HasOne(s=>s.ToRoom)
                .WithMany(m=>m.Messages)
                .HasForeignKey(s=>s.ToRoomId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
