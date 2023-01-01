using FlamingoServices.Data.Models;
using FlamingoServices.Models;
using Microsoft.EntityFrameworkCore;

namespace FlamingoServices.Data
{

    public partial class FlamingoDbContext : DbContext
    {
        public FlamingoDbContext()
        {
        }

        public FlamingoDbContext(DbContextOptions<FlamingoDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Airport> Airports { get; set; }

        public virtual DbSet<Booking> Bookings { get; set; }

        public virtual DbSet<FlightDetail> FlightDetails { get; set; }

        public virtual DbSet<Passenger> Passengers { get; set; }

        public virtual DbSet<Payment> Payments { get; set; }

        public virtual DbSet<ScheduleFlight> ScheduleFlights { get; set; }

        public virtual DbSet<Ticket> Tickets { get; set; }

        public virtual DbSet<TicketAvailability> TicketAvailabilities { get; set; }

        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Airport>(entity =>
            {
                entity.HasKey(e => e.AirportId).HasName("PK__Airports__E3DBE08A36B6914A");

                entity.HasIndex(e => e.AirportName, "UQ__Airports__4E7279462FED56E4").IsUnique();

                entity.Property(e => e.AirportId).HasColumnName("AirportID");
                entity.Property(e => e.AirportName).HasMaxLength(50);
                entity.Property(e => e.Terminal).HasMaxLength(10);
            });

            modelBuilder.Entity<Booking>(entity =>
            {
                entity.HasKey(e => e.BookingId).HasName("PK__Booking__73951ACD9E1B0C52");

                entity.ToTable("Booking");

                entity.Property(e => e.BookingId).HasColumnName("BookingID");
                entity.Property(e => e.Userid).HasMaxLength(20);

                entity.HasOne(d => d.User).WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.Userid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Booking__Userid__38996AB5");
            });

            modelBuilder.Entity<FlightDetail>(entity =>
            {
                entity.HasKey(e => e.FlightId).HasName("PK__Flight_d__8A9E148E52EE3B3E");

                entity.ToTable("Flight_details");

                entity.Property(e => e.FlightId)
                    .HasMaxLength(10)
                    .HasColumnName("FlightID");
                entity.Property(e => e.Aeroplanename).HasMaxLength(20);
            });

            modelBuilder.Entity<Passenger>(entity =>
            {
                entity.Property(e => e.PassengerId).HasColumnName("PassengerID");
                entity.Property(e => e.BookingId).HasColumnName("BookingID");
                entity.Property(e => e.DateOfBirth).HasColumnType("date");
                entity.Property(e => e.Gender)
                    .HasMaxLength(10)
                    .IsUnicode(false);
                entity.Property(e => e.Nationality)
                    .HasMaxLength(15)
                    .IsUnicode(false);
                entity.Property(e => e.PassengerName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.Booking).WithMany(p => p.Passengers)
                    .HasForeignKey(d => d.BookingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Passenger__Booki__398D8EEE");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.HasKey(e => e.PaymentId).HasName("PK__Payments__9B556A584D20E258");

                entity.Property(e => e.PaymentId).HasColumnName("PaymentID");
                entity.Property(e => e.BookingId).HasColumnName("BookingID");
                entity.Property(e => e.CardName).HasMaxLength(50);
                entity.Property(e => e.CardNumber).HasMaxLength(50);
                entity.Property(e => e.Price).HasColumnType("money");
                entity.Property(e => e.TotalAmount).HasColumnType("money");

                entity.HasOne(d => d.Booking).WithMany(p => p.Payments)
                    .HasForeignKey(d => d.BookingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Payments__Bookin__3A81B327");
            });

            modelBuilder.Entity<ScheduleFlight>(entity =>
            {
                entity.HasKey(e => e.FlightSchId).HasName("PK__Schedule__E6B946A19C2AFCA0");

                entity.ToTable("ScheduleFlight");

                entity.Property(e => e.FlightSchId).HasColumnName("FlightSchID");
                entity.Property(e => e.DepartureDay).HasMaxLength(20);
                entity.Property(e => e.Destination).HasMaxLength(30);
                entity.Property(e => e.FlightId)
                    .HasMaxLength(10)
                    .HasColumnName("FlightID");
                entity.Property(e => e.OrginAirportId).HasColumnName("Orgin_AirportID");
                entity.Property(e => e.Origin).HasMaxLength(30);
                entity.Property(e => e.Price).HasColumnType("money");

                entity.HasOne(d => d.Flight).WithMany(p => p.ScheduleFlights)
                    .HasForeignKey(d => d.FlightId)
                    .HasConstraintName("FK__ScheduleF__Fligh__3B75D760");

                entity.HasOne(d => d.OrginAirport).WithMany(p => p.ScheduleFlights)
                    .HasForeignKey(d => d.OrginAirportId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ScheduleF__Orgin__3C69FB99");
            });

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.HasKey(e => e.Pnrnumber).HasName("PK__Ticket__A03A5D40E0F53C3E");

                entity.ToTable("Ticket");

                entity.Property(e => e.Pnrnumber)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("PNRNumber");
                entity.Property(e => e.ArrivalDate).HasColumnType("date");
                entity.Property(e => e.BookingId).HasColumnName("BookingID");
                entity.Property(e => e.DepartureDate).HasColumnType("date");
                entity.Property(e => e.Destination)
                    .HasMaxLength(30)
                    .IsUnicode(false);
                entity.Property(e => e.FlightId)
                    .HasMaxLength(10)
                    .HasColumnName("FlightID");
                entity.Property(e => e.Gender)
                    .HasMaxLength(10)
                    .IsUnicode(false);
                entity.Property(e => e.Origin)
                    .HasMaxLength(30)
                    .IsUnicode(false);
                entity.Property(e => e.PassengerId).HasColumnName("PassengerID");
                entity.Property(e => e.PassengerName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.Booking).WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.BookingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Ticket__BookingI__3D5E1FD2");

                entity.HasOne(d => d.Flight).WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.FlightId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Ticket__FlightID__3E52440B");

                entity.HasOne(d => d.Passenger).WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.PassengerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Ticket__Passenge__3F466844");
            });

            modelBuilder.Entity<TicketAvailability>(entity =>
            {
                entity.HasKey(e => e.Slno);

                entity.ToTable("TicketAvailability");

                entity.Property(e => e.DepartureDate).HasColumnType("date");
                entity.Property(e => e.FlightId)
                    .HasMaxLength(10)
                    .HasColumnName("FlightID");

                entity.HasOne(d => d.Flight).WithMany(p => p.TicketAvailabilities)
                    .HasForeignKey(d => d.FlightId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TicketAva__Fligh__403A8C7D");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.Userid).HasMaxLength(20);
                entity.Property(e => e.DoB).HasColumnType("date");
                entity.Property(e => e.Email).HasMaxLength(20);
                entity.Property(e => e.Fname).HasMaxLength(30);
                entity.Property(e => e.Lname).HasMaxLength(30);
                entity.Property(e => e.Password).HasMaxLength(50);
                entity.Property(e => e.Role).HasMaxLength(30);
                entity.Property(e => e.Token).HasMaxLength(30);
                entity.Property(e => e.Phone).HasColumnType("numeric(18, 0)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
