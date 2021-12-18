using AutoFixture;
using AutoFixture.AutoMoq;
using EntityFrameworkCore.AutoFixture.InMemory;

namespace WWI.Core6.Services.Tests.Customizations
{
    public class DomainDataWithInMemoryContextCustomization : CompositeCustomization
    {
        public DomainDataWithInMemoryContextCustomization()
            : base(
                new IgnoredVirtualMembersCustomization(),
                new InMemoryContextCustomization(),
                new AutoMoqCustomization())
        {
        }
    }
}
