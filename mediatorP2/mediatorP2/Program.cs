using System;

namespace mediatorP2
{
    public interface IMediator
    {
        void RegisterRunway(Runway runway);
        void RegisterFlight(Flight flight);
        void SetLandingStatus(bool status);
        bool IsLandingOk();
    }

    public class Runway
    {
        private IMediator _mediator;

        public Runway(IMediator mediator)
        {
            _mediator = mediator;
            _mediator.SetLandingStatus(false);
        }
        public void Land()
        {
            Console.WriteLine("Permiso para aterrizar acptado"); _mediator.SetLandingStatus(false);
            _mediator.SetLandingStatus(true);

        }
    }

    public class Mediator : IMediator
    {
        private Flight _flight;
        private Runway _runway;
        private bool _land;



        public void RegisterFlight(Flight flight)
        {
            _flight = flight;
        }

        public void RegisterRunway(Runway runway)
        {
            _runway = runway;
        }

        public void SetLandingStatus(bool status)
        {
            _land = status;
        }

        public bool IsLandingOk() => _land;
    }
    public class Flight
    {
        private IMediator _mediator;
        public Flight(IMediator mediator)
        {
            _mediator = mediator;
        }
        public void Land()
        {
            if (_mediator.IsLandingOk())
            {
                Console.WriteLine("Se puede aterrizar");
                _mediator.SetLandingStatus(true);
            }
            else
            {
                Console.WriteLine("Esperando disponibilidad para aterrizar");

            }

        }

        class Program
        {
            static void Main(string[] args)
            {
                IMediator mediator = new Mediator();
                Flight flight1 = new Flight(mediator);
                Runway runway = new Runway(mediator);
                mediator.RegisterFlight(flight1);
                mediator.RegisterRunway(runway);
                flight1.Land();
                runway.Land();
                flight1.Land();
                Console.ReadLine();

            }
        }
    }
}
