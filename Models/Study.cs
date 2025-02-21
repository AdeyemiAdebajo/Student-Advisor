using System;

namespace StudentAdvisor.Models;

public class Study
{
    public ushort StudyId {get; set;}
    public ushort StudentsId{get;set;}
    public string programTitle {get; set; }
    public List <Student>? Students {get;set;}


}
