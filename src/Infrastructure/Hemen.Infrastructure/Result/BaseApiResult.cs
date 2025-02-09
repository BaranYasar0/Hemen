using Hemen.Identity.API.Application.Features;
using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Hemen.Infrastructure.Result;
public class BaseApiResult {
    public HttpStatusCode Status { get; set; }

    public ProblemDetails? ProblemDetails { get; set; }

    [JsonIgnore] public bool IsSuccess => ProblemDetails is null;

    // Static factory methods
    public static BaseApiResult SuccessAsNoContent() {
        return new BaseApiResult {
            Status = HttpStatusCode.NoContent
        };
    }

    public static BaseApiResult ErrorAsNotFound() {
        return new BaseApiResult {
            Status = HttpStatusCode.NotFound,
            ProblemDetails = new ProblemDetails {
                Title = "Not Found",
                Detail = "The requested resource was not found"
            }
        };
    }

    public static BaseApiResult ErrorAsUnauthorized() {
        return new BaseApiResult {
            Status = HttpStatusCode.Unauthorized,
            ProblemDetails = new ProblemDetails {
                Title = "Unauthorized",
                Detail = "You are not authorized to access this resource."
            }
        };
    }

    public new static BaseApiResult ErrorFromException(Exception exception) {

        if (string.IsNullOrEmpty(exception?.InnerException?.Message))
            return new BaseApiResult() {
                ProblemDetails = new ProblemDetails {
                    Title = "An unexpected error occurred. Please try again later."
                },
                Status = HttpStatusCode.BadRequest
            };

        return new BaseApiResult() {
            ProblemDetails = new ProblemDetails {
                Title = exception.InnerException.Message
            },
            Status = HttpStatusCode.BadRequest
        };
    }
    public static BaseApiResult Error(ProblemDetails problemDetails, HttpStatusCode status) {
        return new BaseApiResult {
            Status = status,
            ProblemDetails = problemDetails
        };
    }

    public static BaseApiResult Error(string title, string description, HttpStatusCode status) {
        return new BaseApiResult {
            Status = status,
            ProblemDetails = new ProblemDetails() {
                Title = title,
                Detail = description,
                Status = status.GetHashCode()
            }
        };
    }

    public static BaseApiResult Error(string title, HttpStatusCode status) {
        return new BaseApiResult {
            Status = status,
            ProblemDetails = new ProblemDetails() {
                Title = title,
                Status = status.GetHashCode()
            }
        };
    }

    public static BaseApiResult ErrorFromProblemDetails(Exception exception, HttpStatusCode statusCode) =>
     new BaseApiResult() {
         ProblemDetails = new ProblemDetails() {
             Title = exception.Message
         },
         Status = statusCode
     };



    public static BaseApiResult ErrorFromValidation(IDictionary<string, object?> errors) {
        return new BaseApiResult {
            Status = HttpStatusCode.BadRequest,
            ProblemDetails = new ProblemDetails() {
                Title = "Validation errors occured",
                Detail = "Please check the errors property for more details",
                Extensions = errors,
                Status = HttpStatusCode.BadRequest.GetHashCode()
            }
        };
    }
}

public class BaseApiResult<T> : BaseApiResult {
    public T? Data { get; set; }
    public string Endpoint { get; set; }
    public static BaseApiResult<T> SuccessAsOk(T data) {
        return new BaseApiResult<T> {
            Status = HttpStatusCode.OK,
            Data = data
        };
    }

    //201 => Created => respones body header => location== api/products/5
    public static BaseApiResult<T> SuccessAsCreated(T data, string url) {
        return new BaseApiResult<T> {
            Status = HttpStatusCode.Created,
            Data = data,
            Endpoint = url
        };
    }
    public new static BaseApiResult<T> ErrorAsNotFound() {
        return new BaseApiResult<T> {
            Status = HttpStatusCode.NotFound,
            ProblemDetails = new ProblemDetails {
                Title = "Not Found",
                Detail = "The requested resource was not found"
            }
        };
    }
    public new static BaseApiResult<T> Error(ProblemDetails problemDetails, HttpStatusCode status) {
        return new BaseApiResult<T> {
            Status = status,
            ProblemDetails = problemDetails
        };
    }

    public new static BaseApiResult<T> Error(string title, string description, HttpStatusCode status) {
        return new BaseApiResult<T> {
            Status = status,
            ProblemDetails = new ProblemDetails() {
                Title = title,
                Detail = description,
                Status = status.GetHashCode()
            }
        };
    }

    public new static BaseApiResult<T> Error(string title, HttpStatusCode status) {
        return new BaseApiResult<T> {
            Status = status,
            ProblemDetails = new ProblemDetails() {
                Title = title,
                Status = status.GetHashCode()
            }
        };
    }
    public new static BaseApiResult<T> ErrorAsUnauthorized() {
        return new BaseApiResult<T> {
            Status = HttpStatusCode.Unauthorized,
            ProblemDetails = new ProblemDetails {
                Title = "Unauthorized",
                Detail = "You are not authorized to access this resource."
            }
        };
    }
    public new static BaseApiResult<T> ErrorFromException(Exception exception) {

        if (string.IsNullOrEmpty(exception?.InnerException?.Message))
            return new BaseApiResult<T>() {
                ProblemDetails = new ProblemDetails {
                    Title = "An unexpected error occurred. Please try again later."
                },
                Status = HttpStatusCode.BadRequest
            };

        return new BaseApiResult<T>() {
            ProblemDetails = new ProblemDetails {
                Title = exception.InnerException.Message,
                Detail = exception.Message
            },
            Status = HttpStatusCode.BadRequest
        };
    }

    public new static BaseApiResult<T> ErrorFromProblemDetails(Exception exception, HttpStatusCode statusCode) {

        var problemDetails = JsonSerializer.Deserialize<ProblemDetails>(exception?.InnerException?.Message,
            new JsonSerializerOptions() {
                PropertyNameCaseInsensitive = true
            });


        return new BaseApiResult<T>() {
            ProblemDetails = problemDetails,
            Status = statusCode
        };
    }

    public new static BaseApiResult<T> ErrorFromValidation(IDictionary<string, object?> errors) {
        return new BaseApiResult<T> {
            Status = HttpStatusCode.BadRequest,
            ProblemDetails = new ProblemDetails() {
                Title = "Validation errors occured",
                Detail = "Please check the errors property for more details",
                Extensions = errors,
                Status = HttpStatusCode.BadRequest.GetHashCode()
            }
        };
    }
}

