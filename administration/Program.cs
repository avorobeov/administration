using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace administration
{
    class Program
    {
        static void Main(string[] args)
        {
            Database database = new Database();

            string crime = "Антиправительственное";

            database.ShowListCriminals();
            
            database.AmnestyCriminal(crime);
           
            database.ShowListCriminals();

            Console.ReadKey();
        }
    }

    class Criminal
    {
        public string Surname { get; private set; }
        public string Name { get; private set; }
        public string Patronymic { get; private set; }
        public string Crime { get; private set; }
        
        public Criminal(string surname, string name, string patronymic,string crime)
        {
            Surname = surname;
            Name = name;
            Patronymic = patronymic;
            Crime = crime;
        }
    }

    class Database
    {
        private List<Criminal> _criminals = new List<Criminal>();

        public Database()
        {
            _criminals.Add(new Criminal("Агеев", "Матвей", "Иванович", "Антиправительственное"));
            _criminals.Add(new Criminal("Агеев", "Михаил", "Львович", "Антиправительственное"));
            _criminals.Add(new Criminal("Агеева", "Дарья", "Антоновна", "Разбой"));
            _criminals.Add(new Criminal("Акимов", "Владимир", "Ильич", "Разбой"));
            _criminals.Add(new Criminal("Акимова", "Мия", "Михайловна", "Разбой"));
            _criminals.Add(new Criminal("Александрова", "Вероника", "Матвеевна", "Антиправительственное"));
            _criminals.Add(new Criminal("Алексеев", "Роман", "Ильич", "Разбой"));
            _criminals.Add(new Criminal("Андреева", "Виктория", "Тимофеевна", "Разбой"));
            _criminals.Add(new Criminal("Антипов", "Всеволод", "Иванович", "Антиправительственное"));
            _criminals.Add(new Criminal("Антонов", "Николай", "Матвеевич", "Разбой"));
        }

        public void AmnestyCriminal(string crime)
        {
            _criminals = _criminals.Where(criminal => criminal.Crime != crime).ToList();
        }

        public void ShowListCriminals()
        {
            ShowMessage("\n\n\nСписок преступников\n\n\\n", ConsoleColor.Green);

            foreach (Criminal criminal in _criminals)
            {
                ShowMessage($"\n{criminal.Surname} {criminal.Name} {criminal.Patronymic} ", ConsoleColor.Red);
            }
        }

        private void ShowMessage(string message, ConsoleColor color)
        {
            ConsoleColor preliminaryColor = Console.ForegroundColor;

            Console.ForegroundColor = color;
            Console.WriteLine(message + "\n");

            Console.ForegroundColor = preliminaryColor;
        }
    }
}
