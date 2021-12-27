using AutoFixture;

namespace WWI.Core6.Services.Tests.Customizations;

public class IgnoredVirtualMembersCustomization : ICustomization
{
    public void Customize(IFixture fixture)
    {
        fixture.Customizations.Add(new IgnoredVirtualMembersSpecimenBuilder());
    }
}