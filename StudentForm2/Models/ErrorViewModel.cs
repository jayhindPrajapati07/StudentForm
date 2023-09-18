using BackEnd;
namespace StudentForm2.Models
{
    
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
        
    }
}