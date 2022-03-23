public class Customer {

    public string Customerid { get; set; }

    public string City { get; set; }

    public override string ToString()
    {
        return Customerid + "\t" + City;
    }
}