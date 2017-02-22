using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Passage
    {
        /// <summary>
        /// Tipo da passagem, GO - Ida | CB - Volta
        /// </summary>
        public enum TypeSelect
        {
            GO = 1,
            CB = 2
        }

        public Passage(Passage.TypeSelect type)
        {
            Type = type.ToString();
        }

        public string Type { get; set; }
        public int Id { get; set; }
        public int IdUser { get; set; }
        public string Number { get; set; }

        /// <summary>
        /// Data de partida
        /// </summary>
        public DateTime DepartureDate { get; set; }

        /// <summary>
        /// Data de chegada
        /// </summary>
        public DateTime ArrivalDate { get; set; }
    }
}
