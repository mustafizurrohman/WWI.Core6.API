namespace WWI.Core6.Core.Exceptions
{
    public class AppSettingsValidationException : Exception
    {
        /// <summary>Initializes a new instance of the <see cref="T:WWI.Core6.Core.Exceptions.AppSettingsValidationException" /> class.</summary>
        /// <param name="message">The message that describes the error.</param>
        public AppSettingsValidationException(string message) : base(message)
        {

        }
    }
}
