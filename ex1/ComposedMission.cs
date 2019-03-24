using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise_1
{
    public class ComposedMission : IMission
    {
        //functions to run mission
        private LinkedList<Func<double, double>> funcMissions = new LinkedList<Func<double, double>>();
        private string name;

        //init type to "Composed"
        public string Type { get; private set; } = "Composed";

        public string Name
        {
            get { return name; }
            private set { name = value; }
        }

        public event EventHandler<double> OnCalculate;

        public ComposedMission(string name)
        {
            this.name = name;
        }

        public ComposedMission Add(Func<double, double> func)
        {
            //add new function to the list of functions
            funcMissions.AddLast(func);
            return this;
        }

        public double Calculate(double value)
        {
            double returnVal = value;
            foreach (Func<double, double> f in funcMissions)
            {
                returnVal = f(returnVal);
            }
            OnCalculate?.Invoke(this, returnVal);
            return returnVal;
        }

    }
}