
namespace Pesel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Program pyta się o imię
            Console.WriteLine("Imię:");
            string imie = Console.ReadLine();
            //Program pyta się o nazwisko
            Console.WriteLine("Nazwisko:");
            string nazwisko = Console.ReadLine();
            //Program pyta się o Pesel
            Console.WriteLine("Pesel:");
            string pesel = Console.ReadLine();

            int rok = int.Parse(pesel.Substring(0, 2));
            int rokprawdziwy;
            //Program sprawdza czy osoba jest z okresu  przed lub po 2000 roku
            if (rok < 24)
            {
                rokprawdziwy = rok + 2000;
            }
            else
            {
                rokprawdziwy = rok + 1900;
            }
            //Program oblicza wiek osoby 
            int wiek = DateTime.Today.Year - rokprawdziwy;
            //Program sprawdza jakiej płci jest osoba
            string plec = int.Parse(pesel[9].ToString()) % 2 == 0 ? "Kobieta" : "Mezczyzna";
            //Program sprawdza czy istnieje plik txt a jak nie to go tworzy i dodaje do niego dane
            if (!File.Exists("Peselczajadane.txt"))
            {
                using (StreamWriter sw = new StreamWriter("Peselczajadane.txt"))
                {
                    sw.WriteLine(imie + ", " + nazwisko + ", " + pesel + ", " + wiek + ", " + plec);
                }
            }
            //Jeżeli plik istnieje to program dodaje do niego te dane
            else
            {
                using (StreamWriter sw = File.AppendText("Peselczajadane.txt"))
                {
                    sw.WriteLine(imie + ", " + nazwisko + ", " + pesel + ", " + wiek + ", " + plec);
                }
            }

            string line = "";
            //Program wczytuje dane z pliku txt i je wypisuje
            using (StreamReader sr = new StreamReader("Peselczajadane.txt"))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
        }
    }
}