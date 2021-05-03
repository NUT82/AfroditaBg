namespace AfroditaBg.Web.ViewModels.Contacts
{
    using System.ComponentModel.DataAnnotations;

    public class SendMessageInputModel
    {
        [Required(ErrorMessage = "Полето е задължително.")]
        [MinLength(5, ErrorMessage = "Полето трябва да е поне 5 символа.")]
        public string SenderName { get; set; }

        [Required(ErrorMessage = "Полето е задължително.")]
        [EmailAddress(ErrorMessage = "Невалиден имейл адрес.")]
        public string SenderEmail { get; set; }

        public string EmailSubject { get; set; }

        [Required(ErrorMessage = "Полето е задължително.")]
        [MinLength(20, ErrorMessage = "Полето трябва да е поне 20 символа.")]
        public string Message { get; set; }
    }
}
