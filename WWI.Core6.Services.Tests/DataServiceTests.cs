// ***********************************************************************
// Assembly         : WWI.Core6.Services.Tests
// Author           : Mustafizur Rohman
// Created          : 10-03-2020
//
// Last Modified By : Mustafizur Rohman
// Last Modified On : 10-03-2020
// ***********************************************************************
// <copyright file="DataServiceTests.cs" company="WWI.Core6.Services.Tests">
//     Copyright (c) Personal. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixture.Kernel;
using AutoMapper;
using EntityFrameworkCore.AutoFixture.InMemory;
using FluentAssertions;
using MockQueryable.Moq;
using Moq;
using WWI.Core6.Core.ExtensionMethods;
using WWI.Core6.Models.DbContext;
using WWI.Core6.Models.Models;
using WWI.Core6.Models.ViewModels;
using WWI.Core6.Services.ServiceCollection;
using WWI.Core6.Services.Services;
using WWI.Core6.Services.Services.Shared;
using WWI.Core6.Services.Tests.Automapper;
using WWI.Core6.Services.Tests.Customizations;
using Xunit;

namespace WWI.Core6.Services.Tests
{

    // TODO: Finish this
    /// <summary>
    /// Class DataServiceTests.
    /// </summary>
    public class DataServiceTests
    {
        /// <summary>
        /// introductory test as an asynchronous operation.
        /// </summary>
        /// <param name="numberOfHospitalsToRetrieve">The number of hospitals to retrieve.</param>
        // [Theory(Skip = "Not working. Needs to be fixed."), AutoData]
        [Theory]
        [InlineData(2)]
        public void IntroductoryTest(int numberOfHospitalsToRetrieve)
        {

            // Arrange
            var fixture = new Fixture()
                .Customize(new AutoMoqCustomization());
            fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
                .ForEach(b => fixture.Behaviors.Remove(b));
            fixture.Behaviors.Add(new OmitOnRecursionBehavior(1));

            fixture.Customizations.Add(
                new TypeRelay(
                    typeof(IConfigurationProvider),
                    typeof(MapperConfiguration)));

            var hospitals = fixture.CreateMany<Hospital>(numberOfHospitalsToRetrieve);

            var hospitalsMock = hospitals.AsQueryable().BuildMockDbSet();

            var dbContextMock = new Mock<DocAppointmentContext>();

            var autoMapper = new Mock<IMapper>();

            var hospitalInformationList =
                AutomapperSingleton.AutoMapper.Map<IEnumerable<Hospital>, IEnumerable<HospitalInformation>>(hospitals);

            //autoMapper.Setup(m => m.ProjectTo<HospitalInformation>(It.IsAny<IQueryable<Hospital>>()))
            //    .Returns(hospitalInformationList);

            var applicationServiceMock = new Mock<ApplicationServices>(dbContextMock.Object, autoMapper.Object);
            var sharedServiceMock = new Mock<SharedService>(dbContextMock.Object, autoMapper.Object);

            var dataService = new Mock<DataService>(applicationServiceMock.Object, sharedServiceMock.Object);

            var randomId = hospitalsMock.Object.ToList().GetRandomShuffled().HospitalID;

            // Act
            //var retrivedHospital = await dataService.Object.GetHospitalInformationByIDAsync(randomId);

        }

        // DocAppointmentContext docAppointmentContext
        [Theory(Skip = "Not working. Needs to be fixed."), AutoDomainDataWithInMemoryContext]
#pragma warning disable xUnit1006 // Theory methods should have parameters
        public async Task TestInMemoryDatabase()
#pragma warning restore xUnit1006 // Theory methods should have parameters
        {
            var fixture = new Fixture().Customize(new InMemoryContextCustomization());

            fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
                .ForEach(b => fixture.Behaviors.Remove(b));
            fixture.Behaviors.Add(new OmitOnRecursionBehavior(1));

            var hospital = fixture.Create<Hospital>();


            await using var docAppointmentContext = fixture.Create<DocAppointmentContext>();
            await docAppointmentContext.Database.EnsureCreatedAsync();

            await docAppointmentContext.Hospitals.AddAsync(hospital);
            await docAppointmentContext.SaveChangesAsync();

            docAppointmentContext.Hospitals.Should().Contain(x => x.Name == hospital.Name);

            

        }


    }

}
