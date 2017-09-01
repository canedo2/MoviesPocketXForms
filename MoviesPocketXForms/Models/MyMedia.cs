
namespace MoviesPocketXForms.Models
{
    using Newtonsoft.Json;
    public class MyMedia
    {
        public MyMedia(){
            
        }

        public MyMedia(int id, string title, string posterPath, string overview, double voteAverage, string mediatype){
            this.Id = id;
            this.Title = title;
            this.PosterPath = posterPath;
            this.Overview = overview;
            this.VoteAverage = voteAverage;
            this.MediaType = mediatype;
        }

        [JsonProperty("id")]
        public int Id
        {
            get;
            set;
        }

        [JsonProperty("title")]
        public string Title
        {
            get;
            set;
        }

        [JsonProperty("poster_path")]
        public string PosterPath
        {
            get;
            set;
        }

        [JsonProperty("overview")]
        public string Overview
        {
            get;
            set;
        }

        [JsonProperty("vote_average")]
        public double VoteAverage
        {
            get;
            set;
        }

        [JsonProperty("media_type")]
        public string MediaType
        {
            get;
            set;
        }
    }

}
