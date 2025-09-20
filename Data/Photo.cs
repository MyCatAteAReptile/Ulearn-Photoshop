using System;

namespace MyPhotoshop
{
	public class Photo
	{
		public readonly int width;
		public readonly int height;
        private readonly Pixel[,] data;

		public Photo(int width, int height)
		{
			this.width = width;
            this.height = height;
            this.data = new Pixel[width, height];
		}

		public Photo(Pixel[,] data)
		{
            this.width = data.GetLength(0);
            this.height = data.GetLength(1);
            this.data = data;
		}

		public Pixel this[int x, int y]
		{
			get => data[x, y];
			set => data[x, y] = value;
		}
	}
}

