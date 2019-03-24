using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise_1
{
    public class SingleMission : IMission
    {

        private Func<double, double> funcMission;
        private string name;

        public string Type { get; private set; } = "Single";

        public string Name
        {
            get { return name; }
            private set { name = value; }
        }

        public event EventHandler<double> OnCalculate;

        public SingleMission(Func<double, double> func, string name)
        {
            funcMission = func;
            this.name = name;
        }



        public double Calculate(double value)
        {
            double returnVal = funcMission(value);
            OnCalculate?.Invoke(this, returnVal);
            return returnVal;
        }
    }
}