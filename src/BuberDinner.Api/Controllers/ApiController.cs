using BuberDinner.Api.Common.Http;
using ErrorOr;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BuberDinner.Api.Controllers
{
    [ApiController]
    [Authorize]
    public class ApiController : Controller
    {
        protected IActionResult Problem(List<Error> errors)
        {
            if (errors.Count is 0)
            {
                return Problem();
            }
            if (errors.All(error => error.Type == ErrorType.Validation))
            {
                return ValidationProblem(errors);
            }


            HttpContext.Items[HttpContextItemKeys.Errors] = errors;

            var firstError = errors[0];

            int statusCode = Problem(firstError);

            return Problem(statusCode: statusCode, title: firstError.Description);
        }

        private static int Problem(Error error)
        {
            return error.Type switch
            {
                ErrorType.Conflict => StatusCodes.Status409Conflict,
                ErrorType.Validation => StatusCodes.Status400BadRequest,
                ErrorType.NotFound => StatusCodes.Status404NotFound,
                _ => StatusCodes.Status500InternalServerError
            };
        }

        private IActionResult ValidationProblem(List<Error> errors)
        {
            var modelStateDict = new ModelStateDictionary();

            foreach (var err in errors)
            {
                modelStateDict.AddModelError(
                    err.Code,
                    err.Description
                    );
            }
            return ValidationProblem(modelStateDict);
        }
    }
}
