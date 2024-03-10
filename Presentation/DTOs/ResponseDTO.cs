namespace GADistribuidora.Presentation.DTOs
{
    public class ResponseDTO<T>
    {
        public ResponseDTO(bool success)
        {
            Data = new List<T>();
            Errors = new List<string>();
            Success = success;
        }

        public bool Success { get; set; }
        public List<T> Data { get; set; }
        public List<string> Errors { get; set; }
        public void AddData(T data) => Data.Add(data);
        public void AddError(string errorMessage) => Errors.Add(errorMessage);
    }
}
