using Microsoft.EntityFrameworkCore;

namespace HW4;

internal class AcademyContext : DbContext
{
    private readonly string connectionString;

    public DbSet<Group> Groups { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Faculty> Faculties { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Student> Students { get; set; }

    public AcademyContext(string connString)
    {
        connectionString = connString;
        Database.EnsureDeleted();
        Database.EnsureCreated();
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Groups
        modelBuilder
            .Entity<Group>()
            .Property(x => x.GroupId)
            .HasColumnName("Id")
            .ValueGeneratedOnAdd();

        modelBuilder
            .Entity<Group>()
            .Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(10);

        modelBuilder
            .Entity<Group>()
            .HasIndex(x => x.Name)
            .IsUnique()
            .HasDatabaseName("UQ_Group_Name");

        modelBuilder
            .Entity<Group>()
            .ToTable(x => x.
            HasCheckConstraint("CK_Group_Rating", "Rating BETWEEN 0 AND 5"));

        modelBuilder
            .Entity<Group>()
            .ToTable(x => x.
            HasCheckConstraint("CK_Group_Year", "Year BETWEEN 1 AND 5"));

        // Departments
        modelBuilder
            .Entity<Department>()
            .Property(x => x.DepartmentId)
            .HasColumnName("Id")
            .ValueGeneratedOnAdd();

        modelBuilder
            .Entity<Department>()
            .Property(x => x.Financing)
            .IsRequired()
            .HasColumnType("money")
            .HasDefaultValue(0);

        modelBuilder
            .Entity<Department>()
            .ToTable(x => x
            .HasCheckConstraint("CK_Department_Financing", "Financing >= 0"));

        modelBuilder
            .Entity<Department>()
            .Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(100);

        modelBuilder
            .Entity<Department>()
            .HasIndex(x => x.Name)
            .IsUnique()
            .HasDatabaseName("UQ_Department_Name");

        // Faculties
        modelBuilder
            .Entity<Faculty>()
            .Property(x => x.FacultyId)
            .HasColumnName("Id")
            .ValueGeneratedOnAdd();

        modelBuilder
            .Entity<Faculty>()
            .Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(100);

        modelBuilder
            .Entity<Faculty>()
            .HasIndex(x => x.Name)
            .IsUnique()
            .HasDatabaseName("UQ_Faculty_Name");

        // Teachers
        modelBuilder
            .Entity<Teacher>()
            .Property(x => x.TeacherId)
            .HasColumnName("Id")
            .ValueGeneratedOnAdd();

        modelBuilder
            .Entity<Teacher>()
            .Property(x => x.EmploymentDate)
            .IsRequired()
            .HasColumnType("date");

        modelBuilder
            .Entity<Teacher>()
            .ToTable(x => x
            .HasCheckConstraint("CK_Teacher_EmploymentDate", "EmploymentDate >= '1990-01-01'"));

        modelBuilder
            .Entity<Teacher>()
            .Property(x => x.FirstName)
            .IsRequired()
            .HasColumnName("Name");

        modelBuilder
            .Entity<Teacher>()
            .Property(x => x.LastName)
            .IsRequired()
            .HasColumnName("Surname");

        modelBuilder
            .Entity<Teacher>()
            .Property(x => x.Premium)
            .IsRequired()
            .HasColumnType("money")
            .HasDefaultValue(0);

        modelBuilder
            .Entity<Teacher>()
            .ToTable(x => x
            .HasCheckConstraint("CK_Teacher_Premium", "Premium >= 0"));

        modelBuilder
            .Entity<Teacher>()
            .Property(x => x.Salary)
            .IsRequired()
            .HasColumnType("money");

        modelBuilder
            .Entity<Teacher>()
            .ToTable(x => x
            .HasCheckConstraint("CK_Teacher_Salary", "Salary > 0"));

        modelBuilder
            .Entity<Teacher>()
            .HasOne(x => x.Department)
            .WithMany(d => d.Teachers)
            .HasForeignKey(x => x.DepartmentId)
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("FK_Teacher_Department");

        modelBuilder
            .Entity<Teacher>()
            .HasMany(x => x.Groups)
            .WithMany(g => g.Teachers)
            .UsingEntity(x => x.ToTable("TeacherGroup"));

        // Students
        modelBuilder
            .Entity<Student>()
            .Property(x => x.StudentId)
            .HasColumnName("Id")
            .ValueGeneratedOnAdd();

        modelBuilder
            .Entity<Student>()
            .Property(x => x.FirstName)
            .IsRequired()
            .HasColumnName("Name");

        modelBuilder
            .Entity<Student>()
            .Property(x => x.LastName)
            .IsRequired()
            .HasColumnName("Surname");

        modelBuilder
            .Entity<Student>()
            .HasOne(s => s.Group)
            .WithMany(g => g.Students)
            .HasForeignKey(s => s.GroupId)
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("FK_Student_Group");

        modelBuilder
            .Entity<Student>()
            .HasOne(s => s.Faculty)
            .WithMany(f => f.Students)
            .HasForeignKey(s => s.FacultyId)
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("FK_Student_Faculty");
    }
}
