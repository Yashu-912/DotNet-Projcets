using System.Diagnostics;
internal class DelegateAndLambdaTest {

    internal delegate void Del(int bal);

    internal void printMsg(int bal) {

        if(bal < 0) 
            Console.Write("\n You are Overdrawn");
        else if(bal < 10) 
            Console.Write("\n Your balance in the account is very low");
        else if(bal < 100)
            Console.Write("\n Watch your spendings carefuly");
        else
            Console.Write("\n You have over 100$ in your bank account");

    }

    internal void callDelegate(int balance) {

        Del del = printMsg;
        
        del(balance);
    }

    internal void CallAnonymousMethod()

    {

        bool positive = new Func<int, bool>(delegate (int int32) { return int32 > 0; })(1);

        new Action<bool>(delegate (bool value) { Trace.WriteLine(value); })(positive);

    }

    internal void CallLambda()

    {

        bool positive = new Func<int, bool>(int32 => int32 > 0)(1);

        new Action<bool>(value => Trace.WriteLine(value))(positive);

    }

    internal void getNumber() {


        Console.Write("\n\n Without using Func<in , out> : ");

        var parse = (double x, double y) => ((x > y) ? x : y);

        Console.Write($"\n\n Greater number between 30 and 40 : {parse(30, 40)}");


        Console.Write("\n\n delegates using Func<in, out> ");

        Func<double, double, double> f_greater = (x, y) => {

            if(x > y)
                return x;
            else 
                return y;
        };

        Console.Write($"\n\n Larger number between 30 and 40 is : {f_greater(30, 40)}");



        Func<double, double, double> f_smaller = (x, y) => {

            if(x < y)  
                return x;
            else 
            return y;
        };

        Console.Write($"\n\n Smaller number between 30 and 40 is : {f_smaller(30, 40)}");



    }

    internal static void Test() {
        
        DelegateAndLambdaTest dlt = new DelegateAndLambdaTest();

        Console.Write("\n\n Enter the bank balance : ");
        int balance = Convert.ToInt32(Console.ReadLine());

        dlt.callDelegate(balance);


        dlt.CallAnonymousMethod();
        dlt.CallAnonymousMethod();


        dlt.getNumber();
    }


}