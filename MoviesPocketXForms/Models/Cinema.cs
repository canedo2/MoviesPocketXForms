namespace MoviesPocketXForms.Models
{
    using System;
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class Cinema
    {
		public Cinema()
		{

		}

        public Cinema(string id, string name, string rating, Geometry geometry)
		{
			this.Id = id;
			this.Name = name;
			this.Rating = rating;
			this.Geometry = geometry;
		}


		[JsonProperty("id")]
		public string Id
		{
			get;
			set;
		}

		[JsonProperty("name")]
		public string Name
		{
			get;
			set;
		}

		[JsonProperty("rating")]
		public string Rating
		{
			get;
			set;
		}

		[JsonProperty("geometry")]
        public Geometry Geometry
		{
			get;
			set;
		}

		public override string ToString()
		{
            return "{Cinema: " + Name + "\nRating: " + Rating + "\nGeometry: "+ Geometry + "}";
		}

	}

    public class Geometry
    {   
        [JsonProperty("location")]
        public Location Location{
			get;
			set;
        }

		public override string ToString()
		{
            return "{Geometry: " + Location.Lat + "," + Location.Lng+ "}";
		}
    }

    public class Location{
        [JsonProperty("lat")]
        public double Lat{
			get;
			set;  
        }

        [JsonProperty("lng")]
        public double Lng{
			get;
			set;
        }
    }


}
