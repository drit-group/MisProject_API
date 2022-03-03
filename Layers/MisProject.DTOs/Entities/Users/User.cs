namespace MisProject.DTOs.Entities.Users;

public class User
{
    public User()
    {
        RegisterTime = DateTime.Now;
        ActiveCode = NameGenerator.GenerateUniqueCode();
        IdentityCode = NameGenerator.GenerateUniqueCode();
    }

    [Key] public int UserId { get; set; }


    [MinLength(3), MaxLength(10), RegularExpression(@"[0-9]{10}"), Required]
    public string NationalCode { get; set; }

    #region Email

    private string _email = null!;
    [EmailAddress, Required, MinLength(3), MaxLength(100), DataType(DataType.EmailAddress)]
    public string Email
    {
        get => _email;
        set => _email = FixedEmail = value;
    }


    private string _fixedEmail = null!;
    [EmailAddress, Required, MinLength(3), MaxLength(100), DataType(DataType.EmailAddress)]
    public string FixedEmail
    {
        get => _fixedEmail;
        private set => _fixedEmail = value.ToFixedText();
    }

    #endregion


    #region Security

    public string Password { get; set; } = null!;

    /// <summary>
    ///     Change in every update
    /// </summary>
    [Required, MaxLength(50)]
    public string IdentityCode { get; set; } = null!;

    /// <summary>
    ///     Email Activation code.
    ///     Change when Security Items edited.
    /// </summary>
    [Required, MaxLength(50)]
    public string ActiveCode { get; set; } = null!;

    #endregion


    #region Confirmations

    public bool IsEmailConfirmed { get; set; }
    public bool IsPhoneNumberConfirmed { get; set; }

    #endregion


    #region Personal Info

    [Required, MinLength(3), MaxLength(30)]
    public string FirstName { get; set; } = null!;

    [Required, MinLength(3), MaxLength(30)]
    public string LastName { get; set; } = null!;

    [MinLength(3), MaxLength(30)]
    public string? FatherName { get; set; } = null!;

    [DataType(DataType.Date)]
    public DateTime? BirthDay { get; set; }

    [MaxLength(2000)]
    public string? Interests { get; set; }

    #endregion


    #region Contact Info

    [MinLength(11), MaxLength(11), RegularExpression(@"[0-9]{11}")]
    public string? HomeNumber { get; set; }

    [MinLength(11), MaxLength(11), RegularExpression(@"[0-9]{11}")]
    public string? PhoneNumber { get; set; }

    [MaxLength(30)]
    public string? TelegramId { get; set; }

    [MaxLength(500)]
    public string? Address { get; set; }

    #endregion


    public bool IsDeleted { get; set; }
    public DateTime RegisterTime { get; set; }



    #region Relations

    public ICollection<UserRole> UserRoles { get; set; } = null!;

    #endregion
}