using System;

namespace ExceptionHandlingAbuse
{
    class Program
    {
        //Here we are using exception handling to implement logical flow:
        /* public static void Main()
         {
             try
             {
                 //Convert.ToInt32() can throw FormatException, if the entered value
                 //cannot be converted to integer. So use int.TryParse() instead
                 Console.WriteLine("Please enter First Number");
                 int FNO = Convert.ToInt32(Console.ReadLine());
                 Console.WriteLine("Please enter Second Number");
                 int SNO = Convert.ToInt32(Console.ReadLine());
                 int Result = FNO / SNO;
                 Console.WriteLine("Result = {0}", Result);
             }
             catch (FormatException)
             {
                 Console.WriteLine("Only numbers are allowed!");
             }
             catch (OverflowException)
             {
                 Console.WriteLine("Only numbers between {0} & {1} are allowed",
                     Int32.MinValue, Int32.MaxValue);
             }
             catch (DivideByZeroException)
             {
                 Console.WriteLine("Secoond Number cannot be zero");
             }
             catch (Exception ex)
             {
                 Console.WriteLine(ex.Message);
             }
             Console.ReadLine();
         }*/
        //Preventing exception handling abuse in C#:
        public static void Main()
        {
            try
            {
                Console.WriteLine("Please enter First Number");
                int FNO;
                //int.TryParse() will not throw an exception, instead returns false
                //if the entered value cannot be converted to integer
                bool isValidFNO = int.TryParse(Console.ReadLine(), out FNO);
                if (isValidFNO)
                {
                    Console.WriteLine("Please enter Second Number");
                    int SNO;
                    bool isValidSNO = int.TryParse(Console.ReadLine(), out SNO);

                    if (isValidSNO && SNO != 0)
                    {
                        int Result = FNO / SNO;
                        Console.WriteLine("Result = {0}", Result);
                    }
                    else
                    {
                        //Check if the second number is zero and print a friendly error
                        //message instead of allowing DivideByZeroException exception 
                        //to be thrown and then printing error message to the user.
                        if (isValidSNO && SNO == 0)
                        {
                            Console.WriteLine("Second Number cannot be zero");
                        }
                        else
                        {
                            Console.WriteLine("Only numbers between {0} && {1} are allowed",
                                Int32.MinValue, Int32.MaxValue);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Only numbers between {0} && {1} are allowed",
                                Int32.MinValue, Int32.MaxValue);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }
    }
}
