using System.Collections.Generic;

namespace GameOfLife {
	public static class Calculations {
		public static bool[] CalculateNext(bool[] seed, int stageX, int stageY) {
			var length = seed.Length;
			var next = new bool[length];
			for (int i = 0; i < stageX; i++) {
				for (int j = 0; j < stageY; j++) {
					var cell = (stageY * i) + j;
					next[cell] = calculate(seed, cell, stageX, stageY);
				}
			}
			return next;
		}

		private static bool calculate(bool[] seed, int cellNumber, int stageX, int stageY) {
			var cell = seed[cellNumber];
			var neighborCount = getNeighborCount(seed, cellNumber, stageX, stageY);
			return applyRules(cell, neighborCount);
		}

		private static int getNeighborCount(bool[] seed, int cellNumber, int stageX, int stageY) {
			var directionals = new Directionals(cellNumber, stageX, stageY);
			var culledCells = cullOutOfBounds(directionals);
			var count = 0;
			foreach (var cell in culledCells) {
				if (seed[cell]) {
					count++;
				}
			}
			return count;
		}

		private static int[] cullOutOfBounds(Directionals directionals) {
			//left
			if (directionals.CellNumber % directionals.StageX == 0) {
				//top
				if (directionals.CellNumber == (directionals.StageY * directionals.StageX) - directionals.StageX) {
					return new List<int> {
						directionals.Down,
						directionals.DownRight,
						directionals.Right
					}.ToArray();
					//bottom
				} else if (directionals.CellNumber == 0) {
					return new List<int> {
						directionals.Up,
						directionals.UpRight,
						directionals.Right
					}.ToArray();
					//other left cells
				} else {
					return new List<int> {
						directionals.Up,
						directionals.UpRight,
						directionals.Down,
						directionals.DownRight,
						directionals.Right
					}.ToArray();
				}
				//right
			} else if (directionals.CellNumber % directionals.StageX == directionals.StageX - 1) {
				//top
				if (directionals.CellNumber == (directionals.StageY * directionals.StageX) - 1) {
					return new List<int> {
						directionals.Down,
						directionals.DownLeft,
						directionals.Left,
					}.ToArray();
					//bottom
				} else if (directionals.CellNumber < directionals.StageX) {
					return new List<int> {
						directionals.Up,
						directionals.UpLeft,
						directionals.Left,
					}.ToArray();
					//other right cells
				} else {
					return new List<int> {
						directionals.Up,
						directionals.UpLeft,
						directionals.Down,
						directionals.DownLeft,
						directionals.Left,
					}.ToArray();
				}
			//top
			} else if (directionals.CellNumber >= (directionals.StageY * directionals.StageX) - directionals.StageX) {
				return new List<int> {
					directionals.Down,
					directionals.DownLeft,
					directionals.DownRight,
					directionals.Left,
					directionals.Right
				}.ToArray();
			//bottom
			} else if (directionals.CellNumber < directionals.StageX) {
				return new List<int> {
					directionals.Up,
					directionals.UpLeft,
					directionals.UpRight,
					directionals.Left,
					directionals.Right
				}.ToArray();
			//other right cells
			} else {
				return new List<int> {
					directionals.Up,
					directionals.UpLeft,
					directionals.UpRight,
					directionals.Down,
					directionals.DownLeft,
					directionals.DownRight,
					directionals.Left,
					directionals.Right
				}.ToArray();
			}
		}

		private static bool applyRules(bool cell, int neighborCount) {
			if (cell) {
				return neighborCount < 2
						? false
						: neighborCount > 3
						? false
						: true;
			} else {
				return neighborCount == 3;
			}
		}

		//Any live cell with fewer than two live neighbours dies, as if caused by under-population.
		//Any live cell with two or three live neighbours lives on to the next generation.
		//Any live cell with more than three live neighbours dies, as if by over-population.
		//Any dead cell with exactly three live neighbours becomes a live cell, as if by reproduction.
	}
}