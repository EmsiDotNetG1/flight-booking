using AutoFixture;
using AutoFixture.Xunit2;
using Emsi.FlightBooking.Flights;
using Emsi.FlightBooking.Infrastructure.Abstraction;
using Emsi.FlightBooking.Infrastructure.DAO;
using Emsi.FlightBooking.Models;
using MapsterMapper;
using Moq;
using Xunit;

namespace Emsi.FlightBooking.Tests;

public class FlightsServiceTests : TestsBase
{
    // System Under Test
    private readonly FlightsService _sut;
    
    // Dependencies
    private readonly Mock<IFlightsRepository> _repositoryMock = new();
    
    public FlightsServiceTests()
    {
        _sut = new FlightsService(_repositoryMock.Object, Mapper);
    }

    [Fact]
    public void TestAdd()
    {
        //arrange : jeux de donéne
        int a = 5;
        int b = 10;
        
        //act : appel / traitement
        int actual = a + b;
        
        //assert : verification
        Assert.Equal(15, actual);
    }
    
    [Theory]
    [AutoData]
    public async Task SearchFlightsAsync_SimpleDeparture_ReturnsFlights(string departureFrom, string arrivalTo, DateTime departureDateTime, bool directFlight)
    {
        //arrange
        var departureDate = DateOnly.FromDateTime(departureDateTime);
        var flightsDao = Fixture.CreateMany<FlightDao>(10).ToList();
        
        flightsDao[0].DepartureFrom = departureFrom;
        flightsDao[0].ArrivalTo = arrivalTo;
        flightsDao[0].DepartureDate = departureDateTime;
        if(directFlight)
            flightsDao[0].DirectFlight = directFlight;
        
        _repositoryMock.Setup(m => m.GetAll()).Returns(flightsDao.AsQueryable());
        
        //act
        var actual = await _sut.SearchFlightsAsync(departureFrom, arrivalTo, departureDate, null, directFlight);
        
        //assert
        Assert.NotNull(actual);
        Assert.NotEmpty(actual);
        Assert.Single(actual);
    }
    
    [Theory]
    [AutoData]
    public async Task SearchFlightsAsync_RoundTrip_ReturnsFlights(string departureFrom, string arrivalTo, DateTime departureDateTime, DateTime returnDateTime, bool directFlight)
    {
        //arrange
        var departureDate = DateOnly.FromDateTime(departureDateTime);
        var returnDate = DateOnly.FromDateTime(returnDateTime);
        
        var flightsDao = Fixture.CreateMany<FlightDao>(10).ToList();
        
        //departure
        flightsDao[0].DepartureFrom = departureFrom;
        flightsDao[0].ArrivalTo = arrivalTo;
        flightsDao[0].DepartureDate = departureDateTime;
        if(directFlight)
            flightsDao[0].DirectFlight = directFlight;
        
        //return
        flightsDao[1].DepartureFrom = arrivalTo;
        flightsDao[1].ArrivalTo = departureFrom;
        flightsDao[1].DepartureDate = returnDateTime;
        if(directFlight)
            flightsDao[1].DirectFlight = directFlight;
        _repositoryMock.Setup(m => m.GetAll()).Returns(flightsDao.AsQueryable());
        
        //act
        var actual = await _sut.SearchFlightsAsync(departureFrom, arrivalTo, departureDate, returnDate, directFlight);
        
        //assert
        Assert.NotNull(actual);
        Assert.NotEmpty(actual);
        Assert.Equal(2, actual.Count);
    }
}