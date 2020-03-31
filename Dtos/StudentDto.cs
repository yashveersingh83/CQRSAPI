namespace API2.Dto
{
    public sealed class StudentDto
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public string Course1 { get; set; }
        public string Course1Grade { get; set; }
        public int? Course1Credits { get; set; }
        public int? Course1ID { get; set; }
        public int? Course2ID { get; set; }

        public string Course2 { get; set; }
        public string Course2Grade { get; set; }
        public int? Course2Credits { get; set; }
    }

     public sealed class StudentDisenrollmentDto
    {
        public long StudentId { get; set; }
        public long EnrollmentNumber { get; set; }
        public string Comment { get; set; }
    }

    public sealed class StudentPersonalInfoDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long StudentId { get; set; }
    }

    public sealed class StudentCourseTransferDto
    {
      
        public int CurrentCourseID { get; set; }
        public int NewCourseID { get; set; }
        public long StudentId { get; set; }
    }
}
