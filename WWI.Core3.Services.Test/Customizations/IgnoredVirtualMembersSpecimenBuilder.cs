using System.Reflection;
using AutoFixture.Kernel;

namespace WWI.Core6.Services.Tests.Customizations
{
    public class IgnoredVirtualMembersSpecimenBuilder : ISpecimenBuilder
    {
        public IgnoredVirtualMembersSpecimenBuilder()
            : this(new IsVirtualMemberSpecification())
        {
        }

        private IgnoredVirtualMembersSpecimenBuilder(IRequestSpecification virtualMemberSpecification)
        {
            this.VirtualMemberSpecification = virtualMemberSpecification;
        }

        private IRequestSpecification VirtualMemberSpecification { get; }

        public object Create(object request, ISpecimenContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (!this.VirtualMemberSpecification.IsSatisfiedBy(request))
            {
                return new NoSpecimen();
            }

            return new OmitSpecimen();
        }

        private class IsVirtualMemberSpecification : IRequestSpecification
        {
            public bool IsSatisfiedBy(object request)
            {
                return request is PropertyInfo property
                       // ReSharper disable once PossibleNullReferenceException
                       && property.GetMethod.IsVirtual;
            }
        }
    }
}
