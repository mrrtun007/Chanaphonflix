using System.ComponentModel.DataAnnotations;

namespace Chanaphonflix.ViewModels;

public class LoginViewModel
{
    [Required(ErrorMessage = "กรุณากรอกอีเมล")]
    [EmailAddress(ErrorMessage = "รูปแบบอีเมลไม่ถูกต้อง")]
    [Display(Name = "อีเมล")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "กรุณากรอกรหัสผ่าน")]
    [DataType(DataType.Password)]
    [Display(Name = "รหัสผ่าน")]
    public string Password { get; set; } = string.Empty;

    [Display(Name = "จำฉันไว้ในระบบ")]
    public bool RememberMe { get; set; }
}
