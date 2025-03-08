
namespace StudentAdvisor.Models;
using StudentAdvisor.Models;
public class AdvisorsNote
{
    public ushort AdvisorsNoteId { get; set; }

    public ushort StudentId { get; set; }

    public Student? Students { get; set; }
    public String Note { get; set; } = " ";
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    

}
