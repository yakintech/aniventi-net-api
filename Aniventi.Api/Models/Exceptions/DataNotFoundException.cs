namespace Aniventi.Api.Models.Exceptions
{
    public class DataNotFoundException : Exception
    {

        public DataNotFoundException(string id) : base($"{id} ye sahip obje bulunamadı")
        {
            
        }
    }
}
