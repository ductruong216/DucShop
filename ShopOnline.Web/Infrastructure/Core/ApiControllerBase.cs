using ShopOnline.Model.Models;
using ShopOnline.Service;
using System;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ShopOnline.Web.Infrastructure.Core
{
    public class ApiControllerBase : ApiController
    {
        private IErrorService _errorService;

        public ApiControllerBase(IErrorService errorService)
        {
            _errorService = errorService;
        }

        public HttpResponseMessage CreateHttpResponse(HttpRequestMessage requestMessage, Func<HttpResponseMessage> function)
        {
            HttpResponseMessage response = null;
            try
            {
                response = function.Invoke();
            }

            // Validate Db Entity
            catch (DbEntityValidationException ex)
            {
                foreach (var eve in ex.EntityValidationErrors)
                {
                    Trace.WriteLine($"Entity of type \"{eve.Entry.Entity.GetType().Name}\" in state \"{eve.Entry.State}\" has the following validation error.");
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Trace.WriteLine($"- Property: \"{ve.PropertyName}\", Error: \"{ve.ErrorMessage}\"");
                    }
                }
                LogErorr(ex);

                response = requestMessage.CreateResponse(HttpStatusCode.BadRequest, ex.InnerException.Message);
            }

            // Validate Update Database
            catch (DbUpdateException dbEx)
            {
                LogErorr(dbEx);
                response = requestMessage.CreateResponse(HttpStatusCode.BadRequest, dbEx.Message);
            }

            // Exception
            catch (Exception ex)
            {
                LogErorr(ex);
                response = requestMessage.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }

            return response;
        }

        private void LogErorr(Exception ex)
        {
            try
            {
                var error = new Error();
                error.Message = ex.Message;
                error.StackTrace = ex.StackTrace;
                error.CreatedDate = DateTime.Now;
                _errorService.Create(error);
                _errorService.Save();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}