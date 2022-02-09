public class Employee {

    string fName, lName;
    double Salary;

    public Employee(string fName, string lName, double Salary) {

        this.fName = fName;
        this.lName = lName;
        this.Salary = Salary;
    }

    public string first_name {
        
        get => fName;
        set => fName = value;
    }
    public string last_name {

        get => lName;
        set => lName = value;
    }
    public double salary {
        
        get => Salary;
        set {
            if(value < 0)
                Salary = 0.0;
            else 
                Salary = value;
        } 
        
    }

    public void giveRaise(float raise) {

        this.salary *= (1 + (raise/100));
    }

    public override string ToString() {

        return $"Employee name : {first_name} {last_name} \n Monthly Earning : {salary} Rs. \n Yearly Earning : {salary*12} Rs.";
    }
    
}