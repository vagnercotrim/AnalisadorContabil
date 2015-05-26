using System;

namespace AnalisadorContabil.Validador
{
    public class Notificacao
    {
        public String Texto { get; set; }
        public Tipo Tipo { get; set; }

        public Notificacao(String texto, Tipo tipo)
        {
            Texto = texto;
            Tipo = tipo;
        }
    }
}
