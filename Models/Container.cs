namespace lab_4.Models
{
    public class Container
    {
        public int ID { get; set; }
        virtual public string weight { get; set; }
        public List<SmallItem> items { get; set; }

        public Container(string weight)
        {
            this.weight = weight;
            items = new List<SmallItem>();
        }

        virtual public double consumption() { return 0; }
        virtual public bool equals(Container other) { return true; }
        virtual public void addItem(SmallItem item)
        {
            items.Add(item);
            Console.WriteLine("Item was added, total items in container: " + items.Count);
        }
    }

    public class BasicContainer : Container
    {
        public BasicContainer(string weight) : base(weight) { }
        public override double consumption()
        {
            return Convert.ToDouble(this.weight) * 2.5;
        }
        public override bool equals(Container other)
        {
            bool res = (typeof(BasicContainer) == typeof(Container)) ? true : false;
            return res;
        }

    }

    public class HeavyContainer : Container
    {
        public HeavyContainer(string weight) : base(weight) { }
        public override double consumption()
        {
            return Convert.ToDouble(this.weight) * 3.0;
        }
        public override bool equals(Container other)
        {
            bool res = (typeof(HeavyContainer) == typeof(Container)) ? true : false;
            return res;
        }
    }

    public class RefrigiratedContainer : HeavyContainer
    {
        public RefrigiratedContainer(string weight) : base(weight) { }
        public override double consumption()
        {
            return Convert.ToDouble(this.weight) * 5.0;
        }
        public override bool equals(Container other)
        {
            bool res = (typeof(RefrigiratedContainer) == typeof(Container)) ? true : false;
            return res;
        }

    }

    public class LiquidContainer : HeavyContainer
    {
        public LiquidContainer(string weight) : base(weight) { }
        public override double consumption()
        {
            return Convert.ToDouble(this.weight) * 4.0;
        }
        public override bool equals(Container other)
        {
            bool res = (typeof(LiquidContainer) == typeof(Container)) ? true : false;
            return res;
        }
    }

    public interface IAbstractItem
    {
        public void setWeight(int weight);
    }

    public class SmallItem : IAbstractItem
    {
        public int ID { get; set; }
        public int weight { get; set; } = 0;

        public void setWeight(int weight)
        {
            this.weight = weight * 2;
        }
    }

    public class LargeItem : IAbstractItem
    {
        public int weight { get; set; } = 0;

        public void setWeight(int weight)
        {
            this.weight = weight * 5;
        }
    }

    public class RefrigiratorItem : IAbstractItem
    {
        public int weight { get; set; } = 0;

        public void setWeight(int weight)
        {
            this.weight = weight * 3;
        }
    }

    public class LiquidItem : IAbstractItem
    {
        public int weight { get; set; } = 0;

        public void setWeight(int weight)
        {
            this.weight = weight * 4;
        }
    }
}
