//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PracticaCalificada
{
    using System;
    using System.Collections.Generic;
    
    public partial class CAB_RECETA
    {
        public CAB_RECETA()
        {
            this.DET_RECETA = new HashSet<DET_RECETA>();
        }
    
        public int CREC_ID { get; set; }
        public System.DateTime CREC_FECHA { get; set; }
        public int MEDI_ID { get; set; }
        public int PACI_ID { get; set; }
    
        public virtual MEDICO MEDICO { get; set; }
        public virtual PACIENTE PACIENTE { get; set; }
        public virtual ICollection<DET_RECETA> DET_RECETA { get; set; }
    }
}
