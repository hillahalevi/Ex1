using System;
using System.Collections.Generic;
using System.Linq;

namespace Excercise_1
{

    public class FunctionsContainer
    {
        Dictionary<string, Func<double, double>> functions = new Dictionary<string, Func<double, double>>();

        public List<string> getAllMissions()
        {
            return functions.Keys.ToList();
        }

        public Func<double, double> this[string key]
        {
            get
            {
                if (functions.ContainsKey(key))
                {
                    return functions[key];
                }
                else
                {
                    functions.Add(key, val => val);
                    return val => val;
                }
            }
            set
            {
                functions[key] = value;
            }
        }

    }
}