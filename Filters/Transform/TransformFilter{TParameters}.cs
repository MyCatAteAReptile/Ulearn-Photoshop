using System;
using System.Drawing;

namespace MyPhotoshop
{
    public class TransformFilter<TParameters> : ParametrizedFilter<TParameters>
        where TParameters : IParameters, new()
    {
        string _name;
        private ITransformer<TParameters> _transformer;

        public TransformFilter
            (
            string name,
            ITransformer<TParameters> transformer
            )
        {
            _name = name;
            _transformer = transformer;
        }

        public override Photo Process(Photo original, TParameters parameters)
        {
            var oldSize = new Size(original.width, original.height);
            _transformer.Prepare(oldSize, parameters);
            var result = new Photo(_transformer.ResultSize.Width, _transformer.ResultSize.Height);

            for (int x = 0; x < result.width; x++)
                for (int y = 0; y < result.height; y++)
                {
                    var point = new Point(x, y);
                    var oldPoint = _transformer.MapPoint(point);
                    if (oldPoint.HasValue)
                        result[x, y] = original[oldPoint.Value.X, oldPoint.Value.Y];
                }
            return result;
        }

        public override string ToString()
        {
            return _name;
        }
    }
}

