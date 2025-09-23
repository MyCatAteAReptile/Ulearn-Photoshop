using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyPhotoshop
{
    public abstract class ParametrizedFilter : IFilter
    {
        IParameters parameters;
        public ParametrizedFilter(IParameters parameters)
        {
            this.parameters = parameters;
        }

        public ParameterInfo[] GetParameters() => parameters.GetDesсription();

        public Photo Process(Photo original, double[] values) {
            this.parameters.SetValues(values);
            return Process(original, this.parameters);
        }

        public abstract Photo Process(Photo photo, IParameters parameters);
    }
}
