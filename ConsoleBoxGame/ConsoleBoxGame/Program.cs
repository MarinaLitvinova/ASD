using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Resources;
using System.Drawing;
using System.Threading;

namespace ConsoleBoxGame
{
    class Program {
        static void Main(string[] args) {
            Game game = new Game();
            while (game.loop() == 0) {}
            Console.Clear();

            if (game.gameResult == 1) {
                Console.Write("GAME OVER! YOU LOSE");
            } else {
                Console.Write("GAME OVER! YOU WIN");
            }
            Console.ReadKey();
        }
    }

    class Game {
        static void write(String text) {
            Console.Write(text);
        }
        static void writeln(String text) {
            Console.WriteLine(text);
        }

        static int inputDigitals() {
            var userInput = Console.ReadKey();

            if (!char.IsDigit(userInput.KeyChar)) {
                return -1;
            }
            int n = -1;
            var isParsed = int.TryParse(userInput.KeyChar.ToString(), out n);

            return isParsed ? n : -1;
        }


        Bitmap[] topAtackAnimtions() {
            Bitmap[] bitmaps = {
                ConsoleBoxGame.Properties.assets.SpriteP1Top1,
                ConsoleBoxGame.Properties.assets.SpriteP1Top2,
                ConsoleBoxGame.Properties.assets.SpriteP1Top3,
                ConsoleBoxGame.Properties.assets.SpriteP1Top4,
                ConsoleBoxGame.Properties.assets.SpriteP1Top5,
                ConsoleBoxGame.Properties.assets.SpriteP1Top6,
                ConsoleBoxGame.Properties.assets.SpriteP1Top7,
                ConsoleBoxGame.Properties.assets.SpriteP1Top8,
                ConsoleBoxGame.Properties.assets.SpriteP1Top9,
                ConsoleBoxGame.Properties.assets.SpriteP1Top10,
                ConsoleBoxGame.Properties.assets.SpriteP1Top11,
                ConsoleBoxGame.Properties.assets.SpriteP1Top12,
                ConsoleBoxGame.Properties.assets.SpriteP1Top13,
                ConsoleBoxGame.Properties.assets.SpriteP1Top14,
                ConsoleBoxGame.Properties.assets.SpriteP1Top15,
                ConsoleBoxGame.Properties.assets.SpriteP1Top16,
                ConsoleBoxGame.Properties.assets.SpriteP1Top17,
                ConsoleBoxGame.Properties.assets.SpriteP1Top18,
                ConsoleBoxGame.Properties.assets.SpriteP1Top19,
                ConsoleBoxGame.Properties.assets.SpriteP1Top20,
                ConsoleBoxGame.Properties.assets.SpriteP1Top21,
                ConsoleBoxGame.Properties.assets.SpriteP1Top22,
                ConsoleBoxGame.Properties.assets.SpriteP1Top23
            };
            return bitmaps;
        }
        Bitmap[] bottomAtackAnimtions() {
            Bitmap[] bitmaps = {
                ConsoleBoxGame.Properties.assets.SpriteP1Bottom1,
                ConsoleBoxGame.Properties.assets.SpriteP1Bottom2,
                ConsoleBoxGame.Properties.assets.SpriteP1Bottom3,
                ConsoleBoxGame.Properties.assets.SpriteP1Bottom4,
                ConsoleBoxGame.Properties.assets.SpriteP1Bottom5,
                ConsoleBoxGame.Properties.assets.SpriteP1Bottom6,
                ConsoleBoxGame.Properties.assets.SpriteP1Bottom7,
                ConsoleBoxGame.Properties.assets.SpriteP1Bottom8
            };
            return bitmaps;
        }
        Bitmap[] middleAtackAnimtions() {
            Bitmap[] bitmaps = {
                ConsoleBoxGame.Properties.assets.SpriteP1Middle1,
                ConsoleBoxGame.Properties.assets.SpriteP1Middle2,
                ConsoleBoxGame.Properties.assets.SpriteP1Middle3,
                ConsoleBoxGame.Properties.assets.SpriteP1Middle4,
                ConsoleBoxGame.Properties.assets.SpriteP1Middle5,
                ConsoleBoxGame.Properties.assets.SpriteP1Middle6,
                ConsoleBoxGame.Properties.assets.SpriteP1Middle7,
                ConsoleBoxGame.Properties.assets.SpriteP1Middle8,
                ConsoleBoxGame.Properties.assets.SpriteP1Middle9,
                ConsoleBoxGame.Properties.assets.SpriteP1Middle10,
                ConsoleBoxGame.Properties.assets.SpriteP1Middle11,
                ConsoleBoxGame.Properties.assets.SpriteP1Middle12,
                ConsoleBoxGame.Properties.assets.SpriteP1Middle13,
                ConsoleBoxGame.Properties.assets.SpriteP1Middle14,
                ConsoleBoxGame.Properties.assets.SpriteP1Middle15,
                ConsoleBoxGame.Properties.assets.SpriteP1Middle16

            };
            return bitmaps;
        }

