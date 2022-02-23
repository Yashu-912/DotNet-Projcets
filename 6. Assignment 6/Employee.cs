public enum Designations {
    
    
    BA = 1,
    SDE,
    PM,
    CFO,
    CEO
}


class Employee {
    int empid;
    float salary;
    public string name;
    Designations designation;

    public Employee(int empid, float salary, string name, Designations designation) {

        this.empid = empid;
        this.salary = salary;
        this.name = name;
        this.designation = designation;
    }

    internal static bool CompareBySalary(Employee e1, Employee e2) {
        
        return e1.salary >= e2.salary;
    }

    internal static bool CompareByNames(Employee e1, Employee e2) {
        
        return (e1.name.CompareTo(e2.name) >= 0) ? (true) : (false);
    }

    internal static bool CompareByDesignations(Employee e1, Employee e2) {
    
        return e1.designation >= e2.designation;
    }

    internal static bool CompareByID(Employee e1, Employee e2) {
        return e1.empid >= e2.empid;
    }

    internal void display() {

        Console.Write($"\n\n Employee Id : {empid}");
        Console.Write($"\n Employee Name : {name}");
        Console.Write($"\n Employee Salary : {salary}");
        Console.Write($"\n Employee Designation : {designation.ToString()}");
        
    }
}