using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Security.Principal;
using System.Web;

namespace Rhino.Igloo
{
	/// <summary>
	/// Abstract the HttpContext into an interface that can be mocked.
	/// </summary>
	public interface IContext
	{
		/// <summary>
		/// Redirects the specified destination.
		/// </summary>
		/// <param myName="destination">The destination.</param>
		void Redirect(string destination);

		/// <summary>
		/// Gets the variable from the user input
		/// </summary>
		/// <param name="key">The key.</param>
		string GetInputVariable(string key);

	    /// <summary>
	    /// Gets the input variables (multiplies of them).
	    /// </summary>
	    /// <param name="key">The key.</param>
	    string[] GetMultiplyInputVariables(string key);

		/// <summary>
		/// Gets the variable from the session.
		/// </summary>
		/// <param name="key">The key.</param>
		object GetFromSession(string key);

		/// <summary>
		/// Sets the variable at the session level.
		/// </summary>
		/// <param name="key">The key.</param>
		/// <param name="value">The value.</param>
		void SetAtSession(string key, object value);

		/// <summary>
		/// Authenticates the user and redirect to the destination
		/// </summary>
		/// <param name="destination">The destination.</param>
		/// <param name="user">The user.</param>
	    void AuthenticateAndRedirect(string destination,string user);

		/// <summary>
		/// Signs the user out of the system
		/// </summary>
	    void SignOut();

		/// <summary>
		/// Gets the identity of the current user
		/// </summary>
		/// <value>The identity.</value>
		IIdentity Identity { get; }

        /// <summary>
        /// Gets the uploaded files.
        /// </summary>
        /// <value>The uploaded files.</value>
        IList<UploadedFile> UploadedFiles { get; }

        /// <summary>
        /// Gets the full path from a relative or ~/ one
        /// </summary>
        /// <param name="directory">The directory.</param>
        /// <returns></returns>
	    string GetFullPath(string directory);

        /// <summary>
        /// Ensures that the directory exists.
        /// </summary>
        /// <param name="path">The path.</param>
	    void EnsureDirectoryExists(string path);
	}
}