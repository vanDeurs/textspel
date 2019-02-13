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
                Console.WriteLine((i + 1) + ": " + val[i]);
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

            Console.WriteLine(newSentence.ToString());
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
                    throw new Exception("Välj ett korrekt alternativ.");
            }
        }

        // Läser in användarens val och passar det vidare
        // till PathFinder om inputen är valid
        public static void PathChooser (Action path1, Action path2)
        {
            while (true)
            {
                try
                {
                    ConsoleKeyInfo svar = Console.ReadKey(true);
                    Console.Clear();

                    PathFinder(path1, path2, svar);
                    break;
                }
                catch (Exception error)
                {
                    Console.WriteLine(error.Message);
                }
            }
        }

        // Presenterar pre-story för användaren
        // och startar spelet
        static void Main(string[] args)
        {
            SkrivUtText("Välkommen till mitt spel. Jag föreslår att du spelar det i ett mörkt, tyst rum. Jag kommer inte att berätta för dig vem du är." +
               "Den enda ledtråd jag kommer ge dig är att det är tidigt 1800- tal i Romanien." +
              "Du befinner dig i ett kloster. \n\n" );

            SkrivUtText("Pressa valfri tangent när du är redo att börja.");

            Console.ReadKey(true);
            Console.Clear();

            Start_Path();
        }

        public static void Start_Path()
        {
            SkrivUtText("Du vaknade upp tidigt denna morgon. Solen hade fortfarande inte gått upp, och den kyliga vinden hördes utanför stenväggarna. " +
                 "Plötsligt ser du en skugga vid dörren.\n 'Ewe, är det du?' ropar du.\n Inget svar.");

            string[] val = new string[] { "Ropa igen på 'Ewe'", "Ligg kvar och se vad som händer" };
            PresenteraVal(val);

            PathChooser(Ropa_Path, Vänta_Path);
        }

        public static void Ropa_Path()
        {

            SkrivUtText("'Hallå, Ewe är det du?'\n\n\nPlötsligt försvann skuggan utan att ge ifrån sig ett ljud. Vad i..");
            string[] val = new string[] {"Gå upp och följ efter skuggan", "Gå upp och gör dig i ordning"};
            PresenteraVal(val);

            PathChooser(GåUpp_Path, GörDigiOrdning_Path);

        }
        public static void Vänta_Path()
        {
            Console.WriteLine("För några minuter så händer ingenting.");
        }
        public static void GåUpp_Path()
        {
            SkrivUtText("Du går upp och börjar göra dig i ordning. Du tänker inte så mycket på skuggan, det kunde ju har varit vad som helst? Nu var det dags för morgonbönen.");
        }
        public static void GörDigiOrdning_Path()
        {
            Console.WriteLine("För några minuter så händer ingenting.");
        }
    }
}
