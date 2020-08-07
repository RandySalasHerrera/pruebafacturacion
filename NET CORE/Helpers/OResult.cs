using System;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using EPublico.Core.Classes;
using EPublico.Core.Extensions;
using EPublico.Core.Helpers.GlobalErrorHandling;

namespace EPublico.Core.Helpers
{
    public static class OResult
    {

        public static ObjectResult OkRequestResult(object o = null)
        {

            object result = null;
            if (o == null)
            {
                result = null;
            }
            else if (o.GetType().Name == "String")
            {
                result = JsonConvert.DeserializeObject(o.ToString(), JsonSerializerDefault.LowerCaseSerializerSettings());
            }
            else if (o.GetType().Name.Contains("EntityQueryable") || o.GetType().Name.Contains("List"))
            {
                result = JArray.FromObject(o, jsonSerializer: JsonSerializerDefault.LowerCaseJsonSerializer());
            }
            else if (o.GetType().Name.Contains("JToken"))
            {
                result = o;
            }
            else if (o.GetType().Name.Contains("JArray"))
            {
                result = o;
            }
            else
            {
                result = JObject.FromObject(o, jsonSerializer: JsonSerializerDefault.LowerCaseJsonSerializer());
            }

            var or = new ObjectResult(new
            {
                success = true,
                data = result
            });

            or.StatusCode = 200;
            return or;

        }

        public static ObjectResult BadRequestResult(string m)
        {
            var or = new ObjectResult(new
            {
                success = false,
                data = new ErrorDetails()
                {
                    message = m,
                    code = 0,
                    number = 0
                }
            });
            or.StatusCode = 400;

            return or;
        }

        public static ObjectResult OKRequestResult(string o)
        {
            var or = new ObjectResult(new
            {
                success = true,
                data = new
                {
                    message = o.ToString(),
                    action = "Cerrar"
                }
            });
            or.StatusCode = 200;

            return or;
        }

        public static Task<ObjectResult> OkRequestTaskResult(object o)
        {
            return Task.FromResult(OkRequestResult(o));
        }
        public static Task<ObjectResult> SuccessTaskResult(string m)
        {
            return Task.FromResult(OKRequestResult(m));
        }


        public static Task<ObjectResult> BadRequestTaskResult(SqlException e)
        {

            var or = new ObjectResult(new
            {
                success = false,
                data = new ErrorDetails()
                {
                    message = e.Message,
                    code = e.ErrorCode,
                    number = e.Number
                }
            });
            or.StatusCode = 400;

            return Task.FromResult(or);
        }

        public static Task<ObjectResult> BadRequestTaskResult(Exception e)
        {
            var or = new ObjectResult(new CustomObjectResult
            {
                success = false,
                data = new ErrorDetails()
                {
                    message = e.Message
                }
            });
            or.StatusCode = 400;


            var isSql = e as SqlException;
            if (isSql != null)
            {
                var sqlExObj = (CustomObjectResult)or.Value;
                sqlExObj.data = new ErrorDetails()
                {
                    message = isSql.Message,
                    code = isSql.ErrorCode,
                    number = isSql.Number
                };
            }

            return Task.FromResult(or);
        }

        public static Task<ObjectResult> BadRequestTaskResult(string o)
        {

            return Task.FromResult(BadRequestResult(o));
        }

        public static ObjectResult BadRequestResult(string[] o)
        {
            var or = new ObjectResult(new
            {
                success = false,
                data = new ErrorDetails()
                {
                    message = String.Join(",", o),
                    code = 0,
                    number = 0
                }
            });
            or.StatusCode = 400;
            return or;
        }

        public static Task<ObjectResult> FromResult(ObjectResult o)
        {
            return Task.FromResult<ObjectResult>(o);

        }

        public static ObjectResult BadRequestResult(ModelStateDictionary modelstate)
        {

            var errorList = modelstate.ToDictionary(
                kvp => kvp.Key,
                kvp => String.Join(",", kvp.Value.Errors.Select(e => string.IsNullOrEmpty(e.ErrorMessage) ? e.Exception.Message : e.ErrorMessage).ToArray())
            );

            var or = new ObjectResult(new
            {
                success = false,
                data = new ErrorDetails()
                {
                    message = String.Join(",", errorList.Select(s => s.Value).ToArray()),
                    code = 0,
                    number = 0
                }
            });
            or.StatusCode = 400;

            return or;
        }
    }
}

/**
1×× Informational
100 Continue
101 Switching Protocols
102 Processing
2×× Success
200 OK
201 Created
202 Accepted
203 Non-authoritative Information
204 No Content
205 Reset Content
206 Partial Content
207 Multi-Status
208 Already Reported
226 IM Used
3×× Redirection
300 Multiple Choices
301 Moved Permanently
302 Found
303 See Other
304 Not Modified
305 Use Proxy
307 Temporary Redirect
308 Permanent Redirect
4×× Client Error
400 Bad Request
401 Unauthorized
402 Payment Required
403 Forbidden
404 Not Found
405 Method Not Allowed
406 Not Acceptable
407 Proxy Authentication Required
408 Request Timeout
409 Conflict
410 Gone
411 Length Required
412 Precondition Failed
413 Payload Too Large
414 Request-URI Too Long
415 Unsupported Media Type
416 Requested Range Not Satisfiable
417 Expectation Failed
418 I'm a teapot
421 Misdirected Request
422 Unprocessable Entity
423 Locked
424 Failed Dependency
426 Upgrade Required
428 Precondition Required
429 Too Many Requests
431 Request Header Fields Too Large
444 Connection Closed Without Response
451 Unavailable For Legal Reasons
499 Client Closed Request
5×× Server Error
500 Internal Server Error
501 Not Implemented
502 Bad Gateway
503 Service Unavailable
504 Gateway Timeout
505 HTTP Version Not Supported
506 Variant Also Negotiates
507 Insufficient Storage
508 Loop Detected
510 Not Extended
511 Network Authentication Required
599 Network Connect Timeout Error


 */
