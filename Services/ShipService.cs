using lab_4.Models;
using lab_4.Models.ModelsController;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using Container = lab_4.Models.Container;

namespace lab_4.Services
{
    public interface IShipService
    {
        public Task<bool> CreateShip(ShipController ship);
        public Task<bool> CreatePort(PortController port);
        public Task<bool> CreateContainer(ContainerController container);

        public Task<bool> IncomingShip(int ship_id, int port_id);
        public Task<bool> OutgoingShip(int ship_id, int port_id);
        public Task<double> GetDistance(int port_one_id, int port_two_id);
    }

    public class ShipService : IShipService
    {
        ApplicationContext _context;

        public ShipService(ApplicationContext context)
        {
            this._context = context;
        }

        public async Task<bool> CreateShip(ShipController ship)
        {
            Director director = new Director(new ConcreteShipBuilder());
            Ship s = new Ship
            (
                ship.fuel,
                ship.currentPort,
                ship.totalWeightCapacity,
                ship.maxNumberOfAllContainers,
                ship.maxNumberOfHeavyContainers,
                ship.maxNumberOfRefrigeratedContainers,
                ship.maxNumberOfLiquidContainers,
                ship.fuelConsumptionPerKM
            );
            director.BuildShip(s);
            _context.Ships.Add((Ship)director._builder.GetShip());
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> CreatePort(PortController port)
        {
            Port p = new Port(port.latitude, port.longitude);
            _context.Ports.Add(p);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> CreateContainer(ContainerController container)
        {
            Container cont = new Container(container.weight)
            {
                items = container.items
            };
            _context.Containers.Add(cont);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> IncomingShip(int ship_id, int port_id)
        {
            Ship ship = _context.Ships.Where(x => x.ID == ship_id).Single();
            Port port = _context.Ports.Where(x => x.ID == port_id).Single();
            port.incomingShip(ship);
            _context.Ports.Update(port);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> OutgoingShip(int ship_id, int port_id)
        {
            Ship ship = _context.Ships.Where(x => x.ID == ship_id).Single();
            Port port = _context.Ports.Where(x => x.ID == port_id).Single();
            port.outgoingShip(ship);
            _context.Ports.Update(port);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<double> GetDistance(int port_one_id, int port_two_id)
        {
            Port port_one = await _context.Ports.Where(x => x.ID == port_one_id).SingleAsync();
            Port port_two = await _context.Ports.Where(x => x.ID == port_two_id).SingleAsync();
            return port_one.getDistance(port_two);
        }
    }
}

public class Director
{
    public IShipBuilder _builder { get; set; }

    public Director(IShipBuilder _builder)
    {
        this._builder = _builder;
    }

    public void BuildShip(IShip p)
    {
        this._builder.MakeShip(p);
    }

    public void BuildShipL(IShip p)
    {
        this._builder.MakeLightShip(p);
    }

    public void BuildShipM(IShip p)
    {
        this._builder.MakeMediumShip(p);
    }

    public void BuildShipH(IShip p)
    {
        this._builder.MakeHeavyShip(p);
    }
}

public interface IShipBuilder
{
    void Reset();
    void MakeShip(IShip s);
    void MakeLightShip(IShip s);
    void MakeMediumShip(IShip s);
    void MakeHeavyShip(IShip s);
    IShip GetShip();
}

public class ConcreteShipBuilder : IShipBuilder
{
    private IShip ship = null;

    public ConcreteShipBuilder()
    {
        this.Reset();
    }

    public void Reset()
    {
        this.ship = null;
    }

    public void MakeShip(IShip s)
    {
        this.ship = s;
    }

    public void MakeLightShip(IShip s)
    {
        this.ship = s;
    }

    public void MakeMediumShip(IShip s)
    {
        this.ship = s;
    }

    public void MakeHeavyShip(IShip s)
    {
        this.ship = s;
    }

    public IShip GetShip()
    {
        IShip result = this.ship;

        this.Reset();

        return result;
    }
}

public interface IAbstractItemFactory
{
    IAbstractItem CreateSmallItem();
    IAbstractItem CreateLargeItem();
    IAbstractItem CreateRefrigiratorItem();
    IAbstractItem CreateLiquidItem();
}

public class ItemFactory : IAbstractItemFactory
{
    public IAbstractItem CreateSmallItem()
    {
        return new SmallItem();
    }

    public IAbstractItem CreateLargeItem()
    {
        return new LargeItem();
    }

    public IAbstractItem CreateRefrigiratorItem()
    {
        return new RefrigiratorItem();
    }

    public IAbstractItem CreateLiquidItem()
    {
        return new LiquidItem();
    }
}