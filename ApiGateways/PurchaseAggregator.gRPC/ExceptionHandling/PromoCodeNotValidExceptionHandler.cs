using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PurchaseAggregator.gRPC.Eceptions;

namespace PurchaseAggregator.gRPC.ExceptionHandling
{
    public class PromoCodeNotValidExceptionHandler : IExceptionHandler
    {
        private readonly ILogger _logger;

        public PromoCodeNotValidExceptionHandler(ILogger<PromoCodeNotValidExceptionHandler> logger)
        {
            _logger = logger;
        }

        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {

            if (exception is not PromoCodeIsNotValidException ex)
            {
                return false;
            }

            _logger.LogError(
                ex,
                "PromoCode is not valid: {Message}",
                ex.Message
                );

            var problemDetails = new ProblemDetails
            {
                Title = "Unprocessable entity",
                Status = StatusCodes.Status422UnprocessableEntity,
                Detail = ex.Message
            };

            httpContext.Response.StatusCode = (int)problemDetails.Status;

            await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);

            return true;
        }
    }
}
