using System;

namespace StudentAdvisor.Models;

public class Student
{
    public ushort StudentId {get; set;}
    public string FirstName {get; set;}= "";
    public string LastName {get; set;}="";
    public string Gender {get; set;}="";
    public string PhoneNumber {get; set;}="";
    public string Email {get; set;}="";
    public ushort StudyId{get; set;}
    public List<Study>? Studies{get; set;}

    

}
