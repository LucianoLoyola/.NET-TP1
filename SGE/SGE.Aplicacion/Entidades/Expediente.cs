﻿using System.Runtime.CompilerServices;

namespace SGE.Aplicacion;

public class Expediente
{
    public int Id { get; set; } //debe ser un entero valido mayor a 0 
    public string caratula { get; set; } = ""; //no puede estar vacia 
    public DateTime fechaHoraCreacion { get; set; }
    public DateTime fechaHoraUModificacion { get; set; }
    public int IdUsuarioMod { get; set; }
    public Estado estado { get; set; }
    public override string ToString(){
        return $"Los datos del Expediente son: \n Caratula: '{caratula}' | Id:{Id}";
    }

}
