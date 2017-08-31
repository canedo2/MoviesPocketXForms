﻿namespace MoviesPocketXForms.Providers
{
    using MoviesPocketXForms.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IWebApiProvider<MyMedia>
    {
        Task<IEnumerable<MyMedia>> GetMediaListAsync();
    }
}
