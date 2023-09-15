﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WalletEcom.DB;

#nullable disable

namespace WalletEcom.DB.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230915032733_AddAccountTypeIdToAccount")]
    partial class AddAccountTypeIdToAccount
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.22")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("WalletEcom.Models.Account.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AccountTypeId")
                        .HasColumnType("int")
                        .HasColumnName("account_type_id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("created_at");

                    b.Property<DateTime>("DOB")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("dob");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("email");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("full_name");

                    b.Property<bool>("Status")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("status");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("user_name");

                    b.HasKey("Id");

                    b.HasIndex("AccountTypeId");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("UserName")
                        .IsUnique();

                    b.ToTable("tbl_account", (string)null);
                });

            modelBuilder.Entity("WalletEcom.Models.Account.AccountType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("account_type_name");

                    b.HasKey("Id");

                    b.ToTable("tbl_account_type", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "normal"
                        },
                        new
                        {
                            Id = 2,
                            Name = "premium"
                        },
                        new
                        {
                            Id = 3,
                            Name = "vip"
                        });
                });

            modelBuilder.Entity("WalletEcom.Models.Action.ActionFee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<decimal>("Fee")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("fee");

                    b.Property<int>("action_fee_account_type")
                        .HasColumnType("int");

                    b.Property<int>("action_fee_action_type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("action_fee_account_type");

                    b.HasIndex("action_fee_action_type");

                    b.ToTable("tbl_action_fee", (string)null);
                });

            modelBuilder.Entity("WalletEcom.Models.Action.ActionType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("action_name");

                    b.HasKey("Id");

                    b.ToTable("tbl_action", (string)null);
                });

            modelBuilder.Entity("WalletEcom.Models.Wallet.Wallet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("wallet_amount");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("wallet_updated_at");

                    b.Property<int>("account_id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("account_id");

                    b.ToTable("tbl_wallet", (string)null);
                });

            modelBuilder.Entity("WalletEcom.Models.Wallet.WalletHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("wallet_amount");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("wallet_createdat");

                    b.Property<int?>("DestinationWalletId")
                        .HasColumnType("int")
                        .HasColumnName("destination_wallet_id");

                    b.Property<decimal>("Fee")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("wallet_fee");

                    b.Property<int?>("SourceWalletId")
                        .HasColumnType("int")
                        .HasColumnName("source_wallet_id");

                    b.Property<int>("wallet_account_type")
                        .HasColumnType("int");

                    b.Property<int>("wallet_action_type")
                        .HasColumnType("int");

                    b.Property<int>("wallet_id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("wallet_account_type");

                    b.HasIndex("wallet_action_type");

                    b.HasIndex("wallet_id");

                    b.ToTable("tbl_wallet_history", (string)null);
                });

            modelBuilder.Entity("WalletEcom.Models.Account.Account", b =>
                {
                    b.HasOne("WalletEcom.Models.Account.AccountType", "AccountType")
                        .WithMany()
                        .HasForeignKey("AccountTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AccountType");
                });

            modelBuilder.Entity("WalletEcom.Models.Action.ActionFee", b =>
                {
                    b.HasOne("WalletEcom.Models.Account.AccountType", "AccountType")
                        .WithMany()
                        .HasForeignKey("action_fee_account_type")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WalletEcom.Models.Action.ActionType", "ActionType")
                        .WithMany()
                        .HasForeignKey("action_fee_action_type")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AccountType");

                    b.Navigation("ActionType");
                });

            modelBuilder.Entity("WalletEcom.Models.Wallet.Wallet", b =>
                {
                    b.HasOne("WalletEcom.Models.Account.Account", "Account")
                        .WithMany()
                        .HasForeignKey("account_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("WalletEcom.Models.Wallet.WalletHistory", b =>
                {
                    b.HasOne("WalletEcom.Models.Account.AccountType", "AccountType")
                        .WithMany()
                        .HasForeignKey("wallet_account_type")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WalletEcom.Models.Action.ActionType", "ActionType")
                        .WithMany()
                        .HasForeignKey("wallet_action_type")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WalletEcom.Models.Wallet.Wallet", "Wallet")
                        .WithMany()
                        .HasForeignKey("wallet_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AccountType");

                    b.Navigation("ActionType");

                    b.Navigation("Wallet");
                });
#pragma warning restore 612, 618
        }
    }
}
