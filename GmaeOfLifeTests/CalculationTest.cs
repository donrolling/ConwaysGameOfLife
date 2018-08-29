using GameOfLife;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameOfLifeTests {
	[TestClass]
	public class CalculationTest {
		[TestMethod]
		public void Calculate3by3_CenterSeed() {
			var seed = new bool[9];
			seed[4] = true;
			var engine = new Engine(3, 3, seed);
			var result = engine.DisplayNext();
			Assert.IsFalse(result.Contains("O"));//everything is dead
			result = engine.DisplayNext();
			Assert.IsFalse(result.Contains("O"));//everything stayed dead
		}

		[TestMethod]
		public void Calculate3by3_FullSeed() {
			var seed = new bool[9];
			for (int i = 0; i < seed.Length; i++) {
				seed[0] = true;
			}
			var engine = new Engine(3, 3, seed);
			var result = engine.DisplayNext();
			Assert.IsFalse(result.Contains("O"));//everything is dead
			result = engine.DisplayNext();
			Assert.IsFalse(result.Contains("O"));//everything stayed dead
		}

		[TestMethod]
		public void Calculate3by3_EmptySeed() {
			var seed = new bool[9];
			var engine = new Engine(3, 3, seed);
			var result = engine.DisplayNext();
			Assert.IsFalse(result.Contains("O"));//everything is dead
			result = engine.DisplayNext();
			Assert.IsFalse(result.Contains("O"));//everything stayed dead
		}

		[TestMethod]
		public void Calculate3by3_Lives() {
			var seed = new bool[9];
			seed[1] = true;
			seed[2] = true;
			seed[3] = true;
			var engine = new Engine(3, 3, seed);
			var result = engine.DisplayNext();
			Assert.IsTrue(result.Contains("O"));//some lived
		}

		[TestMethod]
		public void Calculate3by3_Blinker() {
			var sizeX = 3;
			var sizeY = 3;
			var seed = new bool[sizeX * sizeY];
			seed[3] = true;
			seed[4] = true;
			seed[5] = true;
			var engine = new Engine(3, 3, seed);
			var result = engine.DisplayNext();
			var expectedResult = ".O.\r\n.O.\r\n.O.\r\n";
			Assert.AreEqual(expectedResult, result);
			result = engine.DisplayNext();
			expectedResult = "...\r\nOOO\r\n...\r\n";
			Assert.AreEqual(expectedResult, result);
			result = engine.DisplayNext();
			expectedResult = ".O.\r\n.O.\r\n.O.\r\n";
			Assert.AreEqual(expectedResult, result);
			result = engine.DisplayNext();
			expectedResult = "...\r\nOOO\r\n...\r\n";
			Assert.AreEqual(expectedResult, result);
		}
	}
}
