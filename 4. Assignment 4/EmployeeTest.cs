
public class EmployeeTest {

    public static void TestEmployee() {

        Console.Write("\n\n *** For Employee class ***");

        

        Console.Write("\n\n *** Before raising the salary ***");        
        Employee emp_1 = new Employee("Sham", "Sharma", 30000);
        Employee emp_2 = new Employee("Ravish", "Kumar", 15000);
        Console.Write("\n\n " + emp_1.ToString());
        Console.Write("\n\n " + emp_2.ToString());



        Console.Write("\n\n *** After raising the salary ***");
        emp_1.giveRaise(10);
        emp_2.giveRaise(10);
        Console.Write("\n\n " + emp_1.ToString());
        Console.Write("\n\n " + emp_2.ToString());



        Console.Write("\n\n *** For Permenant Employee ***");
        PermanentEmployee p_emp = new PermanentEmployee("Yash", "Parekh", 70000, new DateOnly(2023, 1, 9), new DateOnly(2033, 1, 9));



        Console.Write("\n\n *** Before Raising Salary ***");
        Console.Write($"\n\n {p_emp.ToString()}");
        p_emp.CalculateFinalSalary();



        Console.Write("\n\n *** After Raising salary ***");   
        p_emp.giveRaise(10);
        Console.Write($"\n\n {p_emp.ToString()}");
        p_emp.CalculateFinalSalary();

    }
}