public class PermanentEmployee : Employee {

    readonly double HRA = 10;
    readonly double DA = 10;
    readonly double PF = 5;

    DateOnly j_date, r_date;

    public PermanentEmployee(string fName, string lName, double Salary, DateOnly j_date, DateOnly r_date) : base(fName, lName, Salary) {

        this.j_date = j_date;
        this.r_date = r_date;
    } 

    public DateOnly join_date {

        get => j_date;
        set => j_date = value;
    }

    public DateOnly retire_date {

        get => r_date;
        set => r_date = value;
    }


    public void CalculateFinalSalary() {

        double f_sal = salary*(1 + HRA/100 + DA/100 - PF/100);
        Console.Write($"\n Employee Name : {first_name} {last_name} \n Final Salary per Annum :  {f_sal} Rs.");

    }

    public new void giveRaise(float raise) {

        this.salary *= (1 + (raise/100));
    }

    public override string ToString()
    {
        return $"\n The Permanent Employee Name : {first_name} {last_name} \n Join Date :  {join_date} \n Retirenment Date : {retire_date} \n Salary per Annum : {salary} Rs.";
    }


}