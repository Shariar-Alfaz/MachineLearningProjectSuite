using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineLearningProjectSuite.Application.Dto.Property
{
    public class PropertyPredictModel
    {
        public int Bed { get; set; }
        public int Bath { get; set; }
        public double Area { get; set; }
        public int TypeValue { get; set; }
    }

    public class PropertyPredictResult
    {
        public double PredictedPrice { get; set; }
    }
}
