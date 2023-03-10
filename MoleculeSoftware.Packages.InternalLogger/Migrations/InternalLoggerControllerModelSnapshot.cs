// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MoleculeSoftware.Packages.InternalLogger;

#nullable disable

namespace MoleculeSoftware.Packages.InternalLogger.Migrations
{
    [DbContext(typeof(InternalLoggerController))]
    partial class InternalLoggerControllerModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.1");

            modelBuilder.Entity("MoleculeSoftware.Packages.InternalLogger.InternalLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AdditionalInformation")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("LogType")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("InternalLogs");
                });
#pragma warning restore 612, 618
        }
    }
}
