
//Start 
//Deklarerar och inisierar 
string input = "0"; //Flagga
string age;
string antalBiljetter;
int antal;
int ungdom=0;    
int pensioner=0;    
int standardpris=0;
int total;


do
{
    //Visa meny minst en gång
    ShowMAinMenu();
    //Visar valet som är gjort
    Console.Write( "Ditt val: ");
    input = Console.ReadLine();
    Console.WriteLine(" ");
  
    //Oändlig loop som fortsätter tills input är satt till 0
    switch (input)
    {
        case "0": //lämnar programmet
            Console.WriteLine("Tack och adjö");
            Environment.Exit(0);          
            break;

        case "1": //Frågar efter åldern och sparar i age
            Console.Write("Hur gammal är biobesökaren: ");
            age = Console.ReadLine();
            PrintPriceInformation(CheckAge(age));   //Kallar på PrintPriceInformation skickar med CheckAge som kollar vilken kategori åldern hör till 0, 1 eller 2         
            break;

        case "2":
            Console.Write("Hur många biljetter vill du köpa?"); 
            antalBiljetter = Console.ReadLine();
            antal = FromStringToInt(antalBiljetter);
            for (int i = 1; i < antal+1; i++)
            {
                Console.Write("Hur gammal är biobesökare " + i + ": ");
                age= Console.ReadLine();
                CheckAge(age);              
            }
            int summa = CalcutateTotal(ungdom, pensioner, standardpris);
            PrintKvittens(summa, antal);        
            break;

        case "3":
            Console.Write("Skriv in valfri text: ");
            string text = Console.ReadLine();
            for (int i = 1; i < 11; i++)
            {
                Console.Write(i + "." + text + ", ");
            }
            break;

        case "4":
            Console.Write("Skriv in minst 3 ord: ");
            string words = Console.ReadLine();
            PrintTheThird(words);
            break;

        default:
            
            break;
    }
    } while(input != "0");

void PrintTheThird(string? words)
{
    string[] split = words.Split(' ');
    Console.WriteLine("Det tredje ordet är: " + split[2]);
}

void PrintKvittens(int summa, int antal)
{
    Console.WriteLine("****************************");
    Console.WriteLine($"    Antal personer: {antal}");
    Console.WriteLine($"    Total kostnad:  {summa} ");
    Console.WriteLine("****************************");
}

void PrintPriceInformation(int v) // skriver ut rätt text efter kategori samt nollställer räknarna på kategorierna
{
   if(v==0)
    {
        Console.WriteLine("Ungdomspris: 80 kronor"); 
    }
   else if(v==1)
    {
        Console.WriteLine("Pensionärspris: 90 kronor");
    }
   else
    {
        Console.WriteLine("Standardpris: 120 kronor");
    }
   ResetCount();    
}


void ResetCount()
{
    ungdom = 0;
    pensioner = 0;
    standardpris = 0;
}

int  CalcutateTotal(int ungdom, int pensioner, int standardpris)
{
    total = ungdom * 80 + pensioner * 90 + standardpris * 120;
    return total;
}

int FromStringToInt(string antalBiljetter)
{
    antal = int.Parse(antalBiljetter);
    return antal;
}

int CheckAge(string age) //Kollar vilken kategori åldern är i och räknar antal i varje kategori
{
    int theAge = int.Parse(age);

    if(theAge < 20)
    {
        ungdom++;
        return 0;   
    }
    else if(theAge >64) 
    {
        pensioner++;
        return 1;     
    }
    else
    {
        standardpris++;
        return 2;   
    }
}

void ShowMAinMenu()

{
    Console.WriteLine(" ");
    Console.WriteLine(" ");
    Console.WriteLine(" ");
    Console.WriteLine("*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*");
    Console.WriteLine(" ");
    Console.WriteLine("     HUVUDMENY ");
    Console.WriteLine(" ");
    Console.WriteLine("*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*");
    Console.WriteLine("*************************************************");
    Console.WriteLine("*   Skriv in en siffra för att välja en åtgärd: *");
    Console.WriteLine("*   0. Avsluta                                  *");
    Console.WriteLine("*   1. Vad kostar din biljett?                  *");
    Console.WriteLine("*   2. Antal biljetter                          *");
    Console.WriteLine("*   3. Loopad utskrift                          *");
    Console.WriteLine("*   4. Tredje ordet                             *");
    Console.WriteLine("*************************************************");
    Console.WriteLine("*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*");
}