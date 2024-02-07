using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TaskBoard_App.Data.Configuration
{
    public class BoardConfiguration : IEntityTypeConfiguration<Board>
    {
        public void Configure(EntityTypeBuilder<Board> builder)
        {
            builder
                .HasData(new Board[]
                {
                    ConfigurationHelper.InProgressBoard,
                    ConfigurationHelper.DoneBoard,
                    ConfigurationHelper.OpenBoard,
                });
        }
    }
}
