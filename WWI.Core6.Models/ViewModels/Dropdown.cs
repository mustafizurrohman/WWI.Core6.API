using JetBrains.Annotations;

namespace WWI.Core6.Models.ViewModels
{

    /// <summary>
    /// Class Dropdown.
    /// </summary>
    public class Dropdown
    {

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        [UsedImplicitly]
        public int ID { get; init; }

        /// <summary>
        /// Gets or sets the display value.
        /// </summary>
        /// <value>The display value.</value>
        [UsedImplicitly]
        public string DisplayValue { get; init; }
    }
}
