using AutoFixture;
using AutoFixture.Xunit2;

namespace WWI.Core6.Services.Tests.Customizations
{
    public class AutoDomainDataWithInMemoryContextAttribute : AutoDataAttribute
    {
        public AutoDomainDataWithInMemoryContextAttribute()
            : base(() => new Fixture()
                .Customize(new DomainDataWithInMemoryContextCustomization()))
        {
        }
    }
}
