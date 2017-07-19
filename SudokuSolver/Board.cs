using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SudokuSolver {
    partial class Program {
        public class Board {

            private const int _lines = 9;
            private const int _cols = 9;

            private bool _changed;
            public List<Position> Positions { get; } = new List<Position>(81);

            public Board() {
                for (var i = 0; i < _lines; i++) {
                    for (var j = 0; j < _cols; j++) {
                        Positions.Add(new Position(i, j));
                    }
                }
            }

            public void SetPosition(int lin, int col, int value) {
                GetPosition(lin, col).Solve(value);
            }

            public bool SolveBoard() {
                while (Positions.Any(p => !p.IsSolved)) {
                    _changed = false;
                    for (var i = 0; i < _lines; i++) {
                        for (var j = 0; j < _cols; j++) {
                            var p = GetPosition(i, j);
                            if (p.IsSolved) {
                                continue;
                            }
                            ProcessLine(p);
                            ProcessColumn(p);
                            ProcessArea(p);
                        }
                    }
                    if (!_changed) {
                        return false;
                    }
                }
                return true;
            }

            private void ProcessLine(Position p) {
                for (var i = 0; i < _lines; i++) {
                    var pos = GetPosition(p.Lin, i);
                    if (pos.IsSolved) {
                        MarkIfStepForward(p.Remove(pos.Value));
                    }
                }
            }

            private void ProcessColumn(Position p) {
                for (var i = 0; i < _cols; i++) {
                    var pos = GetPosition(i, p.Col);
                    if (pos.IsSolved) {
                        MarkIfStepForward(p.Remove(pos.Value));
                    }
                }
            }

            private void ProcessArea(Position p) {
                var cs = GetStart(p.Col);
                var ls = GetStart(p.Lin);
                for (var i = ls; i < ls + 3; i++) {
                    for (var j = cs; j < cs + 3; j++) {
                        var pos = GetPosition(i, j);
                        if (pos.IsSolved) {
                            MarkIfStepForward(p.Remove(pos.Value));
                        }
                    }
                }
            }

            private int GetStart(int value) {
                return (value / 3) * 3;
            }

            private Position GetPosition(int lin, int col) {
                return Positions[col + lin * _lines];
            }

            private void MarkIfStepForward(bool removed) {
                if (removed) {
                    _changed = true;
                }
            }

            public override string ToString() {
                var sb = new StringBuilder();
                for (var i = 0; i < _lines; i++) {
                    sb.AppendLine();
                    for (var j = 0; j < _cols; j++) {
                        var p = GetPosition(i,j);
                        sb.Append($"{(p.Value == -1 ? "X" : p.Value+"")}\t" );
                    }
                }
                return sb.ToString();
            }
        }
    }
}
