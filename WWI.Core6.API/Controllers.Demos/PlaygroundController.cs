using WWI.Core6.Services.Interfaces;

namespace WWI.Core6.API.Controllers.Demos;

/// <summary>
/// Demo controller to experiment with new features in .NET Core 6 and C# 10
/// </summary>
public class PlaygroundController : BaseAPIController
{
    private IFakeDataGeneratorService FakeDataGeneratorService { get; }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="fakeDataGeneratorService"></param>
    /// <param name="applicationServices"></param>
    public PlaygroundController(IFakeDataGeneratorService fakeDataGeneratorService, IApplicationServices applicationServices)
        : base(applicationServices)
    {
        FakeDataGeneratorService = Guard.Against.Null(fakeDataGeneratorService, nameof(fakeDataGeneratorService)); 
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="num"></param>
    /// <returns></returns>
    [HttpGet("bogusNames")]
    public IActionResult GetNames(int num)
    {
        var doctors = FakeDataGeneratorService.GenerateFakeDoctors(num);
        return Ok(doctors);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="num"></param>
    /// <returns></returns>
    [HttpGet("MaxBy")]
    public IActionResult TestMaxBy(int num)
    {
        num = Guard.Against.NegativeOrZero(num, nameof(num));
            
        var faker = new Faker();
            
        var maxByValue = Enumerable.Range(0, num)
            .Select(_ => new
            {
                Name = faker.Name.FirstName() + " " + faker.Name.LastName(),
                Age = faker.Random.Number(50, 70)
            })
            .MaxBy(x => x.Age);

        return Ok(maxByValue);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="num"></param>
    /// <returns></returns>
    [HttpGet("LINQChunk")]
    public IActionResult LinqChunkTest(int num)
    {
        var doctors = FakeDataGeneratorService.GenerateFakeDoctors(num);

        var chunked = doctors
            .Select(p => p.FullName)
            .Chunk((int)Math.Sqrt(num));

        return Ok(chunked);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="num"></param>
    /// <returns></returns>
    [HttpGet("LINQOverloads")]
    public IActionResult OverLoadTest(int num)
    {
        num = Guard.Against.NegativeOrZero(num, nameof(num));

        var randomNumbers = Enumerable.Range(1, num)
            .Select(_ => new Faker().Random.Number(10, 100))
            .ToList();

        var numberslessThan10 = randomNumbers.FirstOrDefault(x => x < 10, -1);

        return Ok(numberslessThan10);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [HttpGet("ConstantInterpolatedStrings")]
    public IActionResult ConstantInterpolatedStrings()
    {
        const string languageReleasePrefix = "C# 10";
        const string languageRelease = $"{ languageReleasePrefix } to be released in November 2021.";

        return Ok(languageRelease);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [HttpGet("lambda")]
    public IActionResult LambdaImprovements()
    {
        var helloWorld = () => "Hello World";

        return Ok();
    }

}