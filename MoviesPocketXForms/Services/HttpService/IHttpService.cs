﻿namespace MoviesPocketXForms.Services
{
	using System.Net.Http;
	using System.Threading.Tasks;

    using Models;
    using System.Collections.Generic;
    public interface IHttpService
	{
		Task<List<Media>> GetAsyncService<T>(string url);

		Task<T> PostAsync<T>(string url, HttpContent content);
	}
}
