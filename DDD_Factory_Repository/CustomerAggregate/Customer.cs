namespace DDD_Factory_Repository.Customer;

public class Customer
{
    public string Id { get; private set; }
    public string Name { get; private set; }
    public List<PaymentMethod> PaymentMethods { get; private set; }
    
    private Customer(string name)
    {
        Id = new Random().Next(0, Int32.MaxValue).ToString();
        Name = name;
        PaymentMethods = new List<PaymentMethod>();
    }
    
    public void AddPaymentMethod(PaymentMethod paymentMethod)
    {
        PaymentMethods.Add(paymentMethod);
    }
    
    public override string ToString()
    {
        return $"Customer ID: {Id}, Name: {Name}";
    }
    
    public class CustomerFactory
    {
        public Customer Create(PaymentMethod paymentMethod, string name)
        {
            var customer = new Customer(name);
            customer.AddPaymentMethod(paymentMethod);
            
            return customer;
        }
    }
}