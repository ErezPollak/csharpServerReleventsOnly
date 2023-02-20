using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Entities.Entities
{
    public partial class My_Virtua_lSchoolContext : DbContext
    {
        public My_Virtua_lSchoolContext()
        {
        }

        public My_Virtua_lSchoolContext(DbContextOptions<My_Virtua_lSchoolContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Course> Course { get; set; }
        public virtual DbSet<CoursesToClsss> CoursesToClsss { get; set; }
        public virtual DbSet<Groups> Groups { get; set; }
        public virtual DbSet<LearningFile> LearningFile { get; set; }
        public virtual DbSet<LessonsTaken> LessonsTaken { get; set; }
        public virtual DbSet<PreparedLesson> PreparedLesson { get; set; }
        public virtual DbSet<Schedule> Schedule { get; set; }
        public virtual DbSet<ScheduleHours> ScheduleHours { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<Teacher> Teacher { get; set; }
        public virtual DbSet<presenceInLessons> presenceInLessons { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-39V8OAL\\SQLEXPRESS;Initial Catalog=My_Virtu_alSchool;Integrated Security=SSPI;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasKey(e => e.CoueseId)
                    .HasName("PK__Course__A47F7EC98B3E1A89");

                entity.Property(e => e.CoueseId)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CourseName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ImgCourse).IsUnicode(false);

                entity.Property(e => e.TeacherId).HasColumnType("numeric(18, 0)");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.Course)
                    .HasForeignKey(d => d.TeacherId)
                    .HasConstraintName("FK__Course__TeacherI__1273C1CD");
            });

            modelBuilder.Entity<CoursesToClsss>(entity =>
            {
                entity.Property(e => e.CoursesToClsssId)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CourseId).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.IdGroup).HasColumnType("numeric(18, 0)");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.CoursesToClsss)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK__CoursesTo__Cours__173876EA");

                entity.HasOne(d => d.IdGroupNavigation)
                    .WithMany(p => p.CoursesToClsss)
                    .HasForeignKey(d => d.IdGroup)
                    .HasConstraintName("FK__CoursesTo__IdGro__182C9B23");
            });

            modelBuilder.Entity<Groups>(entity =>
            {
                entity.Property(e => e.GroupsId)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.GroupName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.rankGroup).HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<LearningFile>(entity =>
            {
                entity.HasKey(e => e.FileId)
                    .HasName("PK__Learning__6F0F98BF12232A86");

                entity.Property(e => e.FileId).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.DescriptionFile)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.LessonId).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.SrcDrivFile).IsUnicode(false);

                entity.Property(e => e.SrcPdfFile).IsUnicode(false);

                entity.Property(e => e.TypeFile)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.Lesson)
                    .WithMany(p => p.LearningFile)
                    .HasForeignKey(d => d.LessonId)
                    .HasConstraintName("FK__LearningF__Lesso__2B3F6F97");
            });

            modelBuilder.Entity<LessonsTaken>(entity =>
            {
                entity.Property(e => e.LessonsTakenId)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DateAndTime).HasColumnType("datetime");

                entity.Property(e => e.GroupId).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.LessonId).HasColumnType("numeric(18, 0)");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.LessonsTaken)
                    .HasForeignKey(d => d.GroupId)
                    .HasConstraintName("FK__LessonsTa__Group__276EDEB3");

                entity.HasOne(d => d.Lesson)
                    .WithMany(p => p.LessonsTaken)
                    .HasForeignKey(d => d.LessonId)
                    .HasConstraintName("FK__LessonsTa__Lesso__286302EC");
            });

            modelBuilder.Entity<PreparedLesson>(entity =>
            {
                entity.HasKey(e => e.LessonId)
                    .HasName("PK__Prepared__B084ACD08DC2C8D8");

                entity.Property(e => e.LessonId)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CourseId).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.IndexPreparedLesson).HasColumnType("numeric(18, 0)");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.PreparedLesson)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK__PreparedL__Cours__24927208");
            });

            modelBuilder.Entity<Schedule>(entity =>
            {
                entity.Property(e => e.ScheduleId)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CoursesToClsssId).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ScheduleHourIndex).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.numberDayOfWeek).HasColumnType("numeric(18, 0)");

                entity.HasOne(d => d.CoursesToClsss)
                    .WithMany(p => p.Schedule)
                    .HasForeignKey(d => d.CoursesToClsssId)
                    .HasConstraintName("FK__Schedule__Course__20C1E124");

                entity.HasOne(d => d.ScheduleHourIndexNavigation)
                    .WithMany(p => p.Schedule)
                    .HasForeignKey(d => d.ScheduleHourIndex)
                    .HasConstraintName("FK__Schedule__Schedu__1FCDBCEB");
            });

            modelBuilder.Entity<ScheduleHours>(entity =>
            {
                entity.HasKey(e => e.ScheduleHoursIndex)
                    .HasName("PK__Schedule__93D27EE450BA6070");

                entity.Property(e => e.ScheduleHoursIndex).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.TimeBeginning).HasColumnType("datetime");

                entity.Property(e => e.TimeEnd).HasColumnType("datetime");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property(e => e.StudentId)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Email)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.GroupId).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.IdentitiyNumber)
                    .HasMaxLength(9)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.Student)
                    .HasForeignKey(d => d.GroupId)
                    .HasConstraintName("FK__Student__GroupId__1B0907CE");
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.Property(e => e.TeacherId)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Email)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.IdentitiyNumber)
                    .HasMaxLength(9)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Passwordd)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<presenceInLessons>(entity =>
            {
                entity.Property(e => e.presenceInLessonsId)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CoursesToClsssId).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.DateToday).HasColumnType("date");

                entity.Property(e => e.StudentId).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.TimeBeginning).HasColumnType("datetime");

                entity.Property(e => e.TimeEnd).HasColumnType("datetime");

                entity.HasOne(d => d.CoursesToClsss)
                    .WithMany(p => p.presenceInLessons)
                    .HasForeignKey(d => d.CoursesToClsssId)
                    .HasConstraintName("FK__presenceI__Cours__2F10007B");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.presenceInLessons)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK__presenceI__Stude__2E1BDC42");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
