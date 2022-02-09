
class Time {

    internal double seconds;
    internal double Hours {

        get { return seconds/3600;}
        set {

            if(value < 0 || value > 24)
                throw new ArgumentOutOfRangeException($"{nameof(value)} must be between 0 and 24.");

            seconds = value*3600;
        }
    }
}

class Person {

    private string firstname;
    private string lastname;

    internal Person(string f_name, string l_name) {

        firstname = f_name;
        lastname = l_name;
    }
    internal string Name => $"{firstname} {lastname}";

}

class SaleItem {

    private string _name;
    private double _cost;

    internal SaleItem(string name, double cost) {

        _name = name;
        _cost = cost;
    }

    internal string Name {

        get => _name;
        set => _name = value;
    }
    internal double Cost {

        get => _cost;
        set {

            if(value < 0)
                _cost = 0;

            _cost = value;
        }
    }
}

class AutoImpMethodProperty {

   internal string? _Name
   { get; set; }

   internal decimal _Price
   { get; set; }

}

public class PropertiesTest {

    public static void TestProperties() {

        Console.Write("\n\n *** Testing Properties ***");



        Console.Write("\n\n *** Using basic Properties ***");
        Time t = new Time();
        t.seconds = 25000;
        Console.Write($"\n\n Time in Seconds : {t.seconds} S");
        Console.Write($"\n Time in Hours : {t.Hours} h");



        Console.Write("\n\n *** Properties using expression body definition ***");
        Person p = new Person("Yash", "Parekh");
        Console.Write($"\n\n Full Name : {p.Name}");



        Console.Write("\n\n *** get set properties ***");
        SaleItem si = new SaleItem("Tooth-Brush", 25);
        Console.Write($"\n\n Item : {si.Name} \n Cost : {si.Cost}");



        Console.Write("\n\n *** Auto Implementation method ***");
        AutoImpMethodProperty aimp = new AutoImpMethodProperty{ _Name = "Bucket", _Price = 250};
        Console.Write($"\n\n Item : {aimp._Name} \n Price : {aimp._Price}");

    }
}