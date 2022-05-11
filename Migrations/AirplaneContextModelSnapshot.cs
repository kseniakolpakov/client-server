﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace application.Migrations
{
    [DbContext(typeof(AirplaneContext))]
    partial class AirplaneContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Airplane", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasColumnOrder(1);

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("NumberOfBussinessClassSeats")
                        .HasColumnType("integer")
                        .HasColumnName("number_of_bussiness_class_seats");

                    b.Property<int>("NumberOfEconomyClassSeats")
                        .HasColumnType("integer")
                        .HasColumnName("number_of_economy_class_seats");

                    b.HasKey("Id")
                        .HasName("pk_airplanes");

                    b.ToTable("airplanes", (string)null);
                });

            modelBuilder.Entity("CityOfArrival", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasColumnOrder(1);

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("CountryName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("country_name");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_cities_of_arrival");

                    b.ToTable("cities_of_arrival", (string)null);
                });

            modelBuilder.Entity("CityOfDeparture", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasColumnOrder(1);

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("CountryName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("country_name");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_cities_of_departure");

                    b.ToTable("cities_of_departure", (string)null);
                });

            modelBuilder.Entity("Flight", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasColumnOrder(1);

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AirplaneId")
                        .HasColumnType("integer")
                        .HasColumnName("airplane_id");

                    b.Property<int>("CityOfArrivalId")
                        .HasColumnType("integer")
                        .HasColumnName("city_of_arrival_id");

                    b.Property<int>("CityOfDepartureId")
                        .HasColumnType("integer")
                        .HasColumnName("city_of_departure_id");

                    b.Property<string>("Duration")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("duration");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("number");

                    b.Property<string>("TimeOfArrival")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("time_of_arrival");

                    b.Property<string>("TimeOfDeparture")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("time_of_departure");

                    b.HasKey("Id")
                        .HasName("pk_flights");

                    b.HasIndex("AirplaneId")
                        .HasDatabaseName("ix_flights_airplane_id");

                    b.HasIndex("CityOfArrivalId")
                        .HasDatabaseName("ix_flights_city_of_arrival_id");

                    b.HasIndex("CityOfDepartureId")
                        .HasDatabaseName("ix_flights_city_of_departure_id");

                    b.ToTable("flights", (string)null);
                });

            modelBuilder.Entity("Passenger", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasColumnOrder(1);

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("DateOfBirth")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("date_of_birth");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("first_name");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("last_name");

                    b.Property<string>("PassportNumber")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("passport_number");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("phone_number");

                    b.HasKey("Id")
                        .HasName("pk_passengers");

                    b.ToTable("passengers", (string)null);
                });

            modelBuilder.Entity("Ticket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasColumnOrder(1);

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("DateOfFlight")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("date_of_flight");

                    b.Property<int>("FlightId")
                        .HasColumnType("integer")
                        .HasColumnName("flight_id");

                    b.Property<int>("PassengerId")
                        .HasColumnType("integer")
                        .HasColumnName("passenger_id");

                    b.Property<float>("Price")
                        .HasColumnType("real")
                        .HasColumnName("price");

                    b.Property<string>("Seat")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("seat");

                    b.HasKey("Id")
                        .HasName("pk_tickets");

                    b.HasIndex("FlightId")
                        .HasDatabaseName("ix_tickets_flight_id");

                    b.HasIndex("PassengerId")
                        .HasDatabaseName("ix_tickets_passenger_id");

                    b.ToTable("tickets", (string)null);
                });

            modelBuilder.Entity("Flight", b =>
                {
                    b.HasOne("Airplane", "Airplane")
                        .WithMany("Flights")
                        .HasForeignKey("AirplaneId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_flights_airplanes_airplane_id");

                    b.HasOne("CityOfArrival", "CityOfArrival")
                        .WithMany("Flights")
                        .HasForeignKey("CityOfArrivalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_flights_cities_of_arrival_city_of_arrival_id");

                    b.HasOne("CityOfDeparture", "CityOfDeparture")
                        .WithMany("Flights")
                        .HasForeignKey("CityOfDepartureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_flights_cities_of_departure_city_of_departure_id");

                    b.Navigation("Airplane");

                    b.Navigation("CityOfArrival");

                    b.Navigation("CityOfDeparture");
                });

            modelBuilder.Entity("Ticket", b =>
                {
                    b.HasOne("Flight", "Flight")
                        .WithMany("Tickets")
                        .HasForeignKey("FlightId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_tickets_flights_flight_id");

                    b.HasOne("Passenger", "Passenger")
                        .WithMany("Tickets")
                        .HasForeignKey("PassengerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_tickets_passengers_passenger_id");

                    b.Navigation("Flight");

                    b.Navigation("Passenger");
                });

            modelBuilder.Entity("Airplane", b =>
                {
                    b.Navigation("Flights");
                });

            modelBuilder.Entity("CityOfArrival", b =>
                {
                    b.Navigation("Flights");
                });

            modelBuilder.Entity("CityOfDeparture", b =>
                {
                    b.Navigation("Flights");
                });

            modelBuilder.Entity("Flight", b =>
                {
                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("Passenger", b =>
                {
                    b.Navigation("Tickets");
                });
#pragma warning restore 612, 618
        }
    }
}
