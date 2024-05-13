using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ReHub.DbDataModel.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "lesson_packages",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    lessons_num = table.Column<int>(type: "integer", nullable: false),
                    cost = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lesson_packages", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "referrer_doctors",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    referral_code = table.Column<string>(type: "text", nullable: false),
                    comment = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_referrer_doctors", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Email = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: false),
                    Name = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false),
                    Surname = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false),
                    Gender = table.Column<int>(type: "integer", nullable: false),
                    AvatarUrl = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    Password = table.Column<string>(type: "text", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false),
                    IsVerified = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "admins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_admins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_admins_users_Id",
                        column: x => x.Id,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "doctors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    SubType = table.Column<int>(type: "integer", nullable: false),
                    About = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_doctors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_doctors_users_Id",
                        column: x => x.Id,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "notifications",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    message = table.Column<string>(type: "text", nullable: false),
                    sender_id = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_notifications", x => x.id);
                    table.ForeignKey(
                        name: "FK_notifications_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_notifications_users_sender_id",
                        column: x => x.sender_id,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    SubType = table.Column<int>(type: "integer", nullable: false),
                    Balance = table.Column<int>(type: "integer", nullable: false),
                    DoctorId = table.Column<int>(type: "integer", nullable: true),
                    ReferrerId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_clients_doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "doctors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_clients_referrer_doctors_ReferrerId",
                        column: x => x.ReferrerId,
                        principalTable: "referrer_doctors",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_clients_users_Id",
                        column: x => x.Id,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "conference",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    channel_name = table.Column<string>(type: "text", nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    channel_admin_id = table.Column<int>(type: "integer", nullable: true),
                    DoctorId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_conference", x => x.id);
                    table.ForeignKey(
                        name: "FK_conference_doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "doctors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_conference_users_channel_admin_id",
                        column: x => x.channel_admin_id,
                        principalTable: "users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "notification_recipients",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    notification_id = table.Column<int>(type: "integer", nullable: false),
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    user_seen = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_notification_recipients", x => x.id);
                    table.ForeignKey(
                        name: "FK_notification_recipients_notifications_notification_id",
                        column: x => x.notification_id,
                        principalTable: "notifications",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_notification_recipients_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "appointments",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    date = table.Column<DateOnly>(type: "date", nullable: false),
                    time = table.Column<TimeSpan>(type: "interval", nullable: false),
                    status = table.Column<string>(type: "text", nullable: false),
                    max_listeners = table.Column<int>(type: "integer", nullable: false),
                    speaker_id = table.Column<int>(type: "integer", nullable: true),
                    ClientId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_appointments", x => x.id);
                    table.ForeignKey(
                        name: "FK_appointments_clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "clients",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_appointments_doctors_speaker_id",
                        column: x => x.speaker_id,
                        principalTable: "doctors",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "client_details",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ClientId = table.Column<int>(type: "integer", nullable: false),
                    Birthday = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Pathology = table.Column<int>(type: "integer", nullable: true),
                    Nationality = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    Address = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    City = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    Province = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    Country = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    PostalCode = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    BirthCity = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    BirthCountry = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    PhoneNumber = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    FiscalCode = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_client_details", x => x.Id);
                    table.ForeignKey(
                        name: "FK_client_details_clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "discount_coupons",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    coupon_type = table.Column<int>(type: "integer", nullable: false),
                    discount_type = table.Column<int>(type: "integer", nullable: false),
                    discount = table.Column<double>(type: "double precision", nullable: false),
                    validity_until = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ClientId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_discount_coupons", x => x.id);
                    table.ForeignKey(
                        name: "FK_discount_coupons_clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "clients",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "conference_history",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    action = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    conference_id = table.Column<int>(type: "integer", nullable: true),
                    actor_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_conference_history", x => x.id);
                    table.ForeignKey(
                        name: "FK_conference_history_conference_conference_id",
                        column: x => x.conference_id,
                        principalTable: "conference",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_conference_history_users_actor_id",
                        column: x => x.actor_id,
                        principalTable: "users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "appointment_clients",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    client_id = table.Column<int>(type: "integer", nullable: true),
                    appointment_id = table.Column<int>(type: "integer", nullable: true),
                    pain_rate_before = table.Column<int>(type: "integer", nullable: true),
                    pain_rate_after = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_appointment_clients", x => x.id);
                    table.ForeignKey(
                        name: "FK_appointment_clients_appointments_appointment_id",
                        column: x => x.appointment_id,
                        principalTable: "appointments",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_appointment_clients_clients_client_id",
                        column: x => x.client_id,
                        principalTable: "clients",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "coupon_users",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    coupon_id = table.Column<int>(type: "integer", nullable: false),
                    client_id = table.Column<int>(type: "integer", nullable: false),
                    use_count = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_coupon_users", x => x.id);
                    table.ForeignKey(
                        name: "FK_coupon_users_clients_client_id",
                        column: x => x.client_id,
                        principalTable: "clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_coupon_users_discount_coupons_coupon_id",
                        column: x => x.coupon_id,
                        principalTable: "discount_coupons",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "payments",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    amount = table.Column<double>(type: "double precision", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    lesson_package_id = table.Column<int>(type: "integer", nullable: false),
                    coupon_id = table.Column<int>(type: "integer", nullable: true),
                    client_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_payments", x => x.id);
                    table.ForeignKey(
                        name: "FK_payments_clients_client_id",
                        column: x => x.client_id,
                        principalTable: "clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_payments_discount_coupons_coupon_id",
                        column: x => x.coupon_id,
                        principalTable: "discount_coupons",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_payments_lesson_packages_lesson_package_id",
                        column: x => x.lesson_package_id,
                        principalTable: "lesson_packages",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "discount_coupons",
                columns: new[] { "id", "ClientId", "coupon_type", "created_at", "discount", "discount_type", "name", "updated_at", "validity_until" },
                values: new object[,]
                {
                    { 1, null, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5.0, 0, "SALE", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 12, 13, 54, 31, 878, DateTimeKind.Utc).AddTicks(2040) },
                    { 2, null, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1.0, 1, "FIX", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 12, 13, 54, 31, 878, DateTimeKind.Utc).AddTicks(2047) }
                });

            migrationBuilder.InsertData(
                table: "lesson_packages",
                columns: new[] { "id", "cost", "lessons_num", "name" },
                values: new object[,]
                {
                    { 1, 9.9000000000000004, 1, "PACKAGE NAME N.001" },
                    { 2, 44.899999999999999, 5, "PACKAGE NAME N.002" },
                    { 3, 79.900000000000006, 10, "PACKAGE NAME N.003" }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "AvatarUrl", "CreatedAt", "Deleted", "Email", "Gender", "IsVerified", "Name", "Password", "Surname", "Type", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "test", new DateTime(2024, 5, 13, 13, 54, 31, 878, DateTimeKind.Utc).AddTicks(1693), false, "9iYms6TCxuISbWFyaW96NjNAZ21haWwuY29t", 0, true, "Mario", "9iYms6TCxuIJMTIzNDU2Nzg5", "Z.", 0, new DateTime(2024, 5, 13, 13, 54, 31, 878, DateTimeKind.Utc).AddTicks(1694) },
                    { 2, "https://static.wikia.nocookie.net/rickandmorty/images/3/3f/Young_Adult_Rick.png", new DateTime(2024, 5, 13, 13, 54, 31, 878, DateTimeKind.Utc).AddTicks(1949), false, "9iYms6TCxuITZG9jdG9yMUBleGFtcGxlLmNvbQ==", 0, true, "Rick", "9iYms6TCxuIJMTIzNDU2Nzg5", "Sanchez", 1, new DateTime(2024, 5, 13, 13, 54, 31, 878, DateTimeKind.Utc).AddTicks(1949) },
                    { 3, "https://static.wikia.nocookie.net/marveldatabase/images/0/02/Adam_Warlock_%28Earth-829%29_from_Hercules_Vol_2_3_0001.jpg", new DateTime(2024, 5, 13, 13, 54, 31, 878, DateTimeKind.Utc).AddTicks(1953), false, "9iYms6TCxuITZG9jdG9yMkBleGFtcGxlLmNvbQ==", 0, false, "Adam", "9iYms6TCxuIJMTIzNDU2Nzg5", "Warlock", 1, new DateTime(2024, 5, 13, 13, 54, 31, 878, DateTimeKind.Utc).AddTicks(1953) },
                    { 4, null, new DateTime(2024, 5, 13, 13, 54, 31, 878, DateTimeKind.Utc).AddTicks(1979), false, "9iYms6TCxuIRdGVzdDFAZXhhbXBsZS5jb20=", 3, false, "Test01", "9iYms6TCxuIJMTIzNDU2Nzg5", "Test01", 0, new DateTime(2024, 5, 13, 13, 54, 31, 878, DateTimeKind.Utc).AddTicks(1980) },
                    { 5, null, new DateTime(2024, 5, 13, 13, 54, 31, 878, DateTimeKind.Utc).AddTicks(1982), false, "9iYms6TCxuIRdGVzdDJAZXhhbXBsZS5jb20=", 3, false, "Test02", "9iYms6TCxuIJMTIzNDU2Nzg5", "Test02", 0, new DateTime(2024, 5, 13, 13, 54, 31, 878, DateTimeKind.Utc).AddTicks(1982) }
                });

            migrationBuilder.InsertData(
                table: "admins",
                column: "Id",
                value: 1);

            migrationBuilder.InsertData(
                table: "clients",
                columns: new[] { "Id", "Balance", "DoctorId", "ReferrerId", "SubType" },
                values: new object[,]
                {
                    { 4, 0, null, null, 0 },
                    { 5, 0, null, null, 0 }
                });

            migrationBuilder.InsertData(
                table: "doctors",
                columns: new[] { "Id", "About", "SubType" },
                values: new object[,]
                {
                    { 2, "Text about doctor #3", 1 },
                    { 3, "Text about doctor #4", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_admins_Id",
                table: "admins",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_appointment_clients_appointment_id",
                table: "appointment_clients",
                column: "appointment_id");

            migrationBuilder.CreateIndex(
                name: "IX_appointment_clients_client_id",
                table: "appointment_clients",
                column: "client_id");

            migrationBuilder.CreateIndex(
                name: "IX_appointments_ClientId",
                table: "appointments",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_appointments_speaker_id",
                table: "appointments",
                column: "speaker_id");

            migrationBuilder.CreateIndex(
                name: "IX_client_details_ClientId",
                table: "client_details",
                column: "ClientId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_clients_DoctorId",
                table: "clients",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_clients_Id",
                table: "clients",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_clients_ReferrerId",
                table: "clients",
                column: "ReferrerId");

            migrationBuilder.CreateIndex(
                name: "IX_conference_channel_admin_id",
                table: "conference",
                column: "channel_admin_id");

            migrationBuilder.CreateIndex(
                name: "IX_conference_DoctorId",
                table: "conference",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_conference_id",
                table: "conference",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_conference_history_actor_id",
                table: "conference_history",
                column: "actor_id");

            migrationBuilder.CreateIndex(
                name: "IX_conference_history_conference_id",
                table: "conference_history",
                column: "conference_id");

            migrationBuilder.CreateIndex(
                name: "IX_conference_history_id",
                table: "conference_history",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_coupon_users_client_id",
                table: "coupon_users",
                column: "client_id");

            migrationBuilder.CreateIndex(
                name: "IX_coupon_users_coupon_id",
                table: "coupon_users",
                column: "coupon_id");

            migrationBuilder.CreateIndex(
                name: "IX_discount_coupons_ClientId",
                table: "discount_coupons",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_discount_coupons_name",
                table: "discount_coupons",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_doctors_Id",
                table: "doctors",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_notification_recipients_notification_id",
                table: "notification_recipients",
                column: "notification_id");

            migrationBuilder.CreateIndex(
                name: "IX_notification_recipients_user_id",
                table: "notification_recipients",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_notifications_sender_id",
                table: "notifications",
                column: "sender_id");

            migrationBuilder.CreateIndex(
                name: "IX_notifications_UserId",
                table: "notifications",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_payments_client_id",
                table: "payments",
                column: "client_id");

            migrationBuilder.CreateIndex(
                name: "IX_payments_coupon_id",
                table: "payments",
                column: "coupon_id");

            migrationBuilder.CreateIndex(
                name: "IX_payments_lesson_package_id",
                table: "payments",
                column: "lesson_package_id");

            migrationBuilder.CreateIndex(
                name: "IX_referrer_doctors_name",
                table: "referrer_doctors",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_referrer_doctors_referral_code",
                table: "referrer_doctors",
                column: "referral_code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_users_Email",
                table: "users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_users_Id",
                table: "users",
                column: "Id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "admins");

            migrationBuilder.DropTable(
                name: "appointment_clients");

            migrationBuilder.DropTable(
                name: "client_details");

            migrationBuilder.DropTable(
                name: "conference_history");

            migrationBuilder.DropTable(
                name: "coupon_users");

            migrationBuilder.DropTable(
                name: "notification_recipients");

            migrationBuilder.DropTable(
                name: "payments");

            migrationBuilder.DropTable(
                name: "appointments");

            migrationBuilder.DropTable(
                name: "conference");

            migrationBuilder.DropTable(
                name: "notifications");

            migrationBuilder.DropTable(
                name: "discount_coupons");

            migrationBuilder.DropTable(
                name: "lesson_packages");

            migrationBuilder.DropTable(
                name: "clients");

            migrationBuilder.DropTable(
                name: "doctors");

            migrationBuilder.DropTable(
                name: "referrer_doctors");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