        // ---------------------------------------------------------

        enum Body {
            head = 1,
            body = 2,
            leg = 3
        }
        enum Player {
            player = 1,
            bot = 2
        }

        int player1Hp = 10;
        int botHp = 10;
        Body player1AtackType = Body.head;
        Body botAtackType = Body.head;
        Body player1EvadeType = Body.head;
        Body botEvadeType = Body.head;
        public int gameResult = 0;

        public Game() {
            var launchScreen = ConsoleBoxGame.Properties.assets.Menu.ScaleBitmap(0.7f).ASCIIFilter(5,5);
            write(launchScreen);
            Console.ReadKey();
            Console.Clear();
        }

        int choseAtack() {
            Console.Clear();
            write("Chose atack type:\n 1. HEAD\n 2. Body\n 3. Leg\n");
            var type = inputDigitals();
            return type;
        }

        int choseEvade() {
            Console.Clear();
            write("Chose evade type:\n 1. HEAD\n 2. Body\n 3. Leg\n");
            var type = inputDigitals();
            return type;
        }

        void animatePlayer1AtackByType(Body type, Player player) {
            switch (type) {
                case Body.head: animateBitmaps(topAtackAnimtions(), player); break;
                case Body.body: animateBitmaps(middleAtackAnimtions(), player); break;
                case Body.leg:  animateBitmaps(bottomAtackAnimtions(), player); break;
            }
        }

        void animateBitmaps(Bitmap[] bitmaps, Player player) {
            for (int i = 0; i < bitmaps.Length; i++) {
                Console.Clear();
                var bitmap = bitmaps[i];

                if (player == Player.bot) {
                    bitmap.RotateFlip(RotateFlipType.RotateNoneFlipX);
                }
                var ascii = bitmap.ScaleBitmap(0.7f).ASCIIFilter(5, 10);
                write(ascii);
                Thread.Sleep(100);
            }
        }

        public int loop() {
            while (true) {
                var type = choseAtack();
                if (type != -1 && type > 0 && type < 4) {
                    player1AtackType = (Body)type;
                    break;
                }
                Console.Clear();
                write("Incorrect value. Choose from 1 2 3 Range");
                Console.ReadKey();
            }

            while (true) {
                var type = choseEvade();
                if (type != -1 && type > 0 && type < 4) {
                    player1EvadeType = (Body)type;
                    break;
                }
                Console.Clear();
                write("Incorrect value. Choose from 1 2 3 Range");
                Console.ReadKey();
            }

            Random random = new Random();
            botAtackType = (Body)random.Next(1, 3);
            botEvadeType = (Body)random.Next(1, 3);

            animatePlayer1AtackByType(player1AtackType, Player.player);
            Console.Clear();

            if (player1AtackType != botEvadeType) {
                botHp -= 1;
                write("Your atack sucess - BOT HP (" + botHp + ")");
            } else {
                write("Your atack evaded - BOT HP (" + botHp + ")");
            }

            Console.ReadKey();
            Console.Clear();

            animatePlayer1AtackByType(botAtackType, Player.bot);

            Console.Clear();
            if (botAtackType != player1EvadeType) {
                player1Hp -= 1;
                write("Bot atack sucess - PLAYER HP (" + player1Hp + ")");
            } else {
                write("Bot atack evaded - PLAYER HP (" + player1Hp + ")");
            }

            Console.ReadKey();
            Console.Clear();

            if (botHp == 0) {
                gameResult = 1;
                return -1;
            }

            if (player1Hp == 0) {
                gameResult = 2;
                return -1;
            }

            return 0;
        }
    }
}
