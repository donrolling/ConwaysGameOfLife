namespace GameOfLife {
	public class Directionals {
		public int CellNumber { get; private set; }
		public int StageX { get; private set; }
		public int StageY { get; private set; }
		public int Down => CellNumber - StageX;
		public int DownLeft => Down - 1;
		public int DownRight => Down + 1;
		public int Left => CellNumber - 1;
		public int Right => CellNumber + 1;
		public int Up => CellNumber + StageX;
		public int UpLeft => Up - 1;
		public int UpRight => Up + 1;

		public Directionals(int cellNumber, int stageX, int stageY) {
			this.CellNumber = cellNumber;
			this.StageX = stageX;
			this.StageY = stageY;
		}
	}
}