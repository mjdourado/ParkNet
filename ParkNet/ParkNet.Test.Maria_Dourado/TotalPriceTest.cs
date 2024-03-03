public class TotalPriceTest
{
    private readonly object _ticketRepository;

    public TotalPriceTest(TicketRepository ticketRepository)
    {
        _ticketRepository = ticketRepository;
    }

    [Theory]
    [InlineData(VehicleType.Motorcycle, 30, 0.30)]
    [InlineData(VehicleType.Car, 30, 0.50)]
    [InlineData(VehicleType.Motorcycle, 75, 1)]
    [InlineData(VehicleType.Car, 5, 0.30)]
    public void TestingTotalPrice(VehicleType type, decimal totaltime, decimal expectedPrice)
    {
        // Arrange
        var ticketRepositoryMock = new Mock<TicketRepository>();
        ticketRepositoryMock.Setup(x => x.TotalPrice(It.IsAny<VehicleType>(), It.IsAny<decimal>()))
            .Returns((VehicleType v, decimal t) =>
            {
                if (t <= 15)
                {
                    return 0.30m;
                }
                else if (t <= 30m)
                {
                    return 0.50m;
                }
                else if (t <= 60)
                {
                    return 1;
                }
                else
                {
                    return 1 * (t / 60);
                }
            });

        var totalPriceTest = new TotalPriceTest(ticketRepositoryMock.Object);

        // Act
        totalPriceTest.TestingTotalPrice(type, totaltime, expectedPrice);

        // Assert
        //Assert.Equal(expectedPrice, totalPriceTest.TestingTotalPrice(type, totaltime, expectedPrice));
    }
}