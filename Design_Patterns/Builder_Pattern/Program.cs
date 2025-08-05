namespace Builder_Pattern
{
    /// <summary>
    /// Builder pattern example where we are creating the Car chunk by chunk
    /// </summary>
    public enum CarType
    {
        Sedan,
        SUV,
        HetchBack,
    }

    public class Car
    {
        public CarType CarType { get; set; }
        public int WheelSize { get; set; }
    }

    public interface ICarType
    {
        public IWheels SetCarType(CarType type);
    }
    public interface IWheels
    {
        public IBuildCar SetWheelsSize(int size);
    }
    public interface IBuildCar
    {
        public Car Build();
    }

    public class CarBuilder : ICarType, IWheels, IBuildCar
    {
        private Car car = new Car();
        public IWheels SetCarType(CarType type)
        {
            car.CarType = type;
            return this;
        }
        public IBuildCar SetWheelsSize(int size)
        {
            car.WheelSize = size;
            return this;
        }
        public Car Build()
        {
            return this.car;
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            CarBuilder builder = new CarBuilder();
            var car = builder.SetCarType(CarType.Sedan).SetWheelsSize(10).Build();
            Console.WriteLine($"CarType is {car.CarType} and Wheel Size is {car.WheelSize}");
        }
    }
}
