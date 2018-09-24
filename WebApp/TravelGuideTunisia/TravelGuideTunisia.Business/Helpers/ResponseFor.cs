using TravelGuideTunisia.Business.Base.Classes;
using RH.Standards.Domain;
using RH.Standards.Helpers;

namespace TravelGuideTunisia.Business.Helpers
{
    public static class ResponseFor<T> where T : class
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static ResultOfType<T> AsOK()
        {
            return new Return<T>().OK().WithDefaultResult();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ResultOfType<T> AsOK(T data)
        {
            return new Return<T>().OK().WithResult(data);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static ResultOfType<T> AsBadRequest(EErrorType type, string message)
        {
            return new Return<T>()
                    .Error()
                    .As(EStatusDetail.BadRequest)
                    .AddingError(new ErrorBase
                    {
                        Type = type,
                        Code = null,
                        Message = message
                    })
                    .WithDefaultResult();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="message"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ResultOfType<T> AsBadRequest(EErrorType type, string message, T data)
        {
            return new Return<T>()
                    .Error()
                    .As(EStatusDetail.BadRequest)
                    .AddingError(new ErrorBase
                    {
                        Type = type,
                        Code = null,
                        Message = message
                    })
                    .WithResult(data);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="error"></param>
        /// <returns></returns>
        public static ResultOfType<T> AsBadRequest(ErrorBase error)
        {
            return new Return<T>()
                    .Error()
                    .As(EStatusDetail.BadRequest)
                    .AddingError(error)
                    .WithDefaultResult();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="error"></param>
        /// <returns></returns>
        public static ResultOfType<T> AsBadRequest(ErrorBase error, T data)
        {
            return new Return<T>()
                    .Error()
                    .As(EStatusDetail.BadRequest)
                    .AddingError(error)
                    .WithResult(data);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static ResultOfType<T> AsUnauthorized(EErrorType type, string message)
        {
            return new Return<T>()
                    .Error()
                    .As(EStatusDetail.Unauthorized)
                    .AddingError(new ErrorBase
                    {
                        Type = type,
                        Code = null,
                        Message = message
                    })
                    .WithDefaultResult();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="message"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ResultOfType<T> AsUnauthorized(EErrorType type, string message, T data)
        {
            return new Return<T>()
                    .Error()
                    .As(EStatusDetail.Unauthorized)
                    .AddingError(new ErrorBase
                    {
                        Type = type,
                        Code = null,
                        Message = message
                    })
                    .WithResult(data);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="error"></param>
        /// <returns></returns>
        public static ResultOfType<T> AsUnauthorized(ErrorBase error)
        {
            return new Return<T>()
                    .Error()
                    .As(EStatusDetail.Unauthorized)
                    .AddingError(error)
                    .WithDefaultResult();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="error"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ResultOfType<T> AsUnauthorized(ErrorBase error, T data)
        {
            return new Return<T>()
                    .Error()
                    .As(EStatusDetail.Unauthorized)
                    .AddingError(error)
                    .WithResult(data);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static ResultOfType<T> AsForbidden(EErrorType type, string message)
        {
            return new Return<T>().Error()
                .As(EStatusDetail.Forbidden)
                .AddingError(new ErrorBase
                {
                    Type = type,
                    Code = null,
                    Message = message
                }).WithDefaultResult();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="message"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ResultOfType<T> AsForbidden(EErrorType type, string message, T data)
        {
            return new Return<T>().Error()
                .As(EStatusDetail.Forbidden)
                .AddingError(new ErrorBase
                {
                    Type = type,
                    Code = null,
                    Message = message
                }).WithResult(data);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="error"></param>
        /// <returns></returns>
        public static ResultOfType<T> AsForbidden(ErrorBase error)
        {
            return new Return<T>().Error()
                .As(EStatusDetail.Forbidden)
                .AddingError(error)
                .WithDefaultResult();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="error"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ResultOfType<T> AsForbidden(ErrorBase error, T data)
        {
            return new Return<T>().Error()
                .As(EStatusDetail.Forbidden)
                .AddingError(error)
                .WithResult(data);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static ResultOfType<T> AsNotFound(EErrorType type, string message)
        {
            return new Return<T>().Error()
                .As(EStatusDetail.NotFound)
                .AddingError(new ErrorBase
                {
                    Type = type,
                    Code = null,
                    Message = message
                }).WithDefaultResult();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="message"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ResultOfType<T> AsNotFound(EErrorType type, string message, T data)
        {
            return new Return<T>().Error()
                .As(EStatusDetail.NotFound)
                .AddingError(new ErrorBase
                {
                    Type = type,
                    Code = null,
                    Message = message
                }).WithResult(data);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="error"></param>
        /// <returns></returns>
        public static ResultOfType<T> AsNotFound(ErrorBase error)
        {
            return new Return<T>().Error()
                .As(EStatusDetail.NotFound)
                .AddingError(error)
                .WithDefaultResult();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="error"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ResultOfType<T> AsNotFound(ErrorBase error, T data)
        {
            return new Return<T>().Error()
                .As(EStatusDetail.NotFound)
                .AddingError(error)
                .WithResult(data);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static ResultOfType<T> AsConflict(EErrorType type, string message)
        {
            return new Return<T>().Error()
                .As(EStatusDetail.Conflict)
                .AddingError(new ErrorBase
                {
                    Type = type,
                    Code = null,
                    Message = message
                }).WithDefaultResult();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="message"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ResultOfType<T> AsConflict(EErrorType type, string message, T data)
        {
            return new Return<T>().Error()
                .As(EStatusDetail.Conflict)
                .AddingError(new ErrorBase
                {
                    Type = type,
                    Code = null,
                    Message = message
                }).WithResult(data);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="error"></param>
        /// <returns></returns>
        public static ResultOfType<T> AsConflict(ErrorBase error)
        {
            return new Return<T>().Error()
                .As(EStatusDetail.Conflict)
                .AddingError(error)
                .WithDefaultResult();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="error"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ResultOfType<T> AsConflict(ErrorBase error, T data)
        {
            return new Return<T>().Error()
                .As(EStatusDetail.Conflict)
                .AddingError(error)
                .WithResult(data);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static ResultOfType<T> AsInternalServerError(EErrorType type, string message)
        {
            return new Return<T>().Error()
                .As(EStatusDetail.InternalServerError)
                .AddingError(new ErrorBase
                {
                    Type = type,
                    Code = null,
                    Message = message
                }).WithDefaultResult();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="message"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ResultOfType<T> AsInternalServerError(EErrorType type, string message, T data)
        {
            return new Return<T>().Error()
                .As(EStatusDetail.InternalServerError)
                .AddingError(new ErrorBase
                {
                    Type = type,
                    Code = null,
                    Message = message
                }).WithResult(data);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="error"></param>
        /// <returns></returns>
        public static ResultOfType<T> AsInternalServerError(ErrorBase error)
        {
            return new Return<T>().Error()
                .As(EStatusDetail.InternalServerError)
                .AddingError(error)
                .WithDefaultResult();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="error"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ResultOfType<T> AsInternalServerError(ErrorBase error, T data)
        {
            return new Return<T>().Error()
                .As(EStatusDetail.InternalServerError)
                .AddingError(error)
                .WithResult(data);
        }

        /// <summary>
        /// AsTooManyRequests
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static ResultOfType<T> AsTooManyRequests( string message)
        {
            return new Return<T>().Error()
                .As((EStatusDetail) (Models.SMSCheck.EStatusDetail.TooManyRequests))
                     .AddingError(new ErrorBase
                     {
                         Type = EErrorType.GENERIC_ERROR,
                         Code = "429",
                         Message = message
                     })
                .WithDefaultResult();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static ResultOfType<T> AsHttp200()
        {
            return AsOK();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ResultOfType<T> AsHttp200(T data)
        {
            return AsOK(data);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static ResultOfType<T> AsHttp400(EErrorType type, string message)
        {
            return AsBadRequest(type, message);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="message"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ResultOfType<T> AsHttp400(EErrorType type, string message, T data)
        {
            return AsBadRequest(type, message, data);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="error"></param>
        /// <returns></returns>
        public static ResultOfType<T> AsHttp400(ErrorBase error)
        {
            return AsBadRequest(error);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="error"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ResultOfType<T> AsHttp400(ErrorBase error, T data)
        {
            return AsBadRequest(error, data);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static ResultOfType<T> AsHttp401(EErrorType type, string message)
        {
            return AsUnauthorized(type, message);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="message"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ResultOfType<T> AsHttp401(EErrorType type, string message, T data)
        {
            return AsUnauthorized(type, message, data);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="error"></param>
        /// <returns></returns>
        public static ResultOfType<T> AsHttp401(ErrorBase error)
        {
            return AsUnauthorized(error);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="error"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ResultOfType<T> AsHttp401(ErrorBase error, T data)
        {
            return AsUnauthorized(error, data);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static ResultOfType<T> AsHttp403(EErrorType type, string message)
        {
            return AsForbidden(type, message);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="message"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ResultOfType<T> AsHttp403(EErrorType type, string message, T data)
        {
            return AsForbidden(type, message, data);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="error"></param>
        /// <returns></returns>
        public static ResultOfType<T> AsHttp403(ErrorBase error)
        {
            return AsForbidden(error);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="error"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ResultOfType<T> AsHttp403(ErrorBase error, T data)
        {
            return AsForbidden(error, data);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static ResultOfType<T> AsHttp404(EErrorType type, string message)
        {
            return AsNotFound(type, message);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="message"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ResultOfType<T> AsHttp404(EErrorType type, string message, T data)
        {
            return AsNotFound(type, message, data);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="error"></param>
        /// <returns></returns>
        public static ResultOfType<T> AsHttp404(ErrorBase error)
        {
            return AsNotFound(error);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="error"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ResultOfType<T> AsHttp404(ErrorBase error, T data)
        {
            return AsNotFound(error, data);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static ResultOfType<T> AsHttp409(EErrorType type, string message)
        {
            return AsConflict(type, message);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="message"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ResultOfType<T> AsHttp409(EErrorType type, string message, T data)
        {
            return AsConflict(type, message, data);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="error"></param>
        /// <returns></returns>
        public static ResultOfType<T> AsHttp409(ErrorBase error)
        {
            return AsConflict(error);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="error"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ResultOfType<T> AsHttp409(ErrorBase error, T data)
        {
            return AsConflict(error, data);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static ResultOfType<T> AsHttp500(EErrorType type, string message)
        {
            return AsInternalServerError(type, message);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="message"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ResultOfType<T> AsHttp500(EErrorType type, string message, T data)
        {
            return AsInternalServerError(type, message, data);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="error"></param>
        /// <returns></returns>
        public static ResultOfType<T> AsHttp500(ErrorBase error)
        {
            return AsInternalServerError(error);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="error"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ResultOfType<T> AsHttp500(ErrorBase error, T data)
        {
            return AsInternalServerError(error, data);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static ResultOfType<T> AsHttp429(string message)
        {
            return AsTooManyRequests( message);
        }
    }
}