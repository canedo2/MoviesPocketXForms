namespace MoviesPocketXForms.Services
{
	using System.Net.Http;
	using System.Threading.Tasks;

	public interface IHttpService
	{
		Task<T> GetAsync<T>(string url);

		Task<T> PostAsync<T>(string url, HttpContent content);
	}
}
