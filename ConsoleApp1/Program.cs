using congestion.calculator.Models;
using congestion.calculator.TaxCalculators;
using congestion.calculator.TaxRules;
using congestion.calculator.Vehicles;

var tollFreeDates = new List<DateRange>() {
    new DateRange(new DateTime(2013,01,01),new DateTime(2013,01,01)) ,
    new DateRange(new DateTime(2013,03,28),new DateTime(2013,03,29)) ,
    new DateRange(new DateTime(2013,04,01),new DateTime(2013,04,01)) ,
    new DateRange(new DateTime(2013,04,30),new DateTime(2013,04,30)) ,
    new DateRange(new DateTime(2013,05,01),new DateTime(2013,05,01)) ,
    new DateRange(new DateTime(2013,05,08),new DateTime(2013,05,09)) ,
    new DateRange(new DateTime(2013,06,06),new DateTime(2013,06,06)) ,
    new DateRange(new DateTime(2013,06,21),new DateTime(2013,06,21)) ,
    new DateRange(new DateTime(2013,07,01),new DateTime(2013,07,31)) ,
    new DateRange(new DateTime(2013,11,01),new DateTime(2013,11,01)) ,
    new DateRange(new DateTime(2013,12,24),new DateTime(2013,12,26)) ,
    new DateRange(new DateTime(2013,12,31),new DateTime(2013,12,31)) ,
};
var tollFreeVehicles = new List<IVehicle>() {
    new Foreign()
};

var tollFeeAmounts = new Dictionary<TimeRange, decimal>()
{
    {new TimeRange(new TimeSpan(06,00,00),new TimeSpan(06,29,00)),8},
    {new TimeRange(new TimeSpan(06,30,00),new TimeSpan(06,59,00)),13 },
    {new TimeRange(new TimeSpan(07,00,00),new TimeSpan(07,59,00)),18 },
    {new TimeRange(new TimeSpan(08,00,00),new TimeSpan(08,29,00)),13 },
    {new TimeRange(new TimeSpan(08,30,00),new TimeSpan(14,59,00)),8},
    {new TimeRange(new TimeSpan(15,00,00),new TimeSpan(15,29,00)),13 },
    {new TimeRange(new TimeSpan(15,30,00),new TimeSpan(16,59,00)),18 },
    {new TimeRange(new TimeSpan(17,00,00),new TimeSpan(17,59,00)),13 },
    {new TimeRange(new TimeSpan(18,00,00),new TimeSpan(18,29,00)),8 },
    {new TimeRange(new TimeSpan(18,30,00),new TimeSpan(05,59,00)),0},
};

var tollFeeAmountTaxRule = new TollFeeAmountTaxRule(tollFeeAmounts);
var tollFreeDaysOfWeekTaxRule = new TollFreeDaysOfWeekTaxRule(new List<DayOfWeek> { DayOfWeek.Saturday, DayOfWeek.Saturday });
var tollFreeVehiclesTaxRule = new TollFreeVehiclesTaxRule(tollFreeVehicles);
var tollFreeDateTaxRule = new TollFreeDateTaxRule(tollFreeDates);
//add more rules here if needed

var taxRules = new List<ITaxRule>
            {
                tollFreeDaysOfWeekTaxRule,
                tollFreeVehiclesTaxRule ,
                tollFreeDateTaxRule ,
                tollFeeAmountTaxRule
            };

var taxClaculatorFactory = new TaxClaculatorFactory();

var cityTaxCalculator = taxClaculatorFactory.GetCityTaxCalculator("Gothenburg", taxRules);


DateTime[] dates = new DateTime[]
{
    new DateTime(2013,01,14,21,00,00),
    new DateTime(2013,01,15,21,00,00),
    new DateTime(2013,02,07,06,23,27),
    new DateTime(2013,02,07,15,27,00),
    new DateTime(2013,02,08,06,27,00),
    new DateTime(2013,02,08,06,20,27),
    new DateTime(2013,02,08,14,35,00),
    new DateTime(2013,02,08,15,29,00),
    new DateTime(2013,02,08,15,47,00),
    new DateTime(2013,02,08,16,01,00),
    new DateTime(2013,02,08,16,48,00),
    new DateTime(2013,02,08,17,49,00),
    new DateTime(2013,02,08,18,29,00),
    new DateTime(2013,02,08,18,35,00),
    new DateTime(2013,03,26,14,25,00),
    new DateTime(2013,09,28,14,07,27),
};

var totalTax = cityTaxCalculator.GetTax(new Car(), dates);

Console.WriteLine($"Total tax: {totalTax}");

Console.ReadLine();
