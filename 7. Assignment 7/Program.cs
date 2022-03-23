using System;
using System.Collections.Generic;
using System.Linq;

public class Program {

    public static void Main() {


        Customer[] c = new Customer[10];

        c[0] = new Customer { Customerid = "A1", City = "London" };
        c[1] = new Customer { Customerid = "A2", City = "NewYork" };
        c[2] = new Customer { Customerid = "B1", City = "Moscow" };
        c[3] = new Customer { Customerid = "B2", City = "London" };
        c[4] = new Customer { Customerid = "C1", City = "London" };
        c[5] = new Customer { Customerid = "C21", City = "Delhi" };
        c[6] = new Customer { Customerid = "D3", City = "Surat" };
        c[7] = new Customer { Customerid = "A10", City = "London" };
        c[8] = new Customer { Customerid = "A19", City = "Kathmandu" };
        c[9] = new Customer { Customerid = "E42", City = "Thimphu" };
        

        List<Customer> custList = new List<Customer>(10);

        for(int i = 0; i < c.Length; i++) {

            custList.Add(c[i]);
            
        }


        IEnumerable<Customer> fromlondon = from cust in custList
                                            where cust.City == "London"
                                            select cust;


        IEnumerable<Customer> starts_ID_with_A = from cust in custList 
                                                where cust.Customerid.StartsWith('A')
                                                select cust;
                                            
        
        Console.WriteLine("\n The list of Customer from london is : \n\n");

        foreach(Customer cust in fromlondon) {

            Console.WriteLine(cust.ToString());
        }


        Console.WriteLine($"\n The Total number of customer are : {custList.Count()}\n\n");

        Console.WriteLine("\n The list of Customer whose ID starts with A is : \n\n");

        foreach(Customer cust in starts_ID_with_A) {

            Console.WriteLine(cust.ToString());
        }

        

    }
}