// Domain/Entities/DevelopmentAssessment.cs
namespace PreschoolManagementSystem.Domain.Entities
{
    public class DevelopmentAssessment : BaseEntity
    {
        public Guid StudentId { get; set; }
        public DateTime AssessmentDate { get; set; }
        public string AssessorName { get; set; } = string.Empty;
        
        // Physical development (1-5 scale)
        public int GrossMotorSkills { get; set; }        // Kỹ năng vận động thô
        public int FineMotorSkills { get; set; }         // Kỹ năng vận động tinh
        
        // Cognitive development
        public int CognitiveSkills { get; set; }         // Nhận thức
        public int ProblemSolving { get; set; }          // Giải quyết vấn đề
        public int MemorySkills { get; set; }            // Trí nhớ
        
        // Language development
        public int VerbalCommunication { get; set; }     // Giao tiếp ngôn ngữ
        public int Vocabulary { get; set; }              // Vốn từ vựng
        public int ListeningSkills { get; set; }         // Kỹ năng nghe
        
        // Social-emotional development
        public int SocialSkills { get; set; }            // Kỹ năng xã hội
        public int EmotionalRegulation { get; set; }     // Điều chỉnh cảm xúc
        public int Cooperation { get; set; }             // Hợp tác
        public int SelfConfidence { get; set; }          // Tự tin
        
        // Self-care skills
        public int Toileting { get; set; }               // Tự đi vệ sinh
        public int EatingSkills { get; set; }            // Kỹ năng ăn uống
        public int DressingSkills { get; set; }          // Kỹ năng mặc quần áo
        
        public string Strengths { get; set; } = string.Empty;
        public string AreasForImprovement { get; set; } = string.Empty;
        public string Recommendations { get; set; } = string.Empty;
        public string OverallAssessment { get; set; } = string.Empty;

        // Navigation properties
        public virtual Students Students { get; set; } = null!;
    }
}