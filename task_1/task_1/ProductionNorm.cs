
namespace task_1
{
    public class ProductionNorm
    {
        private static ProductionNorm instance;
        private int MonthlyHoursNorm;

        private ProductionNorm()
        {
            MonthlyHoursNorm = 160;
        }

        public static ProductionNorm GetInstance()
        {
			if (instance == null)
			{
				instance = new ProductionNorm();
			}
			return instance;
		}
		public int MonthlyNorm
		{
			get { return MonthlyHoursNorm; }
		}

        public void IncreaseNorm(int hours)
        {
            MonthlyHoursNorm += hours;
        }
	}
}


/*
 class Singleton
{
    private static Singleton instance;
 
    private Singleton()
    {}
 
    public static Singleton getInstance()
    {
        if (instance == null)
            instance = new Singleton();
        return instance;
    }
}
  */
