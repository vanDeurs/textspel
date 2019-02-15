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
                    line = "";
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
            SkrivUtText("Welcome! I am not going to tell you who you are, because you know that. Your goal is to escape the building in which you are being captured. Good luck. \n\n" );

            SkrivUtText("Press any key to start");

            Console.ReadKey(true);
            Console.Clear();

            Start_Path();
        }

        public static void Start_Path()
        {
            SkrivUtText("The complete darkness surrounds you, and you feel a stinging pain in your head. Where are you? This doesn't feel right.. The" +
                " wooden floor you're laying on is cold and hard, maybe you better get up?");

            string[] val = new string[] { "Start shouting to get someones attention", "Get up and start exploring the pitch black room" };
            PresenteraVal(val);

            PathChooser(Shout_Path, Explore_Path);
        }

        public static void Shout_Path()
        {

            SkrivUtText("'Hello, is anyone here!?'\n\n");
            SkrivUtText("The only response is silence..");
            string[] val = new string[] {"Shout again", "Get up and start exploring the pitch black room" };
            PresenteraVal(val);

            PathChooser(Shout_again_Path, Explore_Path);
        }
        public static void Shout_again_Path()
        {
            SkrivUtText("'Hello!? Anyone here?! '\n\n");
            SkrivUtText("After a couple of seconds you begin to hear distant footsteps, but after a couple of seconds the footsteps stops. " +
                "Suddenly you hear a metallic sound, and a small, small gap in the door appears. The light from the room or corridor outside blinds you " +
                "for a moment, until you see a hand reaching in. In the hand there is a glas of dark liquid.");
            SkrivUtText("'Take it', says a dark, old voice.");

            string[] val = new string[] { "Get up and take the liquid", "Ask the person what is happening" };
            PresenteraVal(val);

            PathChooser(Grap_Liquid_Path, Ask_For_Explanation_Path);
        }
        public static void Grap_Liquid_Path()
        {
            SkrivUtText("You rise from the cold floor and make your way to the door. Without a word you grab the glas with the dark liquid. It looks disgusting.");
            SkrivUtText("'What is in it?' you ask.");
            SkrivUtText("'Just drink it' the person responds.");

            string[] val = new string[] { "Drink the dark, mysterious liquid", "Ask again what the liquid is" };
            PresenteraVal(val);

            PathChooser(Grap_Liquid_Path, Ask_For_Explanation_Path);
        }
        public static void Ask_For_Explanation_Path()
        {
            SkrivUtText("You start exploring the pitch black room.");
        }

        public static void Explore_Path()
        {
            SkrivUtText("You start exploring the pitch black room.");
        }
        public static void GörDigiOrdning_Path()
        {
            Console.WriteLine("För några minuter så händer ingenting.");
        }
    }
}
