namespace GameOfLife {
	public class Board {
		public int StageX { get; private set; }
		public int StageY { get; private set; }
		public bool[] Seed { get; private set; }
		public bool[] Next { get; private set; }
		public int Size() => this.StageX * this.StageY;

		public Board(int stageX, int stageY, bool[] seed) {
			this.StageX = stageX;
			this.StageY = stageY;
			this.Seed = seed;
			this.Next = seed;
		}

		public void SetNext(bool[] next) {
			this.Seed = this.Next;
			this.Next = next;
		}
	}
}