namespace EMSRecord
{
    public class ConsolePrintService : IPrintService
    {
        public void Print(string message)
        {
            Console.WriteLine(message);
        }

        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }




}