using System.Collections.Generic;
using System.Linq;

namespace SudokuSolver {
    public class Position {
        public int Lin { get; }
        public int Col { get; }
        public int Value { get; private set; } = -1;
        public bool IsSolved => Value != -1;

        public HashSet<int> Possibilities { get; } = new HashSet<int>(9) {
            1,2,3,4,5,6,7,8,9
        };

        public Position(int lin, int col) {
            Lin = lin;
            Col = col;
        }
        public void Solve(int value) {
            Value = value;
        }
        public bool Remove(int value) {
            var removed = Possibilities.Remove(value);
            if (Possibilities.Count == 1) {
                Solve(Possibilities.First());
            }
            return removed;
        }
    }
}