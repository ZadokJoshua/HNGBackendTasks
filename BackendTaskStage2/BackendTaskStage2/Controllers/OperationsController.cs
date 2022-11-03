using BackendTaskStage2.Enums;
using BackendTaskStage2.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace BackendTaskStage2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationsController : ControllerBase
    {
        [HttpPost]
        public IActionResult PerformMathematicalOperation(string operationType, int x, int y)
        {
            var result = PerformOperation(operationType, x, y);
            var response = new ResponseModel
            {
                Result = result.Item2,
                Operation_Type = result.Item1
            };

            return Ok(response);
        }

        private (OperationType, int) PerformOperation(string operation_Type, int x, int y)
        {
            OperationType operationType;
            int result = 0;

            if (Enum.TryParse(operation_Type, out operationType))
            {
                switch (operationType)
                {
                    case OperationType.Addition:
                        result = x + y;
                        break;

                    case OperationType.Subtraction:
                        result = x - y;
                        break;

                    case OperationType.Multiplication:
                        result = x * y;
                        break;

                    default: throw new ArgumentException("Invalid Operation");
                } 
            }

            return (operationType, result);
        }
    }
}
