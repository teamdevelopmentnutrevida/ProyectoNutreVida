using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{

    /**
        * Clase HabitoAlimentario, crea el objeto HabitoAlimentario como parte del registro del cliente en los seguimientos
        * @author Yoselyn
        */
    public class HabitoAlimentario
    {
        //inicia atributos
        public int Cedula { set; get; }
        public int ComidaDiaria { set; get; }
        public char ComidaHorasDia { set; get; }
        public int AfueraExpress { set; get; }
        public string ComidaFuera { set; get; }
        public string AzucarBebida { set; get; }
        public string ComidaElaboradCon { set; get; }
        public decimal AguaDiaria { set; get; }
        public char Aderezos { set; get; }
        public char Fruta { set; get; }
        public char Verdura { set; get; }
        public char Leche { set; get; }
        public char Huevo { set; get; }
        public char Yogurt { set; get; }
        public char Carne { set; get; }
        public char Queso { set; get; }
        public char Aguacate { set; get; }
        public char Semillas { set; get; }

        public HabitoAlimentario(int cedula, int comidaDiaria, char comidaHorasDia, int afueraExpress, string comidaFuera, string azucarBebida, string comidaElaboradCon, decimal aguaDiaria, char aderezos, char fruta, char verdura, char leche, char huevo, char yogurt, char carne, char queso, char aguacate, char semillas)
        {
            Cedula = cedula;
            ComidaDiaria = comidaDiaria;
            ComidaHorasDia = comidaHorasDia;
            AfueraExpress = afueraExpress;
            ComidaFuera = comidaFuera;
            AzucarBebida = azucarBebida;
            ComidaElaboradCon = comidaElaboradCon;
            AguaDiaria = aguaDiaria;
            Aderezos = aderezos;
            Fruta = fruta;
            Verdura = verdura;
            Leche = leche;
            Huevo = huevo;
            Yogurt = yogurt;
            Carne = carne;
            Queso = queso;
            Aguacate = aguacate;  
            Semillas = semillas;
            

        }

        public HabitoAlimentario() { }

    }
}
