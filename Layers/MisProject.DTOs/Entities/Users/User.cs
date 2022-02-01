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

    #region UserName

    private string _userName = null!;
    [Required, MinLength(5), MaxLength(20), RegularExpression("^[a-zA-Z][a-zA-Z0-9_]{4,19}$")]
    public string UserName
    {
        get => _userName;
        set => _userName = FixedUserName = value;
    }


    private string _fixedUserName = null!;
    [Required, MaxLength(20)]
    public string FixedUserName
    {
        get => _fixedUserName;
        private set => _fixedUserName = value.ToFixedText();
    }

    #endregion


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

    [Required, MinLength(3), MaxLength(30)]
    public string? FatherName { get; set; } = null!;
    
    [MinLength(3), MaxLength(10), RegularExpression(@"[0-9]{10}")]
    public string? NationalCode { get; set; }

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