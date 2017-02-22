using System;

namespace Model
{
    public class Passage
    {
        #region .: Enums :.
        /// <summary>
        /// Tipo da passagem, GO - Ida | CB - Volta
        /// </summary>
        public enum TypeSelect
        {
            GO = 1,
            CB = 2
        }
        #endregion

        #region .: Constructors :.
        /// <summary>
        /// Construtor da passagem que já define seu tipo
        /// </summary>
        /// <param name="type"></param>
        public Passage(Passage.TypeSelect type)
        {
            Type = type.ToString();
        }
        #endregion

        #region .: Attributes :.
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
        #endregion
    }
}
