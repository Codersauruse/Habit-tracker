namespace Habit_Logger
{
    internal class Program
    {
        private static String habitName;
        private static String year, month, day, time;
        private  static DatabaseConnection db  = new DatabaseConnection();
        static void Main(string[] args)
        {
            App();
            

        }
        //Basic running application.
        public static void  App()
        {
            String userInput;
            Console.WriteLine("..........Hello Welcome To The Habbit Logger..........\n\n");
            Console.WriteLine("MAIN MENU\n\n");
            while (true) 
            {
                
                Console.WriteLine("What do you like to do :");
                Console.WriteLine("--------------------------\n");
                Console.WriteLine("Type \"0\" to exit :\nType \"v\" to View All Habits :\n" +
                    "Type \"a\" to add a Habit :\nType \"d\" to delete a Habit :\n"+
                  "Type \"u\" to update a Habit :\n\n");
                Console.Write("Enter your choice :");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "0":
                        Environment.Exit(0);
                        break;
                    case "a":
                        addhabit();
                        break;
                    case "d":
                        deletehabit();
                        break;
                    case "u":
                        updatehabit();
                        break;
                    case "v":
                        viewhabit();
                        break;

                }

            }

        }
        public static void addhabit() {
            Console.Write("enter the habit name :");
            habitName = Console.ReadLine();
            Console.Write("enter the current year :");
            year = Console.ReadLine();
            Console.Write("enter the current month :");
            month = Console.ReadLine();
            Console.Write("enter the current day :");
            day = Console.ReadLine();
            Console.Write("enter the Allocated time for the habit in minutes(ex:- 60) :");
            time = Console.ReadLine();
            DateTime startDate = new DateTime(Convert.ToInt32(year), Convert.ToInt32(month), Convert.ToInt32(day));
            db.insertdata(habitName,startDate,Convert.ToInt32(time));




        }
        public static void deletehabit() {
            Console.Write("enter the habit name :");
            habitName = Console.ReadLine();
            db.deletedata(habitName);

        }
        public static void updatehabit() {
            bool flag = false;
         
                Console.Write("enter the habit name :");
                habitName = Console.ReadLine();

            Console.Write("Do you want to end the habit (yes or no):");
            string desc  = Console.ReadLine();
            flag =  (desc.Equals("yes"))? true : false;
            DateTime endDate;
            int progress = 0;
            if (flag)
            {
                
                endDate = DateTime.Now;
                db.updateData(habitName, endDate, progress);
               
                
            }
            

        }

        public static void viewhabit() {
            db.ViewData();
        
        }
    }
    
}
