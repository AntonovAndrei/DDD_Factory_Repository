using DDD_Factory_Repository.Customer;

namespace DDD_Factory_Repository.Order;

public class Order
{
    public string Id { get; private set; }
    public Customer Customer { get; private set; }
    public DateTime OrderDate { get; private set; }
    public OrderStatus Status { get; private set; }
    public List<Product> Products { get; private set; }
    public Address ShippingAddress { get; private set; }

    private Order()
    {
        Id = Guid.NewGuid().ToString();
        Status = OrderStatus.Created;
        OrderDate = DateTime.Now;
        Products = new List<Product>();
    }
    
    private Order(Customer customer): this()
    {
        Customer = customer;
    }
    
    public void AddProduct(Product product)
    {
        Products.Add(product);
    }

    public void SetShippingAddress(Address address)
    {
        ShippingAddress = address;
    }

    public void SetStatus(OrderStatus status)
    {
        Status = status;
    }
    
    public override string ToString()
    {
        return $"Order ID: {Id}, Customer: {Customer}, Order Date: {OrderDate}, Status: {Status}";
    }
    
    public class OrderFactory
    {
        public Order Create(Customer customer)
        {
            var order = new Order(customer);
            return order;
        }
    }
}