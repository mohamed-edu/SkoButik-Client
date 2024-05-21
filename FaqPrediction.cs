using Microsoft.ML.Data;

namespace SkoButik_Client
{
    public class FaqPrediction
    {
        [ColumnName("PredictedLabel")]
        public string Answer { get; set; }
    }
}
