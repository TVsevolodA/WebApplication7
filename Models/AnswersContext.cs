using System.Data.Entity;

namespace WebApplication7.Models
{
    public class AnswersContext : DbContext
    {
        public DbSet<Questionnaire> Questionnaires { get; set; }
    }
}