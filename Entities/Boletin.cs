using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Boletin.Entities
{
 
        public class Boletin
    {
        protected List<float> quices = new List<float>();
        protected List<float> trabajos = new List<float>();
        protected List<float> parciales = new List<float>();

        public Boletin()
        {
        }
        public Boletin(List<float> quices, List<float> trabajos, List<float> parciales)
        {
            this.Quices = quices;
            this.Trabajos = trabajos;
            this.Parciales = parciales;
        }

        public List<float> Quices { get { return quices; } set { quices = value; } }
        public List<float> Trabajos { get { return trabajos; } set { trabajos = value; } }
        public List<float> Parciales { get { return parciales; } set { parciales = value; } }
    }
    }
