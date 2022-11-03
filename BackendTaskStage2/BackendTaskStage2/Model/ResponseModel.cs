using BackendTaskStage2.Enums;
using System.Reflection.Emit;

namespace BackendTaskStage2.Model
{
    public class ResponseModel
    {
        public string SlackUsername { get; set; }

        public int Result { get; set; }

        public OperationType Operation_Type { get; set; }

        public ResponseModel()
        {
            SlackUsername = "Tsadhoq";
        }
    }
}
