using System;

namespace StudentAdvisor.Models;

public class StudentProgram
{
    public ushort StudentProgramId {get; set;}
    
    public string programTitle {get; set; }
    public List <Student>? Students {get;set;}


}
