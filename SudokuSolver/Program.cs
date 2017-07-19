using System;
using System.Diagnostics;

namespace SudokuSolver {
    partial class Program {
        static void Main(string[] args) {
            Console.WriteLine("Hello World!");

            var sw = new Stopwatch();
            
            var b = new Board();
            b.SetPosition(0, 1, 8);
            b.SetPosition(0, 3, 5);

            b.SetPosition(1, 1, 5);
            b.SetPosition(1, 3, 9);
            b.SetPosition(1, 7, 3);
            b.SetPosition(1, 8, 8);

            b.SetPosition(2, 2, 4);
            b.SetPosition(2, 3, 3);
            b.SetPosition(2, 5, 8);
            b.SetPosition(2, 6, 5);

            b.SetPosition(3, 2, 3);
            b.SetPosition(3, 6, 2);
            b.SetPosition(3, 7, 5);
            b.SetPosition(3, 8, 1);

            b.SetPosition(5, 0, 9);
            b.SetPosition(5, 1, 7);
            b.SetPosition(5, 2, 2);
            b.SetPosition(5, 6, 6);

            b.SetPosition(6, 2, 9);
            b.SetPosition(6, 3, 6);
            b.SetPosition(6, 5, 1);
            b.SetPosition(6, 6, 4);

            b.SetPosition(7, 0, 1);
            b.SetPosition(7, 1, 6);
            b.SetPosition(7, 5, 7);
            b.SetPosition(7, 7, 2);

            b.SetPosition(8, 5, 3);
            b.SetPosition(8, 7, 7);

            Console.WriteLine(b.ToString());
            Console.WriteLine();
            Console.WriteLine();

            var solved = b.SolveBoard();

            Console.WriteLine("Board " + (solved ? "solved!" : " not solved :("));

            Console.WriteLine(b.ToString());
            Console.WriteLine(sw.Elapsed);
        }
    }
}
