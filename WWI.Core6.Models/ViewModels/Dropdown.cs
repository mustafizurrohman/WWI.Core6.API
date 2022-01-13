namespace WWI.Core6.Models.ViewModels;

/// <summary>
/// Class Dropdown.
/// </summary>
public class Dropdown
{

    /// <summary>
    /// Gets or sets the identifier.
    /// Using init because it does not makes sense to modify what we got from database
    /// </summary>
    /// <value>The identifier.</value>
    [UsedImplicitly]
    public int ID { get; init; }

    /// <summary>
    /// Gets or sets the display value.
    /// Using init because it does not makes sense to modify what we got from database
    /// </summary>
    /// <value>The display value.</value>
    [UsedImplicitly]
    public string DisplayValue { get; init; }
}