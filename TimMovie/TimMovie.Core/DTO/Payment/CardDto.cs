using System.ComponentModel.DataAnnotations;

namespace TimMovie.Core.DTO.Payment;

public class CardDto
{
    [Required(ErrorMessage = "required field")]
    [MinLength(13, ErrorMessage = "incorrect card length")]
    [MaxLength(19, ErrorMessage = "incorrect card length")]
    public string CardNumber { get; set; } = null!;
    
    [DataType(DataType.Password)]
    [Required(ErrorMessage = "required field")]
    [MinLength(3,ErrorMessage = "incorrect cvv length")]
    [MaxLength(7,ErrorMessage = "incorrect cvv length")]
    public string CCID { get; set; } = null!;
    
    [Required(ErrorMessage = "required field")]
    [Range(1,12,ErrorMessage = "invalid value for the month")]
    public int ExpirationMonth { get; set; }
    
    [Required(ErrorMessage = "required field")]
    [Range(2022,int.MaxValue,ErrorMessage = "your card has expired")]
    public int ExpirationYear { get; set; }
}