using BackendTaskStage2.Enums;
using System.Reflection.Emit;

namespace BackendTaskStage2.Model
{
    public class ResponseModel
    {
        public string SlackUsername { get; set; }

        public int Result { get; set; }

        public string Operation_type { get; set; } = String.Empty;

        public ResponseModel()
        {
            SlackUsername = "Tsadhoq";
        }
    }
}
