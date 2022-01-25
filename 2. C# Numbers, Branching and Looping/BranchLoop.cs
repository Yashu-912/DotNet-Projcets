public class BranchLoop {

    public void IFELSE() {

        int a = 5;
        int b = 6;
        if (a + b > 10)
            Console.WriteLine("\n The answer is greater than 10.");
        
        b = 3;

        if (a + b > 10)
            Console.WriteLine("\n The answer is greater than 10.");
        else 
            Console.WriteLine("\n The Answer is less than 10");

        
    }
    
    public void ANDOperator() {

        int a = 5;
        int b = 3;
        int c = 4;
        
        if ((a + b + c > 10) && (a == b)) {
            Console.WriteLine("\n The answer is greater than 10");
            Console.WriteLine("\n And the first number is equal to the second");
        }
        else {
            Console.WriteLine("\n The answer is not greater than 10");
            Console.WriteLine("\n Or the first number is not equal to the second");
        }
    }

    public void OROperator() {

        int a = 5;
        int b = 3;
        int c = 4;
        
        if ((a + b + c > 10) || (a == b)) {
            Console.WriteLine("\n The answer is greater than 10");
            Console.WriteLine("\n Or the first number is equal to the second");
        }
        else {
            Console.WriteLine("\n The answer is not greater than 10");
            Console.WriteLine("\n And the first number is not equal to the second");
        }

    }

    public void looping() {

        int counter = 0;

        while (counter < 10) {
            Console.WriteLine($"\n This is While! The counter is {counter}");
            counter++;
        }

        counter = 0;
        
        do {
        
            Console.WriteLine($"\n This is Do While! The counter is {counter}");
            counter++;

        } while (counter < 10);


        for(int c = 0; c < 10; c++)
        {
            Console.WriteLine($"\n This is For loop! The counter is {c}");
        }

        Console.WriteLine("\n Starting a nested for loop with rows 1-11 and cols a-k"); 

        for (int row = 1; row < 11; row++)
        {
            for (char column = 'a'; column < 'k'; column++)
            {
                Console.WriteLine($"The cell is ({row}, {column})");
            }
        }
    }

    public void SumDivisableBy3() {

        int sum = 0;

        for(int i = 0; i < 20; i++) {

            if(i%3 == 0) {
                sum += i;
                Console.WriteLine($"{i} ");
            }
        }

        Console.WriteLine("\n The final sum is " + sum);   
    }
}