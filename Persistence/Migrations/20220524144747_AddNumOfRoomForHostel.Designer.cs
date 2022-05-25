﻿// <auto-generated />
using System;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220524144747_AddNumOfRoomForHostel")]
    partial class AddNumOfRoomForHostel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Domain.Entities.Commitment.CommitmentContains", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CommitmentId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnOrder(1);

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<Guid>("TenantId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnOrder(2);

                    b.HasKey("Id");

                    b.HasIndex("CommitmentId");

                    b.HasIndex("TenantId");

                    b.ToTable("CommitmentContains");
                });

            modelBuilder.Entity("Domain.Entities.Commitment.CommitmentEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CommitmentCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<Guid>("ManagerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoomId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ManagerId")
                        .IsUnique();

                    b.HasIndex("RoomId")
                        .IsUnique();

                    b.ToTable("Commitment");
                });

            modelBuilder.Entity("Domain.Entities.Facility.FacilityCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CategoryName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("FacilityCategories");
                });

            modelBuilder.Entity("Domain.Entities.Facility.FacilityEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FacilityCategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<Guid>("RoomId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("FacilityCategoryId");

                    b.HasIndex("RoomId");

                    b.ToTable("Facilities");
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

                    b.ToTable("HostelManagent");
                });

            modelBuilder.Entity("Domain.Entities.HostelCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CategoryName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("HostelCategory");
                });

            modelBuilder.Entity("Domain.Entities.HostelEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("HostelCategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumOfRooms")
                        .HasColumnType("int");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("HostelCategoryId");

                    b.HasIndex("OwnerId");

                    b.ToTable("Hostel");
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

                    b.Property<Guid>("InvoiceTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<Guid>("ManagerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<Guid>("RoomId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TenantPaidId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("InvoiceTypeId");

                    b.HasIndex("ManagerId");

                    b.HasIndex("RoomId");

                    b.HasIndex("TenantPaidId");

                    b.ToTable("Invoice");
                });

            modelBuilder.Entity("Domain.Entities.Invoice.InvoiceType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CategoryName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("InvoiceTypes");
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

                    b.Property<string>("InvoiceCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("InvoiceTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<Guid>("ManagerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<Guid>("RoomId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("InvoiceTypeId");

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

            modelBuilder.Entity("Domain.Entities.Notification.Notification_Room", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<Guid>("ManagerId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnOrder(1);

                    b.Property<Guid>("NotificationId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnOrder(3);

                    b.Property<Guid>("RoomId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnOrder(2);

                    b.HasKey("Id");

                    b.HasIndex("ManagerId");

                    b.HasIndex("NotificationId");

                    b.HasIndex("RoomId");

                    b.ToTable("RoomNotification");
                });

            modelBuilder.Entity("Domain.Entities.Notification.NotificationCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CategoryName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("NotificationCategory");
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

                    b.Property<Guid>("NotificationCategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("NotificationCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("NotificationCategoryId");

                    b.ToTable("Notification");
                });

            modelBuilder.Entity("Domain.Entities.Room.RoomEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Area")
                        .HasColumnType("float");

                    b.Property<int>("Height")
                        .HasColumnType("int");

                    b.Property<Guid>("HostelId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<double>("Length")
                        .HasColumnType("float");

                    b.Property<int>("NumOfBathRooms")
                        .HasColumnType("int");

                    b.Property<int>("NumOfDoors")
                        .HasColumnType("int");

                    b.Property<int>("NumOfWCs")
                        .HasColumnType("int");

                    b.Property<int>("NumOfWindows")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("RoomName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoomTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Width")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("HostelId");

                    b.HasIndex("RoomTypeId");

                    b.ToTable("Room");
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

                    b.Property<Guid>("TicketTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoomId");

                    b.HasIndex("TenantId");

                    b.HasIndex("TicketTypeId");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("Domain.Entities.Ticket.TicketType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CategoryName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("TicketTypes");
                });

            modelBuilder.Entity("Domain.Entities.UserEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Avatar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
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

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleString")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Role");

                    b.Property<Guid?>("RoomId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TaxCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RoomId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Domain.Entities.Commitment.CommitmentContains", b =>
                {
                    b.HasOne("Domain.Entities.Commitment.CommitmentEntity", "Commitment")
                        .WithMany("CommitmentContains")
                        .HasForeignKey("CommitmentId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Domain.Entities.UserEntity", "Tenant")
                        .WithMany("CommitmentContains")
                        .HasForeignKey("TenantId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Commitment");

                    b.Navigation("Tenant");
                });

            modelBuilder.Entity("Domain.Entities.Commitment.CommitmentEntity", b =>
                {
                    b.HasOne("Domain.Entities.UserEntity", "Manager")
                        .WithOne("Commitment")
                        .HasForeignKey("Domain.Entities.Commitment.CommitmentEntity", "ManagerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Room.RoomEntity", "Room")
                        .WithOne("Commitment")
                        .HasForeignKey("Domain.Entities.Commitment.CommitmentEntity", "RoomId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Manager");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("Domain.Entities.Facility.FacilityEntity", b =>
                {
                    b.HasOne("Domain.Entities.Facility.FacilityCategory", "FacilityCategory")
                        .WithMany("Facilities")
                        .HasForeignKey("FacilityCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Room.RoomEntity", "Room")
                        .WithMany("Facilities")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FacilityCategory");

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
                    b.HasOne("Domain.Entities.HostelCategory", "HostelCategory")
                        .WithMany("Hostels")
                        .HasForeignKey("HostelCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.UserEntity", "Owner")
                        .WithMany("Hostels")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HostelCategory");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("Domain.Entities.Invoice.InvoiceEntity", b =>
                {
                    b.HasOne("Domain.Entities.Invoice.InvoiceType", "InvoiceType")
                        .WithMany("Invoices")
                        .HasForeignKey("InvoiceTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

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
                        .HasForeignKey("TenantPaidId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("InvoiceType");

                    b.Navigation("Manager");

                    b.Navigation("Room");

                    b.Navigation("TenantPaid");
                });

            modelBuilder.Entity("Domain.Entities.InvoiceSchedule.InvoiceScheduleEntity", b =>
                {
                    b.HasOne("Domain.Entities.Invoice.InvoiceType", "InvoiceType")
                        .WithMany("InvoiceSchedules")
                        .HasForeignKey("InvoiceTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

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

                    b.Navigation("InvoiceType");

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

            modelBuilder.Entity("Domain.Entities.Notification.Notification_Room", b =>
                {
                    b.HasOne("Domain.Entities.UserEntity", "Manager")
                        .WithMany("ManagerCreatedRoomNotifications")
                        .HasForeignKey("ManagerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Notification.NotificationEntity", "Notification")
                        .WithMany("RoomNotifications")
                        .HasForeignKey("NotificationId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Room.RoomEntity", "Room")
                        .WithMany("RoomNotifications")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Manager");

                    b.Navigation("Notification");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("Domain.Entities.Notification.NotificationEntity", b =>
                {
                    b.HasOne("Domain.Entities.Notification.NotificationCategory", "NotificationCategory")
                        .WithMany("Notifications")
                        .HasForeignKey("NotificationCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("NotificationCategory");
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
                        .OnDelete(DeleteBehavior.Cascade)
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

                    b.HasOne("Domain.Entities.Ticket.TicketType", "TicketType")
                        .WithMany("Tickets")
                        .HasForeignKey("TicketTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Room");

                    b.Navigation("Tenant");

                    b.Navigation("TicketType");
                });

            modelBuilder.Entity("Domain.Entities.UserEntity", b =>
                {
                    b.HasOne("Domain.Entities.Room.RoomEntity", "Room")
                        .WithMany("Tenants")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Room");
                });

            modelBuilder.Entity("Domain.Entities.Commitment.CommitmentEntity", b =>
                {
                    b.Navigation("CommitmentContains");
                });

            modelBuilder.Entity("Domain.Entities.Facility.FacilityCategory", b =>
                {
                    b.Navigation("Facilities");
                });

            modelBuilder.Entity("Domain.Entities.HostelCategory", b =>
                {
                    b.Navigation("Hostels");
                });

            modelBuilder.Entity("Domain.Entities.HostelEntity", b =>
                {
                    b.Navigation("HostelManagements");

                    b.Navigation("Rooms");
                });

            modelBuilder.Entity("Domain.Entities.Invoice.InvoiceType", b =>
                {
                    b.Navigation("InvoiceSchedules");

                    b.Navigation("Invoices");
                });

            modelBuilder.Entity("Domain.Entities.Notification.NotificationCategory", b =>
                {
                    b.Navigation("Notifications");
                });

            modelBuilder.Entity("Domain.Entities.Notification.NotificationEntity", b =>
                {
                    b.Navigation("RoomNotifications");
                });

            modelBuilder.Entity("Domain.Entities.Room.RoomEntity", b =>
                {
                    b.Navigation("Commitment");

                    b.Navigation("Facilities");

                    b.Navigation("ManagerCreatedInvoices");

                    b.Navigation("ManegerCreatedInvoiceSchedules");

                    b.Navigation("RoomNotifications");

                    b.Navigation("Tenants");

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

            modelBuilder.Entity("Domain.Entities.Ticket.TicketType", b =>
                {
                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("Domain.Entities.UserEntity", b =>
                {
                    b.Navigation("Commitment");

                    b.Navigation("CommitmentContains");

                    b.Navigation("HostelManagements");

                    b.Navigation("Hostels");

                    b.Navigation("ManagerCreatedInvoices");

                    b.Navigation("ManagerCreatedRoomNotifications");

                    b.Navigation("ManegerCreatedInvoiceSchedules");

                    b.Navigation("Messages");

                    b.Navigation("TenantPaidInvoices");

                    b.Navigation("Tickets");
                });
#pragma warning restore 612, 618
        }
    }
}
