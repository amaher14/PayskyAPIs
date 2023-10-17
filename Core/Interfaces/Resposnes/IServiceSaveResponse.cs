namespace Core.Interfaces.Resposnes
{
    using System.Collections.Generic;
    public interface IServiceSaveResponse<TEntity>
    {
        TEntity Model { get; set; }
        bool Success { get; set; }
        string Message { get; set; }
        int StatusCode { get; set; }
        IList<TEntity> ModelList { get; set; }
        ServiceSaveResponse<TEntity> CreateResponse(TEntity model, bool success, string message);
        ServiceSaveResponse<TEntity> CreateResponse(int statusCode, bool success);
        ServiceSaveResponse<TEntity> CreateListResponse(IList<TEntity> models, bool success, string message);
        
    }

    public class ServiceSaveResponse<TEntity> : IServiceSaveResponse<TEntity>
    {
        public TEntity Model { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
        public int StatusCode { get; set; }
        public IList<TEntity> ModelList { get; set; }
        public ServiceSaveResponse()
        {
        }
        public ServiceSaveResponse(TEntity model, bool success, string message)
        {
            Model = model;
            Success = success;
            Message = message;
        }
        public ServiceSaveResponse(IList<TEntity> models, bool success, string message)
        {
            ModelList = models;
            Success = success;
            Message = message;
        }
        public ServiceSaveResponse<TEntity> CreateResponse(int statusCode, bool success)
        {

            Success = success;
            StatusCode = statusCode;
            return this;
        }
        public ServiceSaveResponse<TEntity> CreateResponse(TEntity model, bool success, string message)
        {
            Model = model;
            Success = success;
            Message = message;
            return this;
        }
     
        public ServiceSaveResponse<TEntity> CreateListResponse(IList<TEntity> models, bool success, string message)
        {
            ModelList = models;
            Success = success;
            Message = message;
            return this;
        }
    }
}