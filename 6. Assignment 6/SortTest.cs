internal class InsertionSortTest {

    internal static void Test() {

        List<Employee> list = new List<Employee>();

        list.Add(new Employee(2, 100000, "Jignes", Designations.PM));
        list.Add(new Employee(4, 80000, "Mahes", Designations.BA));
        list.Add(new Employee(1, 150000, "Sures", Designations.CEO));
        list.Add(new Employee(5, 70000, "Rames", Designations.SDE));
        list.Add(new Employee(3, 95001, "Kamles", Designations.CFO));
        
        
        Console.Write("\n\n _____________Comparing by ID_____________");

        InsertionSort.Sort<Employee>(list, Employee.CompareByID);

        foreach(Employee emp in list) 
            emp.display();



        Console.Write("\n\n ____________Comparing by Name____________");

        InsertionSort.Sort<Employee>(list, Employee.CompareByNames);

        foreach(Employee emp in list) 
            emp.display();



        Console.Write("\n\n ___________Comparing by Salary___________");

        InsertionSort.Sort<Employee>(list, Employee.CompareBySalary);

        foreach(Employee emp in list) 
            emp.display();


        
        Console.Write("\n\n ________Comparing by Designation_________");

        InsertionSort.Sort<Employee>(list, Employee.CompareByDesignations);
        

        foreach(Employee emp in list) 
            emp.display();
        
    }
}