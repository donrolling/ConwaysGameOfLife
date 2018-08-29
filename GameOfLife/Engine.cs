using System.Text;

namespace GameOfLife {
	public class Engine {
		private string Dead = ".";
		private string Alive = "O";
		public Board Board { get; private set; }

		public Engine(int stageX, int stageY, bool[] seed) {
			this.Board = new Board(stageX, stageY, seed);
		}
		public string DisplayNext() {
			var next = Calculations.CalculateNext(this.Board.Next, this.Board.StageX, this.Board.StageY);
			this.Board.SetNext(next);
			return this.display(this.Board.Seed);
		}
		public bool[] DisplayNextArray() {
			var next = Calculations.CalculateNext(this.Board.Next, this.Board.StageX, this.Board.StageY);
			this.Board.SetNext(next);
			return this.Board.Seed;
		}
		private string display(bool[] display) {
			var screen = new StringBuilder();
			for (int i = 0; i < this.Board.StageY; i++) {
				for (int j = 0; j < this.Board.StageX; j++) {
					var cell = (this.Board.StageX * this.Board.StageY - (this.Board.StageX * i)) - (this.Board.StageX - j);
					var cellState = display[cell] ? this.Alive : this.Dead;
					screen.Append(cellState);
				}
				screen.AppendLine();
			}
			return screen.ToString();
		}
	}
}