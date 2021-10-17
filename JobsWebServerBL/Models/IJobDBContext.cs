﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace JobsWebServerBL.Models
{
    public partial class IJobDBContext : DbContext
    {
        public IJobDBContext()
        {
        }

        public IJobDBContext(DbContextOptions<IJobDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<ChatBox> ChatBoxes { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Employer> Employers { get; set; }
        public virtual DbSet<InterstedInRequest> InterstedInRequests { get; set; }
        public virtual DbSet<JobApplication> JobApplications { get; set; }
        public virtual DbSet<JobApplicationStatus> JobApplicationStatuses { get; set; }
        public virtual DbSet<JobOffer> JobOffers { get; set; }
        public virtual DbSet<JobOfferStatus> JobOfferStatuses { get; set; }
        public virtual DbSet<JobRequest> JobRequests { get; set; }
        public virtual DbSet<Rating> Ratings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=IJobDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Hebrew_CI_AS");

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasIndex(e => e.CategoryName, "CategoryNameIndex")
                    .IsUnique();

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            });

            modelBuilder.Entity<ChatBox>(entity =>
            {
                entity.HasKey(e => e.PhraseId)
                    .HasName("PK__ChatBox__0DBA0EA2ABBEA830");

                entity.ToTable("ChatBox");

                entity.Property(e => e.PhraseId).HasColumnName("PhraseID");

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.ToTable("Comment");

                entity.HasIndex(e => e.JobOfferId, "JobOfferIDIndex")
                    .IsUnique();

                entity.Property(e => e.CommentId).HasColumnName("CommentID");

                entity.Property(e => e.JobOfferId).HasColumnName("JobOfferID");

                entity.Property(e => e.JobRequestId).HasColumnName("JobRequestID");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.HasIndex(e => e.Email, "EmailIndex")
                    .IsUnique();

                entity.HasIndex(e => e.LastName, "LastNameIndex")
                    .IsUnique();

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.Birthday).HasColumnType("date");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Nickname)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Pass)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.RatingId).HasColumnName("RatingID");

                entity.HasOne(d => d.Rating)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.RatingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("employee_ratingid_foreign");
            });

            modelBuilder.Entity<Employer>(entity =>
            {
                entity.ToTable("Employer");

                entity.HasIndex(e => e.Email, "EmailIndex")
                    .IsUnique();

                entity.HasIndex(e => e.LastName, "LastNameIndex")
                    .IsUnique();

                entity.Property(e => e.EmployerId).HasColumnName("EmployerID");

                entity.Property(e => e.Birthday).HasColumnType("date");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Nickname)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Pass)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<InterstedInRequest>(entity =>
            {
                entity.ToTable("InterstedInRequest");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.EmployerId).HasColumnName("EmployerID");

                entity.Property(e => e.JobRequestId).HasColumnName("JobRequestID");

                entity.HasOne(d => d.JobRequest)
                    .WithMany(p => p.InterstedInRequests)
                    .HasForeignKey(d => d.JobRequestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("interstedinrequest_jobrequestid_foreign");
            });

            modelBuilder.Entity<JobApplication>(entity =>
            {
                entity.HasKey(e => e.AppId)
                    .HasName("PK__JobAppli__8E2CF7D902688066");

                entity.ToTable("JobApplication");

                entity.HasIndex(e => e.AppStatus, "AppStatusIndex")
                    .IsUnique();

                entity.Property(e => e.AppId).HasColumnName("AppID");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.EmployerId).HasColumnName("EmployerID");

                entity.Property(e => e.JobOfferId).HasColumnName("JobOfferID");

                entity.HasOne(d => d.AppStatusNavigation)
                    .WithOne(p => p.JobApplication)
                    .HasForeignKey<JobApplication>(d => d.AppStatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("jobapplication_appstatus_foreign");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.JobApplications)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("jobapplication_employeeid_foreign");

                entity.HasOne(d => d.Employer)
                    .WithMany(p => p.JobApplications)
                    .HasForeignKey(d => d.EmployerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("jobapplication_employerid_foreign");

                entity.HasOne(d => d.JobOffer)
                    .WithMany(p => p.JobApplications)
                    .HasForeignKey(d => d.JobOfferId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("jobapplication_jobofferid_foreign");
            });

            modelBuilder.Entity<JobApplicationStatus>(entity =>
            {
                entity.HasKey(e => e.StatusId)
                    .HasName("PK__JobAppli__C8EE20432C476996");

                entity.ToTable("JobApplicationStatus");

                entity.HasIndex(e => e.StatusName, "StatusNameIndex")
                    .IsUnique();

                entity.Property(e => e.StatusId).HasColumnName("StatusID");

                entity.Property(e => e.StatusName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<JobOffer>(entity =>
            {
                entity.ToTable("JobOffer");

                entity.HasIndex(e => e.JobOfferStatusId, "JobOfferStatusIDIndex")
                    .IsUnique();

                entity.Property(e => e.JobOfferId).HasColumnName("JobOfferID");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.CommentId).HasColumnName("CommentID");

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.EmployerId).HasColumnName("EmployerID");

                entity.Property(e => e.JobOfferStatusId).HasColumnName("JobOfferStatusID");

                entity.Property(e => e.Topic)
                    .IsRequired()
                    .HasColumnType("text");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.JobOffers)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("joboffer_categoryid_foreign");

                entity.HasOne(d => d.Comment)
                    .WithMany(p => p.JobOffers)
                    .HasForeignKey(d => d.CommentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("joboffer_commentid_foreign");

                entity.HasOne(d => d.Employer)
                    .WithMany(p => p.JobOffers)
                    .HasForeignKey(d => d.EmployerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("joboffer_employerid_foreign");

                entity.HasOne(d => d.JobOfferStatus)
                    .WithOne(p => p.JobOffer)
                    .HasForeignKey<JobOffer>(d => d.JobOfferStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("joboffer_jobofferstatusid_foreign");
            });

            modelBuilder.Entity<JobOfferStatus>(entity =>
            {
                entity.ToTable("JobOfferStatus");

                entity.HasIndex(e => e.JobOfferStatus1, "JobOfferStatusIndex")
                    .IsUnique();

                entity.Property(e => e.JobOfferStatusId).HasColumnName("JobOfferStatusID");

                entity.Property(e => e.JobOfferStatus1)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("JobOfferStatus");
            });

            modelBuilder.Entity<JobRequest>(entity =>
            {
                entity.ToTable("JobRequest");

                entity.HasIndex(e => e.EmployeeId, "EmployeeIDIndex")
                    .IsUnique();

                entity.Property(e => e.JobRequestId).HasColumnName("JobRequestID");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.CommentId).HasColumnName("CommentID");

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.EmployerId).HasColumnName("EmployerID");

                entity.Property(e => e.JobOfferStatusId).HasColumnName("JobOfferStatusID");

                entity.Property(e => e.Topic)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.JobRequests)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("jobrequest_categoryid_foreign");

                entity.HasOne(d => d.Comment)
                    .WithMany(p => p.JobRequests)
                    .HasForeignKey(d => d.CommentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("jobrequest_commentid_foreign");

                entity.HasOne(d => d.JobOfferStatus)
                    .WithMany(p => p.JobRequests)
                    .HasForeignKey(d => d.JobOfferStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("jobrequest_jobofferstatusid_foreign");
            });

            modelBuilder.Entity<Rating>(entity =>
            {
                entity.ToTable("Rating");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.RatingId).HasColumnName("RatingID");

                entity.Property(e => e.RatingName)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
