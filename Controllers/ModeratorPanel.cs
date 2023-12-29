public class ModeratorPanel : Panel
{
    public ModeratorPanel(User user, WeManageContext context) : base(user, context)
    {
        // Implementation specific to ModeratorPanel
    }

    public override void Process()
    {
        bool continueProcessing = true;

        while (continueProcessing)
        {
            Console.WriteLine("Choose an operation:");
            Console.WriteLine("1. Read Data");
            Console.WriteLine("2. Add Data");
            Console.WriteLine("3. Delete Data");
            Console.WriteLine("4. Update Data");
            Console.WriteLine("5. Exit");

            string? input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    var reader = new Reader(Context);
                    reader.Process();
                    break;
                case "2":
                    var adder = new Adder(Context);
                    adder.Process();
                    break;
                case "3":
                    var deleter = new Deleter(Context);
                    deleter.Process();
                    break;
                case "4":
                    // Assuming Updater class and its Process method are implemented similarly
                    var updater = new Updater(Context);
                    updater.Process();
                    break;
                case "5":
                    continueProcessing = false;
                    break;
                default:
                    Console.WriteLine("Invalid option, please try again.");
                    break;
            }

            if (continueProcessing)
            {
                Console.WriteLine("Do you want to continue in the Moderator Panel? (yes/no)");
                string? continueChoice = Console.ReadLine();
                Console.Clear();
                continueProcessing = continueChoice?.Trim().ToLower() == "yes";
            }
        }
    }
    
}
