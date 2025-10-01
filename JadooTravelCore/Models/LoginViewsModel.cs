using System.ComponentModel.DataAnnotations;

namespace JadooTravelCore.Models
{
    public class LoginViewsModel
    {
        [Required(ErrorMessage ="Kullanıcı adı boş bırakılamaz")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Şifre boş bırakılamaz")]
        [MinLength(8,ErrorMessage ="Şifre minumum 8 karakterlidir.")]
        public string UserPassword { get; set; }

    }
}
