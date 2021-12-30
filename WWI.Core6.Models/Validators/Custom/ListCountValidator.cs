using FluentValidation;
using FluentValidation.Validators;

namespace WWI.Core6.Models.Validators.Custom;

/// <summary>
/// 
/// </summary>
/// <typeparam name="T"></typeparam>
/// <typeparam name="TCollectionElement"></typeparam>
public class ListCountValidator<T, TCollectionElement> : PropertyValidator<T, IList<TCollectionElement>> {
    
    private readonly int _max;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="max"></param>
    public ListCountValidator(int max) {
        _max = max;
    }

    public override bool IsValid(ValidationContext<T> context, IList<TCollectionElement> list) {
        
        if(list != null && list.Count >= _max) {
            context.MessageFormatter.AppendArgument("MaxElements", _max);
            return false;
        }

        return true;
    }

    public override string Name 
        => "ListCountValidator";

    /// <summary>
    /// 
    /// </summary>
    /// <param name="errorCode"></param>
    /// <returns></returns>
    protected override string GetDefaultMessageTemplate(string errorCode)
        => "{PropertyName} must contain fewer than {MaxElements} items.";
}