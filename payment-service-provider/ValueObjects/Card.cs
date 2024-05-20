using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace payment_service_provider.ValueObjects;

public sealed class Card
{
    [StringLength(4)]
    public string LastFourDigits { get; init; }

    [StringLength(20)]
    public string Name { get; init; }

    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "MM/yyyy")]
    public DateTime ExpirationDate { get; init; }

    [StringLength(4)]
    public string CVV { get; init; }

    private const int _maxLengthDigits = 4;
    private const int _minLengthName = 2;
    private const int _maxLengthName = 20;
    private const int _minLengthCVV = 3;
    private const int _maxLengthCVV = 4;
    private const string _regexPatternSpace = @"[ ]{2,}"; //two or more spaces
    private const string _regexPatternChar = @"[^A-Za-z\s]"; //special characters

    protected Card()
    {
    }

    private Card(string lastFourDigits, string name, DateTime expirationDate, string cvv)
    {
        LastFourDigits = lastFourDigits;
        Name = name;
        ExpirationDate = expirationDate;
        CVV = cvv;
    }

    public static Card Create(string lastFourDigits, string name, DateTime expirationDate, string cvv)
    {
        ValidateLastFourDigits(lastFourDigits);

        ValidateName(name);

        ValidateExpirationDate(expirationDate);

        ValidateCVV(cvv);

        return new Card(lastFourDigits, name.Trim(), expirationDate, cvv);
    }

    private static void ValidateLastFourDigits(string lastFourDigits)
    {
        if (lastFourDigits.Trim().Length != _maxLengthDigits)
            throw new ArgumentException($"Length must be {_maxLengthDigits}.", nameof(lastFourDigits));

        if (!int.TryParse(lastFourDigits, out _))
            throw new ArgumentException("Is not numeric.", nameof(lastFourDigits));
    }

    private static void ValidateName(string name)
    {
        if (name.Trim().Length < _minLengthName || name.Trim().Length > _maxLengthName)
            throw new ArgumentException($"Length must be between {_minLengthName} and {_maxLengthName}.", nameof(name));

        if (Regex.IsMatch(name, _regexPatternSpace))
            throw new ArgumentException($"Not allowed two or more spaces together.", nameof(name));

        if (Regex.IsMatch(name, _regexPatternChar))
            throw new ArgumentException($"Special characters not allowed.", nameof(name));
    }

    private static void ValidateExpirationDate(DateTime expirationDate)
    {
        if (expirationDate < DateTime.Now)
            throw new ArgumentException($"Date has been exceeded.", nameof(expirationDate));
    }

    private static void ValidateCVV(string cvv)
    {
        if (cvv.Trim().Length < _minLengthCVV || cvv.Trim().Length > _maxLengthCVV)
            throw new ArgumentException($"Length must be between {_minLengthCVV} and {_maxLengthCVV}.", nameof(cvv));

        if (!int.TryParse(cvv, out _))
            throw new ArgumentException("Is not numeric.", nameof(cvv));
    }
}
