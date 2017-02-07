using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1 {
    class Program {

        // I'm so lazy and cose I reduce code as like that
        static void write(String value) {
            Console.WriteLine(value);
        }

        static int inputDigitals() {
            var userInput = Console.ReadLine(); // Get user input
            int n = -1;
            int.TryParse(userInput.ToString(), out n);
            return n;
        }

        static String inputString() {
            var userInput = Console.ReadLine(); // Get user input
            return userInput.ToString();
        }

        static int menu() {
            Console.Clear();

            String issues = "";
            for (int i = 0; i < 17; i++) {
                issues += "\n" + i + ": Issue - " + (i+1);
            }
            write("====Menu====\n Choose one of this:" +
                issues +
                "\n 777: EXIT"
            );

            return inputDigitals();
        }

        static void issue1() {
            Console.Clear();

            write("Input digital for compare:");
            int dig1 = inputDigitals();
            write("\nwith:");
            int dig2 = inputDigitals();

            int result = dig1 > dig2 ? dig1 : dig2;
            write("\n RESULT - " + result);
            inputDigitals();
        }

        static void issue2() {
            Console.Clear();

            write("Input 'Miau' or 'Woof' :\n");
            String input1 = inputString();

            if (input1 == "Miau") {
                write("Feed the cat");
            } else if (input1 == "Woof") {
                write("Walking with dog");
            } else {
                write("Text entered incorrect.\n Try again.\n Or write 777 for exit");
                if (inputDigitals() == 777) {

                    inputDigitals();
                    return;
                } else {
                    issue2();
                }
            }
        }

        static void issue3() {
            Console.Clear();

            write("Choose number of month:\n");

            int number = inputDigitals();

            switch (number) {
                case 1:
                case 2:
                case 12:
                    write("Winter"); break;
                case 3:
                case 4:
                case 5:
                    write("Spring"); break;
                case 6:
                case 7:
                case 8:
                    write("Summer"); break;
                case 9:
                case 10:
                case 11:
                    write("Autumn"); break;

                default:
                    write("Not found 404");
                    break;
            }

            inputDigitals();
        }

        static void issue4() {
            Console.Clear();

            write("Input 0 or 1 for magic\n");

            // ONE STRING FOR ONE ACTION
            write(inputDigitals() != 0 ? "OK" : "BAD");

            inputString();
        }

        static void issue5() {
            Console.Clear();
            write("The same with 3 but other text values for CASE");
            inputDigitals();
        }

        static void issue6() {
            Console.Clear();

            write("Input total kilometers:\n");
            int kilo = inputDigitals();
            write("Input total wasted time (In minutes) when taxi w8 something =) :\n");
            int time = inputDigitals();

            int result = 20;
            if (kilo >= 5) {
                result += (kilo - 5) * 3;
            }
            result += time;

            write("Total cost = (" + result + "UAH ) For:" + kilo + " and Time:" + time);

            inputDigitals();
        }

        static void Main(string[] args) {

            int exit = 0;
            while (exit != 777) {
                switch (menu()) {
                    case 0: issue1(); break;
                    case 1: issue2(); break;
                    case 2: issue3(); break;
                    case 3: issue4(); break;
                    case 4: issue5(); break;
                    case 5: issue6(); break;

                    case 777: exit = 777; break;
                }
            }

            /*
            int c, v, max;
            Console.WriteLine("Введите первое число:");
            c = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите второе число:");
            v = Convert.ToInt32(Console.ReadLine());
            max = c > v ? c : v;

            Console.ReadKey();
            */
        }
    }
    
}
