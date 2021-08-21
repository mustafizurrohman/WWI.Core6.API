using FluentValidation;
using Microsoft.Data.SqlClient;
using System;
using System.Data;

namespace WWI.Core3.Models.Validators
{
    /// <summary>
    /// Class DatabaseConnectionStringValidator.
    /// Implements the <see cref="string" />
    /// </summary>
    /// <seealso cref="string" />
    class DatabaseConnectionStringValidator : AbstractValidator<string>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseConnectionStringValidator"/> class.
        /// </summary>
        public DatabaseConnectionStringValidator()
        {
            RuleFor(connectionString => connectionString)
                .NotNull()
                .Must(BeValidConnectionString)
                .WithMessage("Database specified in connection string is not reachable");

        }

        private bool BeValidConnectionString(string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
                return false;

            SqlConnection connection = null;

            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                if (connection?.State == ConnectionState.Open)
                    connection.Close();
            }


            return true;
        }
    }
}
