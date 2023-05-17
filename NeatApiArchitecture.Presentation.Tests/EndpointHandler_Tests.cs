using FakeItEasy;
using Microsoft.AspNetCore.Http.HttpResults;
using NeatApiArchitecture.DomainCommons.Enteties;
using NeatApiArchitecture.DomainCommons.Interfaces;
using NeatApiArchitecture.Presentation.Endpoints.Handlers;
using NeatApiArchitecture.Presentation.Endpoints.Requests;

namespace NeatApiArchitecture.Presentation.Tests
{
	public class EndpointHandler_Tests
	{
		[Fact]
		public async Task GetAllPeopleHandler_ReturnsCollectionOfPeople()
		{
			//Arrange
			var dummyPeople = A.CollectionOfDummy<Person>(10);
			
			var fakeRepo = A.Fake<IRepository<Person>>();
			A.CallTo(() => fakeRepo.GetAllAsync()).Returns(dummyPeople);

			var sut = new GetAllPeopleHandler(fakeRepo);

			var request = A.Dummy<GetAllPeopleRequest>();
			var cancellationToken = A.Dummy<CancellationToken>();
			//Act

			var result = await sut.Handle(request, cancellationToken);

			//Assert
			Assert.IsType<Ok<IEnumerable<Person>>>(result);
		}

		[Fact]
		public async Task GetAllPeopleHandler_ReturnsCollectionOfTenPeople()
		{
			//Arrange
			var count = 10;
			var dummyPeople = A.CollectionOfDummy<Person>(20);

			var fakeRepo = A.Fake<IRepository<Person>>();
			A.CallTo(() => fakeRepo.GetAllAsync()).Returns(dummyPeople);

			var sut = new GetAllPeopleHandler(fakeRepo);

			var request = A.Dummy<GetAllPeopleRequest>();
			var cancellationToken = A.Dummy<CancellationToken>();
			//Act

			var result = await sut.Handle(request, cancellationToken);

			//Assert
			var okResult = result as Ok<IEnumerable<Person>>;
			Assert.Equal(count, okResult.Value.Count());
		}
	}
}