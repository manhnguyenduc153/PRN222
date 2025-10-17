namespace ApiWithRoles.Models
{
    public class StudentModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }

    public class StudentSearchModel : BaseSearch
    {
        // Nếu cần thêm field riêng cho Student thì thêm ở đây
        // Ví dụ: public int? Age { get; set; }
    }

    public class StudentSaveModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
