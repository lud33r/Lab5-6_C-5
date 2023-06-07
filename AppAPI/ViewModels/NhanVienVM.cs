using System.ComponentModel.DataAnnotations;

namespace AppAPI.ViewModels
{
    public class NhanVienVM
    {
        [Key]
        public Guid Id { get; set; }
        [StringLength(30, ErrorMessage = "cho mỗi thông tin sai sao cho hợp lý")]
        public string Ten { get; set; }
        [Range(18, 50, ErrorMessage = "cho mỗi thông tin sai sao cho hợp lý")]
        public int Tuoi { get; set; }
        public int Role { get; set; }
        [EmailAddress(ErrorMessage = "cho mỗi thông tin sai sao cho hợp lý")]
        public string Email { get; set; }
        [Range(5000000, 30000000, ErrorMessage = "cho mỗi thông tin sai sao cho hợp lý")]
        public int Luong { get; set; }
        [Required]
        public bool TrangThai { get; set; }
    }
}
