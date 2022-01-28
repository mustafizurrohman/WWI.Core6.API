using Microsoft.OpenApi.Models;
using WWI.Core6.Core.Exceptions;
using WWI.Core6.Models.AppSettings;
using WWI.Core6.Models.Validators;
using ValidationResult  = FluentValidation.Results.ValidationResult;

namespace WWI.Core6.API.Helpers
{

    /// <summary>
    /// Class ApplicationSettingsUtility.
    /// </summary>
    public class ApplicationSettingsUtility
    {
        private IConfiguration Configuration { get; }
        
        /// <summary>
        /// The OpenApi information
        /// </summary>
        private readonly OpenApiInfo _info = new();
        
        /// <summary>
        /// The performance options
        /// </summary>
        private PerformanceOptions _performanceOptions = new();

        /// <summary>
        /// 
        /// </summary>
        private MediatRPipelineOptions _pipelineOptions = new();

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationSettingsUtility"/> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        public ApplicationSettingsUtility(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="AppSettingsValidationException"></exception>
        // ReSharper disable once MemberCanBePrivate.Global
        public ApplicationSettings GetApplicationSettings()
        {
            Configuration.GetSection("Swagger").Bind(_info);

            try
            {
                Configuration.GetSection("PerformanceOptions").Bind(_performanceOptions);
            }
            catch (InvalidOperationException ex)
            {
                Log.Error("Invalid boolean values for Performance Options in appsettings file. Valid values are 'true' and 'false'.");
                throw new AppSettingsValidationException(ex.Message);
            }

            try
            {
                Configuration.GetSection("MediatRPipelines").Bind(_pipelineOptions);
            }
            catch (InvalidOperationException ex)
            {
                Log.Error("Invalid boolean values for Pipeline Options in appsettings file. Valid values are 'true' and 'false'.");
                throw new AppSettingsValidationException(ex.Message);
            }

            ApplicationSettings applicationSettings = new()
            {
                OpenApiInfo = _info,
                PerformanceOptions = _performanceOptions,
                ConnectionString = Configuration.GetConnectionString("AppointmentDb"),
                MediatRPipelineOptions = _pipelineOptions
            };

            return applicationSettings;
        }

        /// <summary>
        /// Verifies the application settings.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// <exception cref="AppSettingsValidationException"></exception>
        public void VerifyApplicationSettings(ApplicationSettings applicationSettings = null)
        {
            applicationSettings ??= GetApplicationSettings(); 

            ApplicationSettingsValidator validator = new();
            ValidationResult validationResult =  validator.Validate(applicationSettings);

            if (validationResult.Errors.Count == 0) 
                return;
            
            var errors = validationResult.Errors
                .Select((e, index) => (index + 1) + "- " + e)
                .Aggregate((e1, e2) => e1 + Environment.NewLine + e2);

            Log.Fatal("Invalid app settings. Please refer to the errors below");
            Log.Error(Environment.NewLine + Environment.NewLine + errors + Environment.NewLine);
            Log.Fatal("Please correct the app settings before starting the application again!!!");
            Log.Fatal("Application will now terminate ...");

            throw new AppSettingsValidationException(errors);

        }

    }
}
