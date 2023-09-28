using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace Concession
{
    public class ConcessionCalculator
    {
        static double amount;
        public static double totalF = 2500;
        public double concessionAmount(int age)
        {
            if (age <= 5)
            {
                Console.WriteLine("Little Champs - Free Ticket!");
                totalF = 0;
            }
            else if (age > 60)
            {
                Console.WriteLine("Senior Citizen");
                totalF *= 0.7;
            }
            return totalF;
        }

        public void showUserDetails(string name, int age)
        {
            string stringDetails = $"Name: {name}, Age: {age}, Fare: {totalF}";
            Console.WriteLine(stringDetails);
        }
        public void showOfThanks()
        {
            MessageBox.Show("Ticket Booked Successfuly");
        }
    }
}
