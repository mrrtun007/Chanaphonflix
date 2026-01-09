using System.ComponentModel.DataAnnotations;

namespace Chanaphonflix.ViewModels;

public class RegisterViewModel
{
    [Required(ErrorMessage = "กรุณากรอกชื่อ-นามสกุล")]
    [Display(Name = "ชื่อ-นามสกุล")]
    public string FullName { get; set; } = string.Empty;

    [Required(ErrorMessage = "กรุณากรอกอีเมล")]
    [EmailAddress(ErrorMessage = "รูปแบบอีเมลไม่ถูกต้อง")]
    [Display(Name = "อีเมล")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "กรุณากรอกรหัสผ่าน")]
    [StringLength(100, ErrorMessage = "รหัสผ่านต้องมีอย่างน้อย {2} ตัวอักษร", MinimumLength = 6)]
    [DataType(DataType.Password)]
    [Display(Name = "รหัสผ่าน")]
    public string Password { get; set; } = string.Empty;

    [DataType(DataType.Password)]
    [Display(Name = "ยืนยันรหัสผ่าน")]
    [Compare("Password", ErrorMessage = "รหัสผ่านไม่ตรงกัน")]
    public string ConfirmPassword { get; set; } = string.Empty;
}
