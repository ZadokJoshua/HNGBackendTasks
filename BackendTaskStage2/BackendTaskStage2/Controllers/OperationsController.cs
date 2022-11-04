using BackendTaskStage2.Enums;
using BackendTaskStage2.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace BackendTaskStage2.Controllers
{
    [Route("operations")]
    [ApiController]
    public class OperationsController : ControllerBase
    {
        public record RequestBodyModel(string operation_Type, int x, int y);

        [HttpPost]
        public ActionResult<ResponseModel> PerformMathematicalOperation([FromBody] RequestBodyModel bodyModel)
        {
            // var result = PerformOperation(operationType, x, y);
            var result = PerformOperation(bodyModel.operation_Type, bodyModel.x, bodyModel.y);
            var response = new ResponseModel
            {
                Result = result.Item2,
                Operation_type = bodyModel.operation_Type.ToLower(),
            };

            return Ok(response);
        }

        private (OperationType, int) PerformOperation(string operation_Type, int x, int y)
        {
            OperationType operationType;
            int result = 0;

            if (Enum.TryParse(operation_Type.ToLower(), out operationType))
            {
                switch (operationType)
                {
                    case OperationType.addition:
                        result = x + y;
                        break;

                    case OperationType.subtraction:
                        result = x - y;
                        break;

                    case OperationType.multiplication:
                        result = x * y;
                        break;

                    default: throw new ArgumentException("Invalid Operation");
                } 
            }

            return (operationType, result);
        }
    }
}
