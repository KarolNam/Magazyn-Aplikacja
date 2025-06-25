using Microsoft.EntityFrameworkCore;
using WarehouseAPI.Database.Entities;

namespace WarehouseAPI.Database
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
		public required DbSet<Contractor> Contractors { get; set; }
		public required DbSet<ReceiptDocument> ReceiptDocuments { get; set; }
		public required DbSet<ReceiptItem> ReceiptItems { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<ReceiptItem>().Property(ri => ri.Quantity).HasPrecision(18, 4);
			modelBuilder.Entity<Contractor>().HasIndex(c => c.Symbol).IsUnique();
			modelBuilder.Entity<ReceiptDocument>().HasOne(rd => rd.Contractor).WithMany(c => c.Documents).HasForeignKey(rd => rd.ContractorId);
			modelBuilder.Entity<ReceiptItem>().HasOne(ri => ri.ReceiptDocument).WithMany(rd => rd.Items).HasForeignKey(ri => ri.ReceiptDocumentId);
		}
	}
}
