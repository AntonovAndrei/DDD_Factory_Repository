namespace DDD_Factory_Repository.Customer;

public abstract class PaymentMethod
{
    public string Id { get; private set; }
    public PaymentMethodType PaymentType { get; private set; }
    
    protected PaymentMethod(PaymentMethodType type)
    {
        PaymentType = type;
        Id = new Random().Next(0, Int32.MaxValue).ToString();
    }
}

public class PhoneNumberPaymentMethod : PaymentMethod
{
    public string PhoneNumber { get; private set; }

    public PhoneNumberPaymentMethod(string phoneNumber) 
        : base(PaymentMethodType.PhoneNumber)
    {
        PhoneNumber = phoneNumber;
    }
}

public class CardPaymentMethod : PaymentMethod
{
    public string CardNumber { get; private set; }
    public string CardHolderName { get; private set; }
    public DateOnly IssueDate { get; private set; }

    public CardPaymentMethod(string cardNumber, string cardHolderName,
        DateOnly issueDate) : base(PaymentMethodType.Card)
    {
        CardNumber = cardNumber;
        CardHolderName = cardHolderName;
        IssueDate = issueDate;
    }
}

public class QiwiPaymentMethod : PaymentMethod
{
    public string PhoneNumber { get; private set; }
    public string AccountNumber { get; private set; }

    public QiwiPaymentMethod(string phoneNumber,
        string accountNumber) : base(PaymentMethodType.Qiwi)
    {
        PhoneNumber = phoneNumber;
        AccountNumber = accountNumber;
    }
}