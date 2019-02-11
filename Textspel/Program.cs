using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Textspel
{
    class Program
    {
        // Presenterar användarens val 
        public static void PresenteraVal(string[] val)
        {
            for (int i = 0; i < val.Length; i++)
            {
                Console.WriteLine( " " + (i + 1) + ": " + val[i]);
            }
        }

        // Formaterar och skriver ut text
        public static void SkrivUtText(string text)
        {
            int myLimit = 75;
            string[] words = text.Split(' ');

            StringBuilder newSentence = new StringBuilder();
       

            string line = "";
            foreach (string word in words)
            {
                if ((line + word).Length > myLimit)
                {
                    newSentence.AppendLine(line);
                    line = " ";
                }

                line += string.Format("{0} ", word);
            }

            if (line.Length > 0)
                newSentence.AppendLine(line);

            Console.WriteLine(" " + newSentence.ToString());
        }

        // Väljer path för användaren baserat på input
        public static void PathFinder(Action path1, Action path2, ConsoleKeyInfo svar)
        {
            string svarString = svar.KeyChar.ToString();
            switch (svarString)
            {
                case "1":
                    path1();
                    break;

                case "2":
                    path2();
                    break;

                default:
                    throw new Exception(" Välj ett korrekt alternativ.");
            }
        }

        public static void PathChooser (Action path1, Action path2)
        {
            while (true)
            {
                try
                {
                    ConsoleKeyInfo svar = Console.ReadKey(true);
                    PathFinder(path1, path2, svar);
                }
                catch (Exception error)
                {
                    Console.WriteLine(error.Message);
                }
            }
        }

        public static void Start()
        {

            SkrivUtText("Du vaknade upp tidigt denna morgon. Solen hade fortfarande inte gått upp, och den kyliga vinden hördes utanför stenväggarna. " +
                 "Plötsligt ser du en skugga vid dörren.\n 'Ewe, är det du?' ropar du.\n Inget svar.");

            string[] val = new string[] { "Ropa igen på 'Ewe'", "Ligg kvar och se vad som händer" };
            PresenteraVal(val);

            PathChooser(Ropa, Vänta);
        }

        static void Main(string[] args)
        {
            SkrivUtText("Välkommen till mitt spel. Jag föreslår att du spelar det i ett mörkt, tyst rum. Jag kommer inte att berätta för dig vem du är. " +
               "Den enda ledtråd jag kommer ge dig är att det är tidigt 1800- tal i Romanien. " +
              "Du befinner dig i ett kloster. \n\n" );

            SkrivUtText("Pressa valfri tangent när du är redo att börja.");
            Console.ReadKey(true);
            Console.Clear();

            Start();
        }

        public static void Ropa()
        {

            SkrivUtText(" 'Hallå, Ewe är det du?'\n\n\n Plötsligt försvann skuggan utan att ge ifrån sig ett ljud. Vad i..");
            string[] val = new string[] {" Gå upp och följ efter skuggan", " Gå upp och gör dig i ordning"};
            PresenteraVal(val);

            PathChooser(GåUpp, GörDigiOrdning);

        }
        public static void Vänta()
        {

            Console.WriteLine("För några minuter så händer ingenting.");
        }
        public static void GåUpp()
        {

            SkrivUtText("Du går upp och börjar göra dig i ordning. Du tänker inte så mycket på skuggan, det kunde ju har varit vad som helst? Nu var det dags för morgonbönen.");
        }
        public static void GörDigiOrdning()
        {

            Console.WriteLine("För några minuter så händer ingenting.");
        }
        public static string GömDigBakomTrädet()
        {

            Console.WriteLine("Göm dig bakom trädet!");
            return "LUL";
        }
    }
}
