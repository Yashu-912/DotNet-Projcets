
public class Numbers {

    public void IntegerOperation() {

        int a = 188;
        int b = 6;

        int add = a + b;
        int sub = a - b;
        int mul = a * b;
        int div = a / b;

        int order = a + b*add;
        int bracket = (b + a)*div;

        int complex = (a + b) - 6 * div + (12 * 4) / 3 + 12;


        Console.WriteLine($"\n Addition : {add}");
        Console.WriteLine($"\n Substraction : {sub}");
        Console.WriteLine($"\n Multiplication : {mul}");
        Console.WriteLine($"\n Division : {div}");
        Console.WriteLine($"\n Order : {order}");
        Console.WriteLine($"\n Bracket : {bracket}");
        Console.WriteLine($"\n Complex operation : {complex}");
        
        Console.WriteLine("\n Min Value of INT : " + int.MinValue);
        Console.WriteLine("\n Max Value of INT : " + int.MaxValue);

        Console.WriteLine("\n Overflow value : cannot be displayed as it shows compile time error");
        
        
    }

    public void DoubleOperation() {

        double a = 5;
        double b = 4;
        double c = 2;
        double d = (a + b) / c;

        Console.WriteLine("\n D : " + d);
        Console.WriteLine("\n Double Min : " + double.MinValue);
        Console.WriteLine("\n Double Max : " + double.MaxValue);

        double third = 1.0 / 3.0;

        Console.WriteLine($"\n Third : {third}");
    }

    public void DecimalOperation() {

        decimal min = decimal.MinValue;
        decimal max = decimal.MaxValue;

        Console.WriteLine($"\nThe range of the decimal type is {min} to {max}");

        double a = 1.0;
        double b = 3.0;
        Console.WriteLine("\n Normal double : " + (a / b));

        decimal c = 1.0M;
        decimal d = 3.0M;
        Console.WriteLine("\n decimal : " + (c / d));

        decimal PI = (decimal)(Math.PI);
        Console.WriteLine($"\n Value of PI : {PI}");
        
    }
}