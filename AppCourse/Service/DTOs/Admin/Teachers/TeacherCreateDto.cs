namespace Service.DTOs.Admin.Teachers
{
    public  class TeacherCreateDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public decimal Salary { get; set; }

    }
}
