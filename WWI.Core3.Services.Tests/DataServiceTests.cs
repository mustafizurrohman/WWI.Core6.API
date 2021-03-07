// ***********************************************************************
// Assembly         : WWI.Core3.Services.Tests
// Author           : Mustafizur Rohman
// Created          : 10-03-2020
//
// Last Modified By : Mustafizur Rohman
// Last Modified On : 10-03-2020
// ***********************************************************************
// <copyright file="DataServiceTests.cs" company="WWI.Core3.Services.Tests">
//     Copyright (c) Personal. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using AutoFixture;
using AutoFixture.Xunit2;
using Xunit;

namespace WWI.Core3.Services.Tests
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
        /// <param name="fixture">The fixture.</param>
        /// <param name="numberOfHospitalsToRetrieve">The number of hospitals to retrieve.</param>
        [Theory, AutoData]
        public void IntroductoryTestAsync(IFixture fixture, int numberOfHospitalsToRetrieve)
        {

            // Arrange
            // fixture = fixture.Customize(new AutoMoqCustomization());

            //var hospitals = fixture.CreateMany<Hospital>(numberOfHospitalsToRetrieve).AsQueryable();

            //var dbContext = fixture.Freeze<Mock<DocAppointmentContext>>();
            //dbContext.Setup(dbc => dbc.Hospitals.AsQueryable()).Returns(hospitals);

            //var id = hospitals.ToList().GetRandomShuffled().HospitalID;

            // var dataService2 = Mock<IDataService>();

            // Act
            // var retrievedHospital = await dataService.GetHospitalInformationByIDAsync(id);

            // Assert
            //retrievedHospital.HospitalID
            //    .Should()
            //    .Be(id);


        }

        private object Mock<T>()
        {
            throw new System.NotImplementedException();
        }
    }

}
