using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Task.Models;

public partial class NwcContext : DbContext
{
    public NwcContext()
    {
    }

    public NwcContext(DbContextOptions<NwcContext> options)
        : base(options)
    {
    }

    public virtual DbSet<NwcDefaultSliceValue> NwcDefaultSliceValues { get; set; }

    public virtual DbSet<NwcInvoice> NwcInvoices { get; set; }

    public virtual DbSet<NwcRrealEstateType> NwcRrealEstateTypes { get; set; }

    public virtual DbSet<NwcSubscriberFile> NwcSubscriberFiles { get; set; }

    public virtual DbSet<NwcSubscriptionFile> NwcSubscriptionFiles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=NWC;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<NwcDefaultSliceValue>(entity =>
        {
            entity.HasKey(e => e.NwcDefaultSliceValuesCode);

            entity.ToTable("NWC_Default_Slice_Values");

            entity.Property(e => e.NwcDefaultSliceValuesCode)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("NWC_Default_Slice_Values_Code");
            entity.Property(e => e.NwcDefaultSliceValuesCondtion).HasColumnName("NWC_Default_Slice_Values_Condtion");
            entity.Property(e => e.NwcDefaultSliceValuesName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NWC_Default_Slice_Values_Name");
            entity.Property(e => e.NwcDefaultSliceValuesReasons)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NWC_Default_Slice_Values_Reasons");
            entity.Property(e => e.NwcDefaultSliceValuesSanitationPrice)
                .HasColumnType("decimal(6, 2)")
                .HasColumnName("NWC_Default_Slice_Values_Sanitation_Price");
            entity.Property(e => e.NwcDefaultSliceValuesWaterPrice)
                .HasColumnType("decimal(6, 2)")
                .HasColumnName("NWC_Default_Slice_Values_Water_Price");
        });

        modelBuilder.Entity<NwcInvoice>(entity =>
        {
            entity.HasKey(e => e.NwcInvoicesNo);

            entity.ToTable("NWC_Invoices");

            entity.Property(e => e.NwcInvoicesNo)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("NWC_Invoices_No");
            entity.Property(e => e.NwcInvoicesAmountConsumption).HasColumnName("NWC_Invoices_Amount_Consumption");
            entity.Property(e => e.NwcInvoicesConsumptionValue)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("NWC_Invoices_Consumption_Value");
            entity.Property(e => e.NwcInvoicesCurrentConsumptionAmount).HasColumnName("NWC_Invoices_Current_Consumption_Amount");
            entity.Property(e => e.NwcInvoicesDate)
                .HasColumnType("date")
                .HasColumnName("NWC_Invoices_Date");
            entity.Property(e => e.NwcInvoicesFrom)
                .HasColumnType("date")
                .HasColumnName("NWC_Invoices_From");
            entity.Property(e => e.NwcInvoicesIsThereSanitation).HasColumnName("NWC_Invoices_Is_ There_Sanitation");
            entity.Property(e => e.NwcInvoicesPreviousConsumptionAmount).HasColumnName("NWC_Invoices_Previous_Consumption_Amount");
            entity.Property(e => e.NwcInvoicesRrealEstateTypes)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("NWC_Invoices_Rreal_Estate_Types");
            entity.Property(e => e.NwcInvoicesServiceFee)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("NWC_Invoices_Service_Fee");
            entity.Property(e => e.NwcInvoicesSubscriberNo)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("NWC_Invoices_Subscriber_No");
            entity.Property(e => e.NwcInvoicesSubscriptionNo)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("NWC_Invoices_Subscription_No");
            entity.Property(e => e.NwcInvoicesTaxRate)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("NWC_Invoices_Tax_Rate");
            entity.Property(e => e.NwcInvoicesTaxValue)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("NWC_Invoices_Tax_Value");
            entity.Property(e => e.NwcInvoicesTo)
                .HasColumnType("date")
                .HasColumnName("NWC_Invoices_To");
            entity.Property(e => e.NwcInvoicesTotalBill)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("NWC_Invoices_Total_Bill");
            entity.Property(e => e.NwcInvoicesTotalInvoice)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("NWC_Invoices_Total_Invoice");
            entity.Property(e => e.NwcInvoicesTotalReasons)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NWC_Invoices_Total_Reasons");
            entity.Property(e => e.NwcInvoicesWastewaterConsumptionValue)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("NWC_Invoices_Wastewater_Consumption_Value");
            entity.Property(e => e.NwcInvoicesYear)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("NWC_Invoices_Year");

            entity.HasOne(d => d.NwcInvoicesRrealEstateTypesNavigation).WithMany(p => p.NwcInvoices)
                .HasForeignKey(d => d.NwcInvoicesRrealEstateTypes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_NWC_Invoices_NWC_Rreal_Estate_Types");

            entity.HasOne(d => d.NwcInvoicesSubscriberNoNavigation).WithMany(p => p.NwcInvoices)
                .HasForeignKey(d => d.NwcInvoicesSubscriberNo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_NWC_Invoices_NWC_Subscriber_File");

            entity.HasOne(d => d.NwcInvoicesSubscriptionNoNavigation).WithMany(p => p.NwcInvoices)
                .HasForeignKey(d => d.NwcInvoicesSubscriptionNo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_NWC_Invoices_NWC_Subscription_File");
        });

        modelBuilder.Entity<NwcRrealEstateType>(entity =>
        {
            entity.HasKey(e => e.NwcRrealEstateTypesCode);

            entity.ToTable("NWC_Rreal_Estate_Types");

            entity.Property(e => e.NwcRrealEstateTypesCode)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("NWC_Rreal_Estate_Types_Code");
            entity.Property(e => e.NwcRrealEstateTypesName)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("NWC_Rreal_Estate_Types_Name");
            entity.Property(e => e.NwcRrealEstateTypesReasons)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NWC_Rreal_Estate_Types_Reasons");
        });

        modelBuilder.Entity<NwcSubscriberFile>(entity =>
        {
            entity.ToTable("NWC_Subscriber_File");

            entity.Property(e => e.NwcSubscriberFileId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("NWC_Subscriber_File_Id");
            entity.Property(e => e.NwcSubscriberFileArea)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NWC_Subscriber_File_Area");
            entity.Property(e => e.NwcSubscriberFileCity)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NWC_Subscriber_File_City");
            entity.Property(e => e.NwcSubscriberFileMobile)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("NWC_Subscriber_File_Mobile");
            entity.Property(e => e.NwcSubscriberFileName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NWC_Subscriber_File_Name");
            entity.Property(e => e.NwcSubscriberFileReasons)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NWC_Subscriber_File_Reasons");
        });

        modelBuilder.Entity<NwcSubscriptionFile>(entity =>
        {
            entity.HasKey(e => e.NwcSubscriptionFileNo);

            entity.ToTable("NWC_Subscription_File");

            entity.Property(e => e.NwcSubscriptionFileNo)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("NWC_Subscription_File_No");
            entity.Property(e => e.NwcSubscriptionFileIsThereSanitation).HasColumnName("NWC_Subscription_File_Is_ There_Sanitation");
            entity.Property(e => e.NwcSubscriptionFileLastReadingMeter).HasColumnName("NWC_Subscription_File_Last_Reading_Meter");
            entity.Property(e => e.NwcSubscriptionFileReasons)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NWC_Subscription_File_Reasons");
            entity.Property(e => e.NwcSubscriptionFileRrealEstateTypesCode)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("NWC_Subscription_File_Rreal_Estate_Types_Code");
            entity.Property(e => e.NwcSubscriptionFileSubscriberCode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("NWC_Subscription_File_Subscriber_Code");
            entity.Property(e => e.NwcSubscriptionFileUnitNo).HasColumnName("NWC_Subscription_File_Unit_No");

            entity.HasOne(d => d.NwcSubscriptionFileRrealEstateTypesCodeNavigation).WithMany(p => p.NwcSubscriptionFiles)
                .HasForeignKey(d => d.NwcSubscriptionFileRrealEstateTypesCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_NWC_Subscription_File_NWC_Rreal_Estate_Types");

            entity.HasOne(d => d.NwcSubscriptionFileSubscriberCodeNavigation).WithMany(p => p.NwcSubscriptionFiles)
                .HasForeignKey(d => d.NwcSubscriptionFileSubscriberCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_NWC_Subscription_File_NWC_Subscriber_File");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

}
