public class DivisionDisplay {
    
    public void DoTheMath() {

        int num, denom, remainder, quotient;
        float div;

        Console.Write("\n Enter the Numerator : ");
        num = Convert.ToInt32(Console.ReadLine());

        Console.Write("\n Enter the denominator : ");
        denom = Convert.ToInt32(Console.ReadLine());

        remainder = num % denom;
        div = (float)num/denom;
        quotient = num/denom;

        Console.Write("\n The Integer division result is : " + quotient + " with remainder : " + remainder);
        Console.Write("\n The floating point result is : " + div);
        Console.Write("\n The Mixed Fraction is : " + quotient + " " + remainder + "/" + denom);
        Console.Write("\n\n");
        
    }
}