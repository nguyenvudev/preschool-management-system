// Infrastructure/Persistence/SeedData/ModelBuilderExtensions.cs
using Microsoft.EntityFrameworkCore;
using PreschoolManagementSystem.Domain.Entities;
using PreschoolManagementSystem.Domain.Enums;

namespace PreschoolManagementSystem.Infrastructure.Persistence.SeedData
{
    public static class ModelBuilderExtensions
    {
        public static void ApplySeedData(this ModelBuilder modelBuilder)
        {
            var (adminId, teacher1Id, teacher2Id, medicalStaffId, preschoolId) = SeedUsers(modelBuilder);
            var (classroom1Id, classroom2Id, classroom3Id) = SeedClassrooms(modelBuilder, teacher1Id, teacher2Id);
            SeedStudents(modelBuilder, classroom1Id, classroom2Id, classroom3Id);
            SeedHealthRecords(modelBuilder, medicalStaffId);
            SeedMenus(modelBuilder, adminId);
        }

        private static (Guid adminId, Guid teacher1Id, Guid teacher2Id, Guid medicalStaffId, Guid preschoolId) 
            SeedUsers(ModelBuilder modelBuilder)
        {
            var adminId = Guid.NewGuid();
            var teacher1Id = Guid.NewGuid();
            var teacher2Id = Guid.NewGuid();
            var medicalStaffId = Guid.NewGuid();
            var preschoolId = Guid.NewGuid();

            // Admin user
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = adminId,
                    Email = "admin@preschool.com",
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("Admin123!"),
                    FullName = "Quản trị viên hệ thống",
                    Role = UserRole.Admin,
                    PhoneNumber = "0901234567",
                    PreschoolId = preschoolId,
                    IsActive = true,
                    CreatedAt = new DateTime(2024, 1, 1),
                    UpdatedAt = new DateTime(2024, 1, 1)
                }
            );

