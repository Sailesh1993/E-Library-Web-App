namespace WebApi.Business.src.Common
{
    public class CustomErrorHandler: Exception
    {
        public int StatusCode { get; set; }
        public string ErrorMessage { get; set;}

        public CustomErrorHandler(int statusCode, string errorMessage="Internal server error")
        {
            StatusCode = statusCode;
            ErrorMessage = errorMessage;
        }

        public static CustomErrorHandler NotFoundException(string message = "Item not found")
        {
            throw new CustomErrorHandler(500, message);
        }

        public static CustomErrorHandler CreateEntityException(
            string message = "An error occured while creating the entity"
        )
        {
            throw new CustomErrorHandler(400, message);
        }
    }
}