namespace DDD_Factory_Repository.Customer;

public class CustomerRepository
{
    private List<Customer> _customers;

    public CustomerRepository()
    {
        _customers = new List<Customer>();
    }
    
    public CustomerRepository(params Customer[] customers)
    {
        _customers = new List<Customer>(customers);
    }

    public void AddCustomer(Customer customer)
    {
        if (customer == null || customer == default)
            throw new Exception("The customer is not defined");
        _customers.Add(customer);
    }

    public Customer GetCustomer(string id)
    {
        return _customers.Where(i => i.Id.Equals(id)).FirstOrDefault();
    }
    
    public void Update(Customer customer)
    {
        var dbCustomer = _customers.FirstOrDefault(c => c.Id == customer.Id);
        if (dbCustomer != null)
        {
            dbCustomer = customer;
        }
    }

    public void Delete(string id)
    {
        var customer = _customers.Where(i => i.Id.Equals(id)).FirstOrDefault();
        _customers.Remove(customer);
    }
}