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
                    throw new Exception("\nVälj ett korrekt alternativ.\n");
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
            SkrivUtText("Welcome! I am not going to tell you who you are, because you know that already. Your goal is to " +
                "get out safe and alive. Good luck! \n\n" );

            SkrivUtText("Press any key to start");

            Console.ReadKey(true);
            Console.Clear();

            Start_Path();
        }

        public static void Start_Path()
        {
            SkrivUtText("The complete darkness surrounds you, and you feel a stinging pain in your head. Where are you? " +
                "This doesn't feel right.. The wooden floor you're laying on is cold and hard, maybe you better get up?");

            string[] val = new string[] { "Start shouting to get someones attention", "Get up and start exploring the " +
                "pitch black room" };
            PresenteraVal(val);

            PathChooser(Shout_Path, Explore_Path);
        }

        public static void Shout_Path()
        {

            SkrivUtText("'Hello, is anyone here!?'\n");

            SkrivUtText("The only response you receive is complete silence from the walls.");

            string[] val = new string[] {"Shout again", "Get up and start exploring the pitch black room" };
            PresenteraVal(val);

            PathChooser(Shout_again_Path, Explore_Path);
        }
        public static void Shout_again_Path()
        {
            SkrivUtText("'Hello!? Anyone here?! '\n");

            SkrivUtText("After a couple of seconds you begin to hear distant footsteps, and suddenly a small, small gap in " +
                "the door appears. The light from corridor outside blinds you for a moment, until you see a hand reaching " +
                "in. In the hand there is a glas of dark liquid.");

            SkrivUtText("'Take it, you need it', says a dark, old voice.");

            string[] val = new string[] { "Get up and take the liquid", "Ask the person what is happening" };
            PresenteraVal(val);

            PathChooser(Grab_Liquid_Path, Ask_For_Explanation_Path);
        }
        public static void Grab_Liquid_Path()
        {
            SkrivUtText("You rise from the cold floor and make your way to the door. Without a word you grab the glas " +
                "with the dark liquid. It looks disgusting.");

            SkrivUtText("'What is in it?' you ask.");

            SkrivUtText("'Just drink it' the person responds.");

            string[] val = new string[] { "Drink the dark, mysterious liquid", "Refuse to drink it" };
            PresenteraVal(val);

            PathChooser(Drink_Liquid_Path, Refuse_Liquid_Path);
        }
        public static void Ask_For_Explanation_Path()
        {
            SkrivUtText("You start exploring the pitch black room.");
        }

        public static void Explore_Path()
        {
            SkrivUtText("You rise from the cold floor and start exploring the room. There is no source of light in the " +
                "room, so all you can do is feel yourself forward. All of a sudden you bumb into a small, wooden table. " +
                "On it lays a small item, not bigger than the size of a finger. You belive it is made out of steel, but " +
                "have no idea what is it. ");

            string[] val = new string[] { "Take the item", "Leave the item on the table" };
            PresenteraVal(val);

            PathChooser(Keep_Item_Path, Leave_Item_Path);
        }
        public static void Drink_Liquid_Path()
        {
            SkrivUtText("Your body fights against your will when you pull the liquid closer to your lips. " +
                "With some hesitation you start swallowing the dark and disgusting liquid, bit for bit. " +
                "It only takes a couple of seconds, and you feel sick. The man starts laughing.");

            SkrivUtText("\n'What was in it?!' you scream hysterically");

            SkrivUtText("\n'Only a fool would drink that. You have proven yourself to be a fool. Now you " +
                "shall suffer the consequences and die. Game over.");

            SkrivUtText("\n\nGAME OVER. YOU HAVE DIED A FOOLS DEATH.");

            string[] val = new string[] { "Exit", "Play again" };
            PresenteraVal(val);

            PathChooser(Exit_Game, Play_Again);
        }
        public static void Refuse_Liquid_Path()
        {
            SkrivUtText("'I will not drink that, what do you think I am? A fool?'\nThe man starts smiling " +
                "weirdly. And then, all of a sudden, he pulls out a knife.\n'Come here!' the man yells.");

            string[] val = new string[] { "Throw the steel item at the man", "Stand your ground" };
            PresenteraVal(val);

            PathChooser(Throw_Item_Attack_Path, Fists_Path);
        }
        public static void Keep_Item_Path()
        {
            SkrivUtText("You begin exploring the other parts of the small room, tightly keeping the steel " +
                "item in your hand. There is nothing more in the room except for a massive steel door. All of" +
                "a sudden you begin hearing footsteps coming your way. You hide the small item in your hand and " +
                "back off from the door. Suddenly it opens and a man enters. The light from the corridor behind " +
                "him blinds you for a short moment, and then you realize the man is holding a glass of liquid in his " +
                "hand. A dark, mysterious liquid.\n'Drink this, it will be good for you', the man says");

            string[] val = new string[] { "Drink the dark, mysterious liquid", "Refuse to drink it" };
            PresenteraVal(val);

            PathChooser(Drink_Liquid_Path, Refuse_Liquid_Path);
        }
        public static void Leave_Item_Path()
        {
            SkrivUtText("You begin exploring the other parts of the small room, leaving the steel item on the table.");
        }
        public static void Fists_Path()
        {
            SkrivUtText("The man gets closer to you. You have to make a decision. Attack or Defend?");

            string[] val = new string[] { "Attack", "Defend" };
            PresenteraVal(val);

            PathChooser(Attack_Path, Defend_Path);
        }
        public static void Throw_Item_Attack_Path()
        {
            SkrivUtText("You begin exploring the other parts of the small room, leaving the steel item on the table.");
        }
        public static void Attack_Path()
        {
            SkrivUtText("You launch forward in an attempt to suprise the man, and you manage to successfully hit him right in his " +
                "face, and he stumbles back.");
            Console.ReadKey();
        }
        public static void Defend_Path()
        {
            SkrivUtText("You begin to back off into the room with your fists held high, but the man follows you.");

            string[] val = new string[] { "Grab the item off the table", "Wait for the man to attack" };
            PresenteraVal(val);

            PathChooser(Grab_Item_Path, Wait_For_Attack_Path);
        }
        public static void Grab_Item_Path()
        {
            return;
        }
        public static void Wait_For_Attack_Path()
        {
            return;
        }
        public static void Exit_Game()
        {
            return;
        }
        public static void Play_Again()
        {
            Start_Path();
        }
    }
}
