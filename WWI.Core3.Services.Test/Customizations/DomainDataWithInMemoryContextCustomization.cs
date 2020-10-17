using AutoFixture;
using AutoFixture.AutoMoq;
using EntityFrameworkCore.AutoFixture.InMemory;

namespace WWI.Core3.Services.Test.Customizations
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
