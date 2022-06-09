﻿// <auto-generated />
using System;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Domain.Entities.Commitment.CommitmentEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CommitmentCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("CommitmentScaffoldingId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double?>("Compensation")
                        .HasColumnType("float");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DateOverdue")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("HostelId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<Guid?>("ManagerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("PaymentDate")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<Guid>("RoomId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Commitment Status");

                    b.Property<Guid?>("TenantId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CommitmentScaffoldingId");

                    b.HasIndex("HostelId");

                    b.HasIndex("ManagerId");

                    b.HasIndex("OwnerId");

                    b.HasIndex("RoomId");

                    b.HasIndex("TenantId");

                    b.ToTable("Commitments");
                });

            modelBuilder.Entity("Domain.Entities.Commitment.CommitmentScaffolding", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("CommitmentScaffoldings");
                });

            modelBuilder.Entity("Domain.Entities.Commitment.JoiningCode", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CommitmentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("SixDigitsCode")
                        .HasColumnType("int");

                    b.Property<int>("TimeSpan")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CommitmentId")
                        .IsUnique();

                    b.ToTable("JoiningCodes");
                });

            modelBuilder.Entity("Domain.Entities.Facility.FacilityEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("HostelId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("HostelId");

                    b.ToTable("Facilities");
                });

            modelBuilder.Entity("Domain.Entities.Facility.FacilityManagement", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("FacilityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<Guid>("RoomId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("FacilityId");

                    b.HasIndex("RoomId");

                    b.ToTable("FacilityManagements");
                });

            modelBuilder.Entity("Domain.Entities.Hostel.HostelManagement", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("HostelId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnOrder(1);

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<Guid>("ManagerId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnOrder(2);

                    b.HasKey("Id");

                    b.HasIndex("HostelId");

                    b.HasIndex("ManagerId");

                    b.ToTable("HostelManagents");
                });

            modelBuilder.Entity("Domain.Entities.HostelEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImgPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("NumOfRooms")
                        .HasColumnType("int");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("Hostels");
                });

            modelBuilder.Entity("Domain.Entities.Invoice.InvoiceEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("InvoiceCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InvoiceType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<Guid>("ManagerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<Guid>("RoomId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("TenantPaidId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ManagerId");

                    b.HasIndex("RoomId");

                    b.HasIndex("TenantPaidId");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("Domain.Entities.InvoiceSchedule.InvoiceScheduleEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cron")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InvoiceType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<Guid>("ManagerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<Guid>("RoomId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ManagerId");

                    b.HasIndex("RoomId");

                    b.ToTable("InvoiceSchedules");
                });

            modelBuilder.Entity("Domain.Entities.Message.MessageEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<Guid>("TicketId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("TicketId");

                    b.HasIndex("UserId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("Domain.Entities.Notification.NotificationEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsSent")
                        .HasColumnType("bit");

                    b.Property<bool>("IsUnread")
                        .HasColumnType("bit");

                    b.Property<Guid>("ManagerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoomId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TransactionCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ManagerId");

                    b.HasIndex("RoomId");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("Domain.Entities.Room.RoomEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Area")
                        .HasColumnType("float");

                    b.Property<double>("Height")
                        .HasColumnType("float");

                    b.Property<Guid>("HostelId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<double>("Length")
                        .HasColumnType("float");

                    b.Property<int?>("MaximumPeople")
                        .HasColumnType("int");

                    b.Property<int>("NumOfBathRooms")
                        .HasColumnType("int");

                    b.Property<int>("NumOfDoors")
                        .HasColumnType("int");

                    b.Property<int>("NumOfWCs")
                        .HasColumnType("int");

                    b.Property<int>("NumOfWindows")
                        .HasColumnType("int");

                    b.Property<string>("RoomName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoomTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Room Status");

                    b.Property<double>("Width")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("HostelId");

                    b.HasIndex("RoomTypeId");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("Domain.Entities.Room.RoomType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CategoryName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("RoomTypes");
                });

            modelBuilder.Entity("Domain.Entities.Ticket.TicketEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Discription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImgPaths")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<Guid>("RoomId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TenantId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoomId");

                    b.HasIndex("TenantId");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("Domain.Entities.User.RoomTenant", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<Guid>("RoomId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnOrder(1);

                    b.Property<Guid>("TenantId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnOrder(2);

                    b.HasKey("Id");

                    b.HasIndex("RoomId");

                    b.HasIndex("TenantId");

                    b.ToTable("RoomTenants");
                });

            modelBuilder.Entity("Domain.Entities.UserEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Avatar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BackIdentification")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CitizenIdentity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FrontIdentification")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GenderString")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Gender");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OrganizationCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("OwnerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleString")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Role");

                    b.Property<string>("TaxCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Domain.Entities.Commitment.CommitmentEntity", b =>
                {
                    b.HasOne("Domain.Entities.Commitment.CommitmentScaffolding", "CommitmentScaffolding")
                        .WithMany()
                        .HasForeignKey("CommitmentScaffoldingId");

                    b.HasOne("Domain.Entities.HostelEntity", "Hostel")
                        .WithMany("Commitments")
                        .HasForeignKey("HostelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.UserEntity", "Manager")
                        .WithMany("ManagerCommitments")
                        .HasForeignKey("ManagerId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("Domain.Entities.UserEntity", "Owner")
                        .WithMany("OwnerCommitments")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Room.RoomEntity", "Room")
                        .WithMany("Commitments")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Domain.Entities.UserEntity", "Tenant")
                        .WithMany("TenantCommitments")
                        .HasForeignKey("TenantId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("CommitmentScaffolding");

                    b.Navigation("Hostel");

                    b.Navigation("Manager");

                    b.Navigation("Owner");

                    b.Navigation("Room");

                    b.Navigation("Tenant");
                });

            modelBuilder.Entity("Domain.Entities.Commitment.JoiningCode", b =>
                {
                    b.HasOne("Domain.Entities.Commitment.CommitmentEntity", "Commitment")
                        .WithOne("JoiningCode")
                        .HasForeignKey("Domain.Entities.Commitment.JoiningCode", "CommitmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Commitment");
                });

            modelBuilder.Entity("Domain.Entities.Facility.FacilityEntity", b =>
                {
                    b.HasOne("Domain.Entities.HostelEntity", "Hostel")
                        .WithMany("Facilities")
                        .HasForeignKey("HostelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hostel");
                });

            modelBuilder.Entity("Domain.Entities.Facility.FacilityManagement", b =>
                {
                    b.HasOne("Domain.Entities.Facility.FacilityEntity", "Facility")
                        .WithMany("FacilityManagements")
                        .HasForeignKey("FacilityId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Room.RoomEntity", "Room")
                        .WithMany("FacilityManagements")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Facility");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("Domain.Entities.Hostel.HostelManagement", b =>
                {
                    b.HasOne("Domain.Entities.HostelEntity", "Hostel")
                        .WithMany("HostelManagements")
                        .HasForeignKey("HostelId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Domain.Entities.UserEntity", "Manager")
                        .WithMany("HostelManagements")
                        .HasForeignKey("ManagerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Hostel");

                    b.Navigation("Manager");
                });

            modelBuilder.Entity("Domain.Entities.HostelEntity", b =>
                {
                    b.HasOne("Domain.Entities.UserEntity", "Owner")
                        .WithMany("Hostels")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("Domain.Entities.Invoice.InvoiceEntity", b =>
                {
                    b.HasOne("Domain.Entities.UserEntity", "Manager")
                        .WithMany("ManagerCreatedInvoices")
                        .HasForeignKey("ManagerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Room.RoomEntity", "Room")
                        .WithMany("ManagerCreatedInvoices")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Domain.Entities.UserEntity", "TenantPaid")
                        .WithMany("TenantPaidInvoices")
                        .HasForeignKey("TenantPaidId");

                    b.Navigation("Manager");

                    b.Navigation("Room");

                    b.Navigation("TenantPaid");
                });

            modelBuilder.Entity("Domain.Entities.InvoiceSchedule.InvoiceScheduleEntity", b =>
                {
                    b.HasOne("Domain.Entities.UserEntity", "Manager")
                        .WithMany("ManegerCreatedInvoiceSchedules")
                        .HasForeignKey("ManagerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Room.RoomEntity", "Room")
                        .WithMany("ManegerCreatedInvoiceSchedules")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Manager");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("Domain.Entities.Message.MessageEntity", b =>
                {
                    b.HasOne("Domain.Entities.Ticket.TicketEntity", "Ticket")
                        .WithMany("Messages")
                        .HasForeignKey("TicketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.UserEntity", "User")
                        .WithMany("Messages")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ticket");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.Notification.NotificationEntity", b =>
                {
                    b.HasOne("Domain.Entities.UserEntity", "Manager")
                        .WithMany("Notifications")
                        .HasForeignKey("ManagerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Room.RoomEntity", "Room")
                        .WithMany("Notifications")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Manager");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("Domain.Entities.Room.RoomEntity", b =>
                {
                    b.HasOne("Domain.Entities.HostelEntity", "Hostel")
                        .WithMany("Rooms")
                        .HasForeignKey("HostelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Room.RoomType", "RoomType")
                        .WithMany("Rooms")
                        .HasForeignKey("RoomTypeId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Hostel");

                    b.Navigation("RoomType");
                });

            modelBuilder.Entity("Domain.Entities.Ticket.TicketEntity", b =>
                {
                    b.HasOne("Domain.Entities.Room.RoomEntity", "Room")
                        .WithMany("Tickets")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Domain.Entities.UserEntity", "Tenant")
                        .WithMany("Tickets")
                        .HasForeignKey("TenantId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Room");

                    b.Navigation("Tenant");
                });

            modelBuilder.Entity("Domain.Entities.User.RoomTenant", b =>
                {
                    b.HasOne("Domain.Entities.Room.RoomEntity", "Room")
                        .WithMany("RoomTenants")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Domain.Entities.UserEntity", "Tenant")
                        .WithMany("RoomTenants")
                        .HasForeignKey("TenantId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Room");

                    b.Navigation("Tenant");
                });

            modelBuilder.Entity("Domain.Entities.UserEntity", b =>
                {
                    b.HasOne("Domain.Entities.UserEntity", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("Domain.Entities.Commitment.CommitmentEntity", b =>
                {
                    b.Navigation("JoiningCode");
                });

            modelBuilder.Entity("Domain.Entities.Facility.FacilityEntity", b =>
                {
                    b.Navigation("FacilityManagements");
                });

            modelBuilder.Entity("Domain.Entities.HostelEntity", b =>
                {
                    b.Navigation("Commitments");

                    b.Navigation("Facilities");

                    b.Navigation("HostelManagements");

                    b.Navigation("Rooms");
                });

            modelBuilder.Entity("Domain.Entities.Room.RoomEntity", b =>
                {
                    b.Navigation("Commitments");

                    b.Navigation("FacilityManagements");

                    b.Navigation("ManagerCreatedInvoices");

                    b.Navigation("ManegerCreatedInvoiceSchedules");

                    b.Navigation("Notifications");

                    b.Navigation("RoomTenants");

                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("Domain.Entities.Room.RoomType", b =>
                {
                    b.Navigation("Rooms");
                });

            modelBuilder.Entity("Domain.Entities.Ticket.TicketEntity", b =>
                {
                    b.Navigation("Messages");
                });

            modelBuilder.Entity("Domain.Entities.UserEntity", b =>
                {
                    b.Navigation("HostelManagements");

                    b.Navigation("Hostels");

                    b.Navigation("ManagerCommitments");

                    b.Navigation("ManagerCreatedInvoices");

                    b.Navigation("ManegerCreatedInvoiceSchedules");

                    b.Navigation("Messages");

                    b.Navigation("Notifications");

                    b.Navigation("OwnerCommitments");

                    b.Navigation("RoomTenants");

                    b.Navigation("TenantCommitments");

                    b.Navigation("TenantPaidInvoices");

                    b.Navigation("Tickets");
                });
#pragma warning restore 612, 618
        }
    }
}
