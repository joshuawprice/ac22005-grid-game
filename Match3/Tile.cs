using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.CodeDom.Compiler;
using System.Diagnostics;

namespace Match_Mania {
    internal class Tile : Button {
        private static Random s_rng = new Random();

        private Colors _color;

        private Point _position;
        public Point Position {
            get => _position;
            set {
                _position = value;
                SetBounds(value.X * 75 + 20, value.Y * 75 + 188, 75, 75);
            }
        }

        public enum Colors {
            Green,
            Orange,
            Red,
            Blue,
            Pink,
            Turquoise,
            Gold
        }

        public Colors Color {
            get => _color;
            init {
                _color = value;
                switch (value) {
                    case Colors.Green:
                        BackColor = System.Drawing.Color.Green;
                        break;
                    case Colors.Orange:
                        BackColor = System.Drawing.Color.Orange;
                        break;
                    case Colors.Red:
                        BackColor = System.Drawing.Color.Red;
                        break;
                    case Colors.Blue:
                        BackColor = System.Drawing.Color.Blue;
                        break;
                    case Colors.Pink:
                        BackColor = System.Drawing.Color.Pink;
                        break;
                    case Colors.Turquoise:
                        BackColor = System.Drawing.Color.Turquoise;
                        break;
                    case Colors.Gold:
                        BackColor = System.Drawing.Color.Gold;
                        break;
                }
            }
        }

        private Colors genColor() {
            switch (s_rng.Next(0, 7)) {
                case 0:
                    return Colors.Green;
                case 1:
                    return Colors.Orange;
                case 2:
                    return Colors.Red;
                case 3:
                    return Colors.Blue;
                case 4:
                    return Colors.Pink;
                case 5:
                    return Colors.Turquoise;
                case 6:
                    return Colors.Gold;
                // Placeholder; shouldn't ever be run.
                default:
                    return Colors.Green;
            }
        }
        
        public bool IsAdjacent(Tile tile) {
            Point pos = tile.Position;
            if ((pos.X == Position.X + 1 || pos.X == Position.X - 1) && pos.Y == Position.Y
                || (pos.Y == Position.Y + 1 || pos.Y == Position.Y - 1) && pos.X == Position.X) {
                return true;
            }

            return false;
        }

        public Tile(Point position) {
            Position = position;
            Color = genColor();
        }
    }
}
