﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NotificationServices.Infrastructure;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace NotificationServices.Infrastructure.Migrations
{
    [DbContext(typeof(NotificationDbContext))]
    [Migration("20220916192037_NotifyDB")]
    partial class NotifyDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("NotificationServices.Domain.Models.Notification", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("NotificationType")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UserNotificationId")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserNotificationId");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("NotificationServices.Domain.Models.UserNotification", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text");

                    b.Property<string>("NotificationId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("UserNotifications");
                });

            modelBuilder.Entity("NotificationServices.Domain.Models.Notification", b =>
                {
                    b.HasOne("NotificationServices.Domain.Models.UserNotification", "UserNotification")
                        .WithMany("Notifications")
                        .HasForeignKey("UserNotificationId");

                    b.Navigation("UserNotification");
                });

            modelBuilder.Entity("NotificationServices.Domain.Models.UserNotification", b =>
                {
                    b.Navigation("Notifications");
                });
#pragma warning restore 612, 618
        }
    }
}
