using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizio_27_Stefanini
{
    class Program
    {
        public abstract class FigGeometrica : IComparable, ICloneable
        {
            protected string figura;
            protected double area;
            protected double perimetro;

            public abstract double getArea();
            public abstract double getPerimetro();
            public abstract FigGeometrica Clone();

            object ICloneable.Clone()
            {
                return (object)Clone();
            }

            public override string ToString()
            {
                return figura + " di area " + area + " e di perimetro " + perimetro;
            }

            public int CompareTo(object obj)
            {
                FigGeometrica f = (FigGeometrica)obj;
                if (area > f.getArea())
                {
                    return 1;
                }
                else if (area < f.getArea())
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }

            /*public override bool Equals(object obj)
            {
                FigGeometrica f = (FigGeometrica)obj;
                if (this.GetType() == f.GetType())
                {
                    if (this.getPerimetro() == f.getPerimetro() && this.getArea() == f.getArea())
                    {
                        return true;
                    }
                    return false;
                }
                else
                {
                    return false;
                }
            }*/
        }

        class Triangolo : FigGeometrica
        {
            private int Base;
            private int lato1;
            private int lato2;
            private int altezza;

            public Triangolo(int Base, int lato1, int lato2, int altezza)
            {
                this.Base = Base;
                this.lato1 = lato1;
                this.lato2 = lato2;
                this.altezza = altezza;
                this.figura = "triangolo";
                area = (Base * altezza) / 2;
                perimetro = (Base + lato1 + lato2);
            }

            public override double getArea()
            {
                return area;
            }

            public override double getPerimetro()
            {
                return perimetro;
            }

            public override FigGeometrica Clone()
            {
                FigGeometrica f = new Triangolo(Base, lato1, lato2, altezza);
                return f;
            }

            public override bool Equals(object obj)
            {
                Triangolo t;
                if(!(obj is Triangolo))
                {
                    throw new FiuguraErrata("Eccezione generata: hai provato a fare il casting di una figura sbagliata");
                }
                else
                {
                    t = (Triangolo)obj;
                    if (this.Base == t.Base && this.lato1 == t.lato1 && this.lato2 == t.lato2)
                    {
                        return true;
                    }
                    return false;
                }    
            }
        }

        class Quadrato : Rettangolo
        {

            public Quadrato(int lato) : base(lato, lato)
            {
                this.figura = "quadrato";
                area = (lato * lato);
                perimetro = (lato * 4);
            }

            public override double getArea()
            {
                return area;
            }

            public override double getPerimetro()
            {
                return perimetro;
            }

            public override FigGeometrica Clone()
            {
                FigGeometrica f = new Quadrato(lato);
                return f;
            }

            public override bool Equals(object obj)
            {
                try
                {
                    Quadrato q = (Quadrato)obj;
                    if (this.lato == q.lato)
                    {
                        return true;
                    }
                    return false;
                }
                catch (InvalidCastException)
                {
                    return false;
                }
            }
        }

        class Rettangolo : FigGeometrica
        {
            protected int lato;
            private int altezza;

            public Rettangolo(int lato, int altezza)
            {
                this.lato = lato;
                this.altezza = altezza;
                this.figura = "rettangolo";
                area = (lato * altezza);
                perimetro = (lato + altezza) * 2;
            }

            public override double getArea()
            {
                return area;
            }

            public override double getPerimetro()
            {
                return perimetro;
            }

            public override FigGeometrica Clone()
            {
                FigGeometrica f = new Rettangolo(lato, altezza);
                return f;
            }

            public override bool Equals(object obj)
            {
                Rettangolo r;
                if (!(obj is Rettangolo))
                {
                    throw new FiuguraErrata("Eccezione generata: hai provato a fare il casting di una figura sbagliata");
                }
                else
                {
                    r = (Rettangolo)obj;
                    if (this.altezza == r.altezza && this.lato == r.lato )
                    {
                        return true;
                    }
                    return false;
                }
            }
        }

        class Circonferenza : FigGeometrica
        {
            int raggio;

            public Circonferenza(int raggio)
            {
                this.raggio = raggio;
                this.figura = "circonferenza";

                area = (raggio * raggio) * Math.PI;
                perimetro = (2 * Math.PI) * raggio;
            }

            public override double getArea()
            {
                return area;
            }

            public override double getPerimetro()
            {
                return perimetro;
            }

            public override FigGeometrica Clone()
            {
                FigGeometrica f = new Circonferenza(raggio);
                return f;
            }

            public override bool Equals(object obj)
            {
                try
                {
                    Circonferenza c = (Circonferenza)obj;
                    if (this.raggio == c.raggio)
                    {
                        return true;
                    }
                    return false;
                }
                catch (InvalidCastException)
                {
                    return false;
                }
            }
        }

        class Rombo : Quadrato
        {
            private int diagonaleMax;
            private int diagonaleMin;

            public Rombo(int lato, int diagonaleMax, int diagonaleMin) : base(lato)
            {
                this.diagonaleMax = diagonaleMax;
                this.diagonaleMin = diagonaleMin;
                this.figura = "rombo";
                area = (diagonaleMax * diagonaleMin) / 2;
                perimetro = (lato * 4);
            }

            public override double getArea()
            {
                return area;
            }

            public override double getPerimetro()
            {
                return perimetro;
            }

            public override FigGeometrica Clone()
            {
                FigGeometrica f = new Rombo(lato, diagonaleMax, diagonaleMin);
                return f;
            }

            public override bool Equals(object obj)
            {
                Rombo r;
                if (!(obj is Rombo))
                {
                    throw new FiuguraErrata("Eccezione generata: hai provato a fare il casting di una figura sbagliata");
                }
                else
                {
                    r = (Rombo)obj;
                    if (this.lato == r.lato && this.diagonaleMax == r.diagonaleMax && this.diagonaleMin == r.diagonaleMin)
                    {
                        return true;
                    }
                    return false;
                }
            }
        }

        public class ListaFig
        {

            List<FigGeometrica> l;

            public ListaFig()

            {

                l = new List<FigGeometrica>();

            }

            public void Add(FigGeometrica f)

            {

                l.Add(f);

            }

            public FigGeometrica getAreaMaggiore()
            {
                double m = 0;
                FigGeometrica max = null;
                foreach (FigGeometrica f in l)
                {
                    if (m < f.getArea())
                    {
                        max = f;
                        m = f.getArea();
                    }
                }
                Console.WriteLine("La figura con l'area maggiore è un " + max);
                return max;
            }

            public FigGeometrica getPerimetroMinore()
            {
                bool t = false;
                double m = 0;
                FigGeometrica min = null;
                foreach (FigGeometrica f in l)
                {
                    if (t == false)
                    {
                        min = f;
                        m = f.getArea();
                        t = true;
                    }
                    if (m > f.getArea())
                    {
                        min = f;
                        m = f.getArea();
                    }
                }
                Console.WriteLine("La figura con il perimetro minore è un " + min);
                return min;
            }

            public void stampa()
            {
                foreach (FigGeometrica f in l)
                {
                    Console.WriteLine(f);
                }
            }

            public void Sort()
            {
                l.Sort();// è un metodo della classe list<T> che utilizza in autmatico il CompareTo
            }

            private static bool AreaMaggiore10(FigGeometrica obj)
            {
                return obj.getArea() > 10;
            }

            public FigGeometrica CercaAMaxdi10()
            {
                Predicate<FigGeometrica> p = AreaMaggiore10; //predicate cerca un elemento di tipo<T> all'interno della lista rispettando le condizioni dopo l'uguale
                Console.WriteLine("La figura geometrica  seguente ha l'area maggiore di 10: ");
                return l.Find(p);
            }

            public void Rimuovi()
            {
                l.Remove(l.Last());
            }

            public void RimuoviIndex(int i)
            {
                l.RemoveAt(i);
            }

            
            /*public FigGeometrica AreaMaxT()
            {
                double m = 0;
                Triangolo t = null;
                foreach (FigGeometrica f in l)
                {
                    if (f is Triangolo) 
                    {
                        if (m < f.getArea())
                        {
                            t = (Triangolo)f.Clone();
                            m = f.getArea();
                        }
                    }
                }
                return t;
            }

            public FigGeometrica AreaMaxRett()
            {
                double m = 0;
                Rettangolo r = null;
                foreach (FigGeometrica f in l)
                {
                    if (f is Rettangolo)
                    {
                        if (m < f.getArea())
                        {
                            r = (Rettangolo)f.Clone();
                            m = f.getArea();
                        }
                    }
                }
                return r;
            }

            public FigGeometrica AreaMaxQ()
            {
                double m = 0;
                Quadrato q = null;
                foreach (FigGeometrica f in l)
                {
                    if (f is Quadrato)
                    {
                        if (m < f.getArea())
                        {
                            q = (Quadrato)f.Clone();
                            m = f.getArea();
                        }
                    }
                }
                return q;
            }

            public FigGeometrica AreaMaxC()
            {
                double m = 0;
                Circonferenza c = null;
                foreach (FigGeometrica f in l)
                {
                    if (f is Circonferenza)
                    {
                        if (m < f.getArea())
                        {
                            c = (Circonferenza)f.Clone();
                            m = f.getArea();
                        }
                    }
                }
                return c;
            }

            public FigGeometrica AreaMaxRom()
            {
                double m = 0;
                Rombo r = null;
                foreach (FigGeometrica f in l)
                {
                    if (f is Rombo)
                    {
                        if (m < f.getArea())
                        {
                            r = (Rombo)f.Clone();
                            m = f.getArea();
                        }
                    }
                }
                return r;
            }

            public List<FigGeometrica> getAreeMax()
            {
                Predicate<FigGeometrica> t = AreaMaxT();
            }

            //fatto in classe alla lavagna con questo metodo
            */

            public ListaFig maxAreaFigure()
            {
                ListaFig ris = new ListaFig();
                FigGeometrica tmpMax;
                foreach (FigGeometrica f in this.l)
                {
                    if (ris.l.Find(fig => fig.GetType() == f.GetType()) == null)
                    {
                        tmpMax = f;
                        foreach (FigGeometrica i in this.l)
                        {
                            if (f.GetType() == i.GetType())
                            {
                                tmpMax = (i.CompareTo(tmpMax) > 0) ? i : tmpMax;
                            }
                        }
                        ris.Add(tmpMax);
                    }
                }
                return ris;
            }
        }

        static void Main(string[] args)
        {
            FigGeometrica q1 = new Quadrato(4);
            FigGeometrica q2 = new Quadrato(4);
            FigGeometrica c1 = new Circonferenza(4);
            FigGeometrica c2 = new Circonferenza(3);
            FigGeometrica t1 = new Triangolo(1, 2, 3, 4);
            FigGeometrica t2 = new Triangolo(1, 3, 3, 4);
            FigGeometrica ro1 = new Rombo(4,6,3);
            FigGeometrica ro2 = new Rombo(5, 6, 3);
            FigGeometrica re1 = new Rettangolo(4, 6);
            FigGeometrica re2 = new Rettangolo(5, 6);

            Console.WriteLine(c1.Equals(q2));// eccezione gestita nel metodo; output:False
            Console.WriteLine(q1.Equals(q2));// nessuna eccezione; output:True
            Console.WriteLine(t1.Equals(t2));// nessuna eccezione; output:False

            try
            {
                Console.WriteLine(t1.Equals(q2));//eccezione sollevata; output:eccezione
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            Console.WriteLine("ciap");


            Console.ReadKey();
        }
    }
}
