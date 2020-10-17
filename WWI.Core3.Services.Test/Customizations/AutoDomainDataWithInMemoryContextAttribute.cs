using AutoFixture;
using AutoFixture.Xunit2;

namespace WWI.Core3.Services.Test.Customizations
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
