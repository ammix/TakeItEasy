//using System;
//using System.Collections.Generic;
//using System.Drawing;

//using TakeItEasy.Model;
//using TakeItEasy.View;

//namespace TakeItEasy.Rendering
//{
//	public class TileGraphics : HexagonGraphics, IDisposable
//	{
//		private BarGraphics[] bars;

//		public Tile Tile { get; }

//		public IEnumerable<BarGraphics> Bars => bars;

//		public TileGraphics(Hexagon hexagon, Tile tile) : base(hexagon)
//		{
//			Tile = tile;
//			bars = new BarGraphics[3];

//			for (var i = 0; i < 3; i++)
//			{
//				var number = GetNumber(i, tile);
//				bars[i] = new BarGraphics(hexagon, number);
//			}
//		}

//		public void ChangeCenter(SizeF delta)
//		{
//			var hx = Hexagon;
//			hx.Center = Hexagon.Center + delta;
//			Hexagon = hx;
//		}

//		//public void ChangeColor(Color color)
//		//{
//		//	var hx = Hexagon;
//		//	hx.Color = color;
//		//	Hexagon = hx;
//		//}

//		public override void Dispose()
//		{
//			base.Dispose();
//			foreach (var bar in bars)
//				bar.Dispose();
//		}

//		private static int GetNumber(int order, Tile model)
//		{
//			var list = new List<int> { model.LeftNumber, model.TopNumber, model.RightNumber };
//			list.Sort();
//			return list[order];
//		}
//	}
//}
