using System;

namespace ExceptionHandlingAbuse
{
    class Program
    {
        //Here we are using exception handling to implement logical flow:
        public static void Main()
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
        }
    }
}
