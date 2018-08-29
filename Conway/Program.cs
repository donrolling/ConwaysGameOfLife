using GameOfLife;
using System;
using System.Threading;

namespace Conway {
	class Program {
		static void Main(string[] args) {
			var rnd = new Random();
			var input = string.Empty;
			var sizeX = 10;
			var sizeY = 10;
			var seed = new bool[sizeX * sizeY];
			var aliveCells = sizeX * sizeY / 4;
			for (int i = 0; i < aliveCells; i++) {
				var cell = rnd.Next(seed.Length);
				seed[cell] = true;
			}
			var engine = new Engine(sizeX, sizeY, seed);
			while (input != "exit") {
				var display = engine.DisplayNext();
				Console.Clear();
				Console.Write(display);
				Thread.Sleep(500);
			}
		}
	}
}
