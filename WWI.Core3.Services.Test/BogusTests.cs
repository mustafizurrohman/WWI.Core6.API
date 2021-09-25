using Bogus;
using FluentAssertions;
using WWI.Core3.Models.Models;
using Xunit;

namespace WWI.Core3.Services.Test
{
    public class BogusTests
    {
        [Theory]
        [InlineData(10)]
        public void GenerateDoctors(int numberOfDoctors)
        {
            var doctorsFaker = new Faker<Doctor>()
                .StrictMode(false)
                .RuleFor(doc => doc.Firstname, fake => fake.Name.FirstName())
                .RuleFor(doc => doc.Lastname, fake => fake.Name.LastName())
                .RuleFor(doc => doc.SpecialityID, fake => fake.UniqueIndex)
                .RuleFor(doc => doc.Middlename, fake => fake.Name.LastName());

            var test = doctorsFaker.Generate(numberOfDoctors);

            test.Count
                .Should()
                .Be(numberOfDoctors);

        }

    }
}