            // Teachers
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = teacher1Id,
                    Email = "giaovien1@preschool.com",
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("Teacher123!"),
                    FullName = "Nguyễn Thị Mai",
                    Role = UserRole.Teacher,
                    PhoneNumber = "0901234568",
                    PreschoolId = preschoolId,
                    IsActive = true,
                    CreatedAt = new DateTime(2024, 1, 1),
                    UpdatedAt = new DateTime(2024, 1, 1)
                },
                new User
                {
                    Id = teacher2Id,
                    Email = "giaovien2@preschool.com",
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("Teacher123!"),
                    FullName = "Trần Văn Hùng",
                    Role = UserRole.Teacher,
                    PhoneNumber = "0901234569",
                    PreschoolId = preschoolId,
                    IsActive = true,
                    CreatedAt = new DateTime(2024, 1, 1),
                    UpdatedAt = new DateTime(2024, 1, 1)
                }
            );

            // Medical staff
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = medicalStaffId,
                    Email = "yte@preschool.com",
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("Medical123!"),
                    FullName = "Bác sĩ Lan Anh",
                    Role = UserRole.MedicalStaff,
                    PhoneNumber = "0901234570",
                    PreschoolId = preschoolId,
                    IsActive = true,
                    CreatedAt = new DateTime(2024, 1, 1),
                    UpdatedAt = new DateTime(2024, 1, 1)
                }
            );

            return (adminId, teacher1Id, teacher2Id, medicalStaffId, preschoolId);
        }

        private static (Guid classroom1Id, Guid classroom2Id, Guid classroom3Id) 
            SeedClassrooms(ModelBuilder modelBuilder, Guid teacher1Id, Guid teacher2Id)
        {
            var classroom1Id = Guid.NewGuid();
            var classroom2Id = Guid.NewGuid();
            var classroom3Id = Guid.NewGuid();

            modelBuilder.Entity<Classroom>().HasData(
                new Classroom
                {
                    Id = classroom1Id,
                    Name = "Lớp Mầm 1",
                    GradeLevel = GradeLevel.Mam,
                    Capacity = 20,
                    MainTeacherId = teacher1Id,
                    AcademicYear = 2024,
                    Description = "Lớp dành cho trẻ 3-4 tuổi",
                    IsActive = true,
                    CreatedAt = new DateTime(2024, 1, 1),
                    UpdatedAt = new DateTime(2024, 1, 1)
                },
                new Classroom
                {
                    Id = classroom2Id,
                    Name = "Lớp Chồi 1",
                    GradeLevel = GradeLevel.Choi,
                    Capacity = 22,
                    MainTeacherId = teacher2Id,
                    AcademicYear = 2024,
                    Description = "Lớp dành cho trẻ 4-5 tuổi",
                    IsActive = true,
                    CreatedAt = new DateTime(2024, 1, 1),
                    UpdatedAt = new DateTime(2024, 1, 1)
                },
                new Classroom
                {
                    Id = classroom3Id,
                    Name = "Lớp Lá 1",
                    GradeLevel = GradeLevel.La,
                    Capacity = 25,
                    MainTeacherId = teacher1Id,
                    AcademicYear = 2024,
                    Description = "Lớp dành cho trẻ 5-6 tuổi",
                    IsActive = true,
                    CreatedAt = new DateTime(2024, 1, 1),
                    UpdatedAt = new DateTime(2024, 1, 1)
                }
            );

            return (classroom1Id, classroom2Id, classroom3Id);
        }

        private static void SeedStudents(ModelBuilder modelBuilder, Guid classroom1Id, Guid classroom2Id, Guid classroom3Id)
        {
            var students = new List<Students>
            {
                // Lớp Mầm
                new Students
                {
                    Id = Guid.NewGuid(),
                    Code = "MS001",
                    FullName = "Nguyễn Văn An",
                    DateOfBirth = new DateTime(2020, 3, 15),
                    Gender = Gender.Male.ToString(),
                    ParentName = "Nguyễn Văn Bố",
                    ParentPhone = "0901111111",
                    ParentEmail = "parent1@email.com",
                    Address = "123 Đường ABC, Quận 1, TP.HCM",
                    BloodType = "A",
                    Allergies = "Hải sản, đậu phộng",
                    EmergencyContact = "Mẹ - 0901111112",
                    EmergencyPhone = "0901111112",
                    ClassroomId = classroom1Id,
                    Status = StudentStatus.Active,
                    CreatedAt = new DateTime(2024, 1, 15),
                    UpdatedAt = new DateTime(2024, 1, 15)
                },
                new Students
                {
                    Id = Guid.NewGuid(),
                    Code = "MS002",
                    FullName = "Trần Thị Bích",
                    DateOfBirth = new DateTime(2020, 6, 20),
                    Gender = Gender.Female.ToString(),
                    ParentName = "Trần Văn Mẹ",
                    ParentPhone = "0902222222",
                    ParentEmail = "parent2@email.com",
                    Address = "456 Đường XYZ, Quận 2, TP.HCM",
                    BloodType = "O",
                    EmergencyContact = "Bố - 0902222223",
                    EmergencyPhone = "0902222223",
                    ClassroomId = classroom1Id,
                    Status = StudentStatus.Active,
                    CreatedAt = new DateTime(2024, 1, 16),
                    UpdatedAt = new DateTime(2024, 1, 16)
                },

                // Lớp Chồi
                new Students
                {
                    Id = Guid.NewGuid(),
                    Code = "CS001",
                    FullName = "Lê Văn Cường",
                    DateOfBirth = new DateTime(2019, 8, 10),
                    Gender = Gender.Male.ToString(),
                    ParentName = "Lê Văn Cha",
                    ParentPhone = "0903333333",
                    ParentEmail = "parent3@email.com",
                    Address = "789 Đường DEF, Quận 3, TP.HCM",
                    BloodType = "B",
                    Allergies = "Sữa bò",
                    EmergencyContact = "Mẹ - 0903333334",
                    EmergencyPhone = "0903333334",
                    ClassroomId = classroom2Id,
                    Status = StudentStatus.Active,
                    CreatedAt = new DateTime(2024, 1, 17),
                    UpdatedAt = new DateTime(2024, 1, 17)
                },
                new Students
                {
                    Id = Guid.NewGuid(),
                    Code = "CS002",
                    FullName = "Phạm Thị Dung",
                    DateOfBirth = new DateTime(2019, 11, 5),
                    Gender = Gender.Female.ToString(),
                    ParentName = "Phạm Văn Ba",
                    ParentPhone = "0904444444",
                    ParentEmail = "parent4@email.com",
                    Address = "321 Đường GHI, Quận 4, TP.HCM",
                    BloodType = "AB",
                    EmergencyContact = "Bố - 0904444445",
                    EmergencyPhone = "0904444445",
                    ClassroomId = classroom2Id,
                    Status = StudentStatus.Active,
                    CreatedAt = new DateTime(2024, 1, 18),
                    UpdatedAt = new DateTime(2024, 1, 18)
                },

                // Lớp Lá
                new Students
                {
                    Id = Guid.NewGuid(),
                    Code = "LS001",
                    FullName = "Hoàng Văn Em",
                    DateOfBirth = new DateTime(2018, 2, 28),
                    Gender = Gender.Male.ToString(),
                    ParentName = "Hoàng Văn Anh",
                    ParentPhone = "0905555555",
                    ParentEmail = "parent5@email.com",
                    Address = "654 Đường JKL, Quận 5, TP.HCM",
                    BloodType = "O",
                    MedicalConditions = "Hen suyễn nhẹ",
                    EmergencyContact = "Mẹ - 0905555556",
                    EmergencyPhone = "0905555556",
                    ClassroomId = classroom3Id,
                    Status = StudentStatus.Active,
                    CreatedAt = new DateTime(2024, 1, 19),
                    UpdatedAt = new DateTime(2024, 1, 19)
                }
            };

            modelBuilder.Entity<Students>().HasData(students);
        }

        private static void SeedHealthRecords(ModelBuilder modelBuilder, Guid medicalStaffId)
        {
            // Get student IDs from the seeded data
            var studentIds = new List<Guid>();
            
            // We'll create health records for the first 3 students
            for (int i = 0; i < 3; i++)
            {
                studentIds.Add(Guid.NewGuid());
            }

            var healthRecords = new List<HealthRecord>
            {
                new HealthRecord
                {
                    Id = Guid.NewGuid(),
                    StudentId = studentIds[0],
                    RecordDate = new DateTime(2024, 2, 1),
                    Height = 95.5m,
                    Weight = 14.2m,
                    BMI = 15.6m,
                    Temperature = 36.8m,
                    HealthStatus = HealthStatus.Good,
                    Symptoms = "Không",
                    RecordedById = medicalStaffId,
                    CreatedAt = new DateTime(2024, 2, 1),
                    UpdatedAt = new DateTime(2024, 2, 1)
                },
                new HealthRecord
                {
                    Id = Guid.NewGuid(),
                    StudentId = studentIds[1],
                    RecordDate = new DateTime(2024, 2, 1),
                    Height = 92.0m,
                    Weight = 13.5m,
                    BMI = 15.9m,
                    Temperature = 36.7m,
                    HealthStatus = HealthStatus.Excellent,
                    Symptoms = "Không",
                    RecordedById = medicalStaffId,
                    CreatedAt = new DateTime(2024, 2, 1),
                    UpdatedAt = new DateTime(2024, 2, 1)
                },
                new HealthRecord
                {
                    Id = Guid.NewGuid(),
                    StudentId = studentIds[2],
                    RecordDate = new DateTime(2024, 2, 1),
                    Height = 98.0m,
                    Weight = 15.0m,
                    BMI = 15.6m,
                    Temperature = 36.9m,
                    HealthStatus = HealthStatus.Good,
                    Symptoms = "Ho nhẹ",
                    Medications = "Si rô ho",
                    RecordedById = medicalStaffId,
                    CreatedAt = new DateTime(2024, 2, 1),
                    UpdatedAt = new DateTime(2024, 2, 1)
                }
            };

            modelBuilder.Entity<HealthRecord>().HasData(healthRecords);
        }

        private static void SeedMenus(ModelBuilder modelBuilder, Guid createdById)
        {
            var menuId = Guid.NewGuid();

            modelBuilder.Entity<Menu>().HasData(
                new Menu
                {
                    Id = menuId,
                    Name = "Thực đơn tuần 1 tháng 2",
                    Description = "Thực đơn cân bằng dinh dưỡng cho tuần đầu tháng 2",
                    EffectiveDate = new DateTime(2024, 2, 1),
                    ExpiryDate = new DateTime(2024, 2, 7),
                    MenuType = Domain.Enums.MenuType.Weekly, // Sử dụng fully qualified name
                    Season = Domain.Enums.Season.Spring, // Sử dụng fully qualified name
                    TotalCalories = 1250,
                    TotalProtein = 45,
                    TotalFat = 35,
                    TotalCarbs = 180,
                    IsActive = true,
                    CreatedById = createdById,
                    CreatedAt = new DateTime(2024, 1, 28),
                    UpdatedAt = new DateTime(2024, 1, 28)
                }
            );

            // Sample menu meals - sử dụng fully qualified names để tránh conflict
            modelBuilder.Entity<MenuMeal>().HasData(
                new MenuMeal
                {
                    Id = Guid.NewGuid(),
                    MenuId = menuId,
                    DayOfWeek = DayOfWeek.Monday,
                    MealType = Domain.Entities.MealType.Breakfast, // Sử dụng fully qualified name
                    DishName = "Cháo thịt băm, sữa",
                    Ingredients = "Gạo, thịt heo, cà rốt, sữa tươi",
                    Calories = 250,
                    Protein = 8,
                    Fat = 5,
                    Carbs = 40,
                    ServingSize = 200,
                    ServingUnit = "g",
                    CreatedAt = new DateTime(2024, 1, 28),
                    UpdatedAt = new DateTime(2024, 1, 28)
                },
                new MenuMeal
                {
                    Id = Guid.NewGuid(),
                    MenuId = menuId,
                    DayOfWeek = DayOfWeek.Monday,
                    MealType = Domain.Entities.MealType.Lunch, // Sử dụng fully qualified name
                    DishName = "Cơm, cá kho, canh rau",
                    Ingredients = "Gạo, cá thu, rau muống, cà chua",
                    Calories = 450,
                    Protein = 20,
                    Fat = 15,
                    Carbs = 60,
                    ServingSize = 250,
                    ServingUnit = "g",
                    CreatedAt = new DateTime(2024, 1, 28),
                    UpdatedAt = new DateTime(2024, 1, 28)
                },
                new MenuMeal
                {
                    Id = Guid.NewGuid(),
                    MenuId = menuId,
                    DayOfWeek = DayOfWeek.Monday,
                    MealType = Domain.Entities.MealType.AfternoonSnack, // Sử dụng fully qualified name
                    DishName = "Bánh flan, nước cam",
                    Ingredients = "Trứng, sữa, đường, cam",
                    Calories = 150,
                    Protein = 5,
                    Fat = 3,
                    Carbs = 25,
                    ServingSize = 150,
                    ServingUnit = "g",
                    CreatedAt = new DateTime(2024, 1, 28),
                    UpdatedAt = new DateTime(2024, 1, 28)
                }
            );
        }
    }
}