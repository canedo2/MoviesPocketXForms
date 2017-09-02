/*namespace MoviesPocketXForms.Providers.StorageProvider
{
	using Plugin.Settings;
	using Plugin.Settings.Abstractions;
    public class LocalStorage
    {
        public LocalStorage()
        {
            
        }
    }
}

namespace gistekpr
{
	/// <summary>
	/// This is the Settings static class that can be used in your Core solution or in any
	/// of your client applications. All settings are laid out the same exact way with getters
	/// and setters. 
	/// </summary>
	public static class Settings
	{
		private static ISettings AppSettings
		{
			get
			{
				return CrossSettings.Current;
			}
		}

		#region Setting Constants
		const string UserIdKey = "userid";
		static readonly string UserIdDefault = string.Empty;

		const string AuthTokenKey = "authtoken";
		static readonly string AuthTokenDefault = string.Empty;

		const string UserEmailKey = "useremail";
		static readonly string UserEmailDefault = string.Empty;

		const string UserCodAutosKey = "usercodautos";
		static readonly string UserCodAutosDefault = string.Empty;

		const string UserCodDiversosKey = "usercoddiversos";
		static readonly string UserCodDiversosDefault = string.Empty;

		const string UserPasswordKey = "userpassword";
		static readonly string UserPasswordDefault = string.Empty;
		#endregion

		public static string UserId
		{
			get
			{
				return AppSettings.GetValueOrDefault<string>(UserIdKey, UserIdDefault);
			}
			set
			{
				AppSettings.AddOrUpdateValue<string>(UserIdKey, value);
			}
		}

		public static string AuthToken
		{
			get
			{
				return AppSettings.GetValueOrDefault<string>(AuthTokenKey, AuthTokenDefault);
			}
			set
			{
				AppSettings.AddOrUpdateValue<string>(AuthTokenKey, value);
			}
		}

		public static string UserEmail
		{
			get
			{
				return AppSettings.GetValueOrDefault<string>(UserEmailKey, UserEmailDefault);
			}
			set
			{
				AppSettings.AddOrUpdateValue<string>(UserEmailKey, value);
			}
		}

		public static string CodAutos
		{
			get
			{
				return AppSettings.GetValueOrDefault<string>(UserCodAutosKey, UserCodAutosDefault);
			}
			set
			{
				AppSettings.AddOrUpdateValue<string>(UserCodAutosKey, value);
			}
		}

		public static string CodDiversos
		{
			get
			{
				return AppSettings.GetValueOrDefault<string>(UserCodDiversosKey, UserCodDiversosDefault);
			}
			set
			{
				AppSettings.AddOrUpdateValue<string>(UserCodDiversosKey, value);
			}
		}

		public static string UserPassword
		{
			get
			{
				return AppSettings.GetValueOrDefault<string>(UserPasswordKey, UserPasswordDefault);
			}
			set
			{
				AppSettings.AddOrUpdateValue<string>(UserPasswordKey, value);
			}
		}

		public static bool IsLoggedIn => !string.IsNullOrWhiteSpace(UserEmail);
	}
}
*/