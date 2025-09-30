using System;

namespace MyPhotoshop
{
	public class PixelFilter<TParameters> : ParametrizedFilter<TParameters>
		where TParameters : IParameters, new()
    {
		string _name;
		Func<Pixel, TParameters,  Pixel> _processor;

        public PixelFilter(string name, Func<Pixel, TParameters, Pixel> process)
        {
            _name = name;
            _processor = process;
        }

        public override Photo Process(Photo original, TParameters parameters)
        {
			var result=new Photo(original.width, original.height);
			
			for (int x=0;x<result.width;x++)
				for (int y=0;y<result.height;y++)
                    result[x, y] = _processor(original[x, y], parameters);
			return result;
		}

        public override string ToString()
        {
            return _name;
        }
    }
}

