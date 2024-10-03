using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BattaglieMagiche
{
    public class CPersonaggio
    {
        protected string nome;
        protected int punti_vita;

        protected CPersonaggio(string nome, int punti_vita) 
        {
            this.nome = nome;
            this.punti_vita = punti_vita;
        }

        public virtual int attacca() 
        {
            return 5;
        }

        public void ricevi_danno(int danno) 
        {
            punti_vita -= danno;
        }

        public bool e_vivo() 
        {
            if (punti_vita > 0)
                return true;
            punti_vita = 0;
            return false;
        }

        public string Print() 
        {
            return $"Personaggio: {nome}; Punti vita rimanenti: {punti_vita}.";
        }

        public string GetNome() 
        {
            return nome;
        }
    }

    public class CGuerriero : CPersonaggio
    {
        public CGuerriero(string nome) : base(nome, 100) { }

        public override int attacca() 
        {
            return 20;
        }
    }

    public class CMago : CPersonaggio
    {
        public CMago(string nome) : base(nome, 70) { }

        public override int attacca() 
        {
            Random random = new Random();
            if (random.Next(100) == 0)
                return int.MaxValue;
            return 30;
        }
    }

    public class CArciere : CPersonaggio 
    {
        public CArciere(string nome) : base(nome, 80) { }

        public override int attacca()
        {
            return 25;
        }
    }
}
